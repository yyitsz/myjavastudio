using System;
using System.Collections.Generic;
using System.Text;

namespace SqlParser
{
    public class Parser
    {
        int index;
        int lastIndex;
        int length;
        string sql;

        private Dictionary<String, object> varList = new Dictionary<string, object>();

        public ICollection<String> VarList
        {
            get { return varList.Keys; }
        }


        public Parser(string sql)
        {
            index = 0;
            lastIndex = 0;
            this.sql = "{" + sql + "}";
            length = this.sql.Length;

        }
        public Expression Parse()
        {
            return ParseLiteral();
        }

        private Expression ParseLiteral()
        {
            int braceCount = 0;

            SkipBlank();
            CheckLeftBrace('{');
            braceCount++;

            index++;
            lastIndex = index;
            LiteralExpression root = new LiteralExpression();
            bool isQuota = false;
            bool isEscaped = false;
            bool isInNamedVar = false;
            int namedVarStartedIndex = 0;
            while (index < length)
            {
                if (sql[index] == '\'')// 'abc
                {
                    if (isQuota == false)
                    {
                        isEscaped = false;
                        isQuota = true;
                    }
                    else if (IsEscapeChar()) // 'abc'' 
                    {
                        isEscaped = true;
                    }
                    else if (isEscaped) // 'abc''
                    {
                        //conitinue
                        isEscaped = false;
                    }
                    else if (NextCharIsWordEnd()) // 'abc'''
                    {
                        isQuota = false;
                    }

                }
                else if (isQuota == false)
                {
                    if (sql[index] == '@')
                    {
                        Token token;
                        if (TryGetToken(out token))
                        {
                            StringExpression sexp = new StringExpression(sql.Substring(lastIndex, index - lastIndex));
                            root.Append(sexp);
                            lastIndex = index + token.ToString().Length + 1;
                            index = lastIndex;
                            Expression tokenExp = ParseToken(token);
                            root.Append(tokenExp);
                            index--; //compensate
                        }
                    }
                    else if (sql[index] == ':')
                    {
                        isInNamedVar = true;
                        namedVarStartedIndex = index;
                    }
                    else if (isInNamedVar && NextCharIsWordEndForNamedVar())
                    {
                        string varName = sql.Substring(namedVarStartedIndex + 1, index - namedVarStartedIndex);
                        varList[varName] = null;
                        isInNamedVar = false;
                    }
                    else if (IsBlank(sql[index]))
                    {
                    }
                    else if (sql[index] == '{') // { ....{
                    {
                        braceCount++;
                    }
                    else if (sql[index] == '}')
                    {
                        if (braceCount == 1)// {.....}
                        {
                            break;
                        }
                        else // { ...{ ....}
                        {
                            braceCount--;
                        }
                    }
                }
                index++;
            }

            if (index < length && sql[index] == '}')
            {
                string result = sql.Substring(lastIndex, index - lastIndex);
                StringExpression sexp = new StringExpression(result);
                lastIndex = index + 1;
                index++;
                root.Append(sexp);
            }
            else
            {
                throw new Exception("Syntax Error, Should end } char at " + index.ToString());
            }
            return root;
        }

        private bool IsEscapeChar()
        {
            if (index + 1 < length && sql[index + 1] == '\'')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool TryParseVar(out string var)
        {
            var = null;
            return false;
        }

        private void CheckLeftBrace(char c)
        {
            if (sql[index] != c)
            {
                throw new Exception("Syntax Error, Should Start + [" + c + "] char at " + index.ToString());
            }
        }

        private void CheckRightBrace(char c)
        {
            if (sql[index] != c)
            {
                throw new Exception("Syntax Error, Should End + [" + c + "] char at " + index.ToString());
            }
        }

        private Expression ParseToken(Token token)
        {
            if (token == Token.If)
            {
                return ParseIf();
            }
            else if (token == Token.And || token == Token.Or)
            {
                return ParseAndOrExp(token);
            }
            else if (token == Token.Where)
            {
                return ParseWhere();
            }
            else if (token == Token.In)
            {
                return ParseIn();
            }

            throw new NotSupportedException("Not support token" + token);
        }

        private Expression ParseIn()
        {
            int braceCount = 0;

            SkipBlank();
            CheckLeftBrace('(');
            braceCount++;

            index++;
            lastIndex = index;
            InExpression root = new InExpression();
            string columnName = null;
            string propertyName = null;

            bool isInNamedVar = false;
            int namedVarStartedIndex = 0;
            while (index < length)
            {
                char c = sql[index];
                if ((c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z') || c=='.' || c=='_')
                {
                    if (isInNamedVar == false)
                    {
                        isInNamedVar = true;
                        namedVarStartedIndex = index;
                    }
                    else if (NextCharIsWordEndForNamedVar())
                    {
                        string varName = sql.Substring(namedVarStartedIndex , index - namedVarStartedIndex + 1);
                        if (columnName == null)
                        {
                            columnName = varName;
                        }
                        else if (propertyName == null)
                        {
                            propertyName = varName;
                        }
                        else
                        {
                            throw new Exception("Syntax Error. Invalid char in @in expression. @in expression : @in(columnName, propertyName)");
                        }
                        isInNamedVar = false;
                    }
                }
                else if (IsBlank(c))
                {
                }
                else if (c == ',')
                {
                }
                 else if (c == ')')
                {
                    break;
                }
                else
                {
                    throw new Exception("Syntax Error. Invalid char in @in expression. @in expression : @in(columnName, propertyName)");
                }

                index++;
            }

            if (index < length && sql[index] == ')')
            {
                if (columnName == null || propertyName == null)
                {
                    throw new Exception("Syntax Error. Invalid char in @in expression. @in expression : @in(columnName, propertyName)");
                }
                root.ColumnName = columnName;
                root.PropertyName = propertyName;

                lastIndex = index + 1;
                index++;
            }
            else
            {
                throw new Exception("Syntax Error, Should end } char at " + index.ToString());
            }
            return root;
        }

        private void CheckEnd()
        {
            if (index >= length)
            {
                throw new Exception("Syntax error");
            }
        }

        private void SkipBlank()
        {

            while (index < length)
            {
                Char c = sql[index];
                if (IsBlank(c))
                {
                    index++;
                    continue;
                }
                break;
            }
        }

        private static bool IsBlank(Char c)
        {
            return c == '\r' || c == '\n' || c == '\t' || c == ' ';
        }

        private Expression ParseWhere()
        {
            int braceCount = 0;
            SkipBlank();
            CheckEnd();
            CheckLeftBrace('{');
            braceCount++;
            index++;
            WhereExpression whereExp = new WhereExpression();

            while (index < length)
            {
                if (sql[index] == '@')
                {
                    Token token;
                    if (TryGetToken(out token))
                    {
                        lastIndex = index + token.ToString().Length + 1;
                        index = lastIndex;
                        Expression tokenExp = ParseToken(token);
                        whereExp.Append(tokenExp);
                        index--; //compensate
                    }
                    else
                    {
                        throw new Exception("Syntax Error, In Or, And expression, @ must be follow a legal token.");
                    }
                }
                else if (sql[index] == '}')
                {
                    break;
                }
                else if (IsBlank(sql[index]))
                {
                }
                else
                {
                    throw new Exception("Syntax Error, In Or, error char at location: " + index.ToString());
                }
                index++;
            }

            if (sql[index] == '}')
            {
                index++;
                lastIndex = index;
            }
            else
            {
                CheckEnd();
                if (sql[index] != '}')
                {
                    throw new Exception("Syntax Error, Should end } char at " + index.ToString());
                }
            }
            return whereExp;
        }

        private Expression ParseAndOrExp(Token rooToken)
        {
            int braceCount = 0;
            SkipBlank();
            CheckEnd();
            CheckLeftBrace('{');
            braceCount++;
            index++;
            Expression expression = null;
            if (rooToken == Token.And)
            {
                expression = new AndExpression();
            }
            else if (rooToken == Token.Or)
            {
                expression = new OrExpression();
            }
            else
            {
                throw new Exception("Only And/ Or token are supported.");
            }

            while (index < length)
            {

                if (sql[index] == '@')
                {
                    Token token;
                    if (TryGetToken(out token))
                    {
                        lastIndex = index + token.ToString().Length + 1;
                        index = lastIndex;
                        Expression tokenExp = ParseToken(token);
                        expression.Append(tokenExp);
                        index--; //compensate
                    }

                    else
                    {
                        throw new Exception("Syntax Error, In Or, And expression, @ must be follow a legal token.");
                    }
                }
                else if (sql[index] == ',')
                {

                }
                else if (IsBlank(sql[index]))
                {
                }
                else if (sql[index] == '{') // @or{ {} }
                {
                    expression.Append(ParseLiteral());
                    index--; //compensate
                }
                else if (sql[index] == '}')
                {
                    break;
                }
                else
                {
                    throw new Exception("Syntax Error, In Or, error char at location: " + index.ToString());
                }
                index++;
            }

            if (sql[index] == '}')
            {
                index++;
                lastIndex = index;
            }
            else
            {
                CheckEnd();
                if (sql[index] != '}')
                {
                    throw new Exception("Syntax Error, Should end } char at " + index.ToString());
                }
            }
            return expression;
        }

        private Expression ParseIf()
        {
            IfExpression ifExpression = new IfExpression();
            ConditionalExpression firstIfExp = new ConditionalExpression();

            SkipBlank();
            CheckEnd();
            firstIfExp.Condition = ParseCondition();
            SkipBlank();
            CheckLeftBrace('{');
            firstIfExp.Exp = ParseLiteral();
            ifExpression.Append(firstIfExp);

            while (index < length)
            {

                if (sql[index] == '@')
                {
                    Token token;
                    if (TryGetToken(out token))
                    {
                        lastIndex = index + token.ToString().Length + 1;
                        index = lastIndex;
                        if (token == Token.ElseIf)
                        {
                            ConditionalExpression condExpr = new ConditionalExpression();
                            SkipBlank();
                            CheckEnd();
                            condExpr.Condition = ParseCondition();
                            SkipBlank();
                            CheckLeftBrace('{');
                            condExpr.Exp = ParseLiteral();

                            ifExpression.Append(condExpr);
                        }
                        else if (token == Token.Else)
                        {
                            SkipBlank();
                            CheckEnd();
                            CheckLeftBrace('{');
                            Expression exp = ParseLiteral();
                            ifExpression.DefaultExp = exp;
                        }
                        else
                        {
                            throw new Exception("Unsupported token " + token);
                        }
                        index--; //compensate
                    }
                    else
                    {
                        throw new Exception("Syntax Error, In expression, @ must be follow a legal token.");
                    }
                }
                else if (IsBlank(sql[index]))
                {
                }
                else
                {
                    break;
                }
                index++;
            }


            return ifExpression;
        }

        private string ParseCondition()
        {
            string result = "";
            SkipBlank();
            CheckLeftBrace('(');
            int braceCount = 1;
            index++;
            lastIndex = index;
            bool isQuota = false;
            bool isEscaped = false;

            while (index < length)
            {
                if (sql[index] == '"')// "abc
                {
                    if (isQuota == false)
                    {
                        isEscaped = false;
                        isQuota = true;
                    }
                    else if (sql[index] == '\\') // "abc\"
                    {
                        isEscaped = true;
                    }
                    else if (isEscaped) // "abc\"
                    {
                        //conitinue
                        isEscaped = false;
                    }
                    else if (NextCharIsWordEnd()) // "abc\""
                    {
                        isQuota = false;
                    }

                }
                else if (isQuota == false)
                {
                    if (sql[index] == '(') // ( ....(
                    {
                        braceCount++;
                    }
                    else if (sql[index] == ')')
                    {
                        if (braceCount == 1)// (.....)
                        {
                            break;
                        }
                        else // ( ...( ....(
                        {
                            braceCount--;
                        }
                    }
                }
                index++;
            }

            if (index < length && sql[index] == ')')
            {
                result = sql.Substring(lastIndex, index - lastIndex);
                index++;
                lastIndex = index;
            }
            else
            {
                CheckEnd();
                CheckRightBrace(')');
            }
            return result;
        }

        private bool TryGetToken(out Token token)
        {
            if (index + 2 < length)//@if, @or
            {
                if ((sql[index + 1] == 'i' || sql[index + 1] == 'I')
                    && (sql[index + 2] == 'f' || sql[index + 2] == 'F'))
                {
                    token = Token.If;
                    return true;
                }
                if ((sql[index + 1] == 'o' || sql[index + 1] == 'O')
                    && (sql[index + 2] == 'r' || sql[index + 2] == 'R'))
                {
                    token = Token.Or;
                    return true;
                }
            }

            if (index + 3 < length)//@and
            {
                if ((sql[index + 1] == 'a' || sql[index + 1] == 'A')
                    && (sql[index + 2] == 'n' || sql[index + 2] == 'N')
                    && (sql[index + 3] == 'd' || sql[index + 3] == 'D'))
                {
                    token = Token.And;
                    return true;
                }

            }
            if (index + 5 < length)//@where
            {
                if ((sql.Substring(index + 1, 5).ToLower() == "where"))
                {
                    token = Token.Where;
                    return true;
                }
            }

            if (index + 6 < length)//@elseif
            {
                if ((sql.Substring(index + 1, 6).ToLower() == "elseif"))
                {
                    token = Token.ElseIf;
                    return true;
                }
            }

            if (index + 4 < length)//@else
            {
                if ((sql.Substring(index + 1, 4).ToLower() == "else"))
                {
                    token = Token.Else;
                    return true;
                }
            }

            if (index + 2 < length)//@in
            {
                if ((sql.Substring(index + 1, 2).ToLower() == "in"))
                {
                    token = Token.In;
                    return true;
                }
            }

            token = Token.Unsupported;
            return false;
        }

        private bool NextCharIsWordEnd()
        {
            if (index < length - 1)
            {
                char c = sql[index + 1];
                if (c == '\r' || c == '\n' || c == '\t'
                    || c == ' '  // must be in quota status
                    || c == '}'  //for }, must be in quota status, i.e. 'abcd'}
                    || c == ')' //for ), must be in quota status, i.e. 'abcd')
                    || c == '<'
                    || c == '>'
                    || c == '='
                    ) //
                {
                    return true;
                }
                return false;
            }
            return true;
        }

        private bool NextCharIsWordEndForNamedVar()
        {
            if (index < length - 1)
            {
                char c = sql[index + 1];
                if (c >= 'a' && c <= 'z'
                    || c >= 'A' && c <= 'Z'
                    || c == '_'
                    || c >= '0' && c <= '9'
                    || c == '.'
                    )
                {
                    return false;
                }
                return true;
            }
            return true;
        }

    }
}
