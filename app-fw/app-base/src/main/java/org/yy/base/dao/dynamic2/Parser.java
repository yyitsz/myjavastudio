package org.yy.base.dao.dynamic2;

import java.util.Collection;
import java.util.HashMap;
import java.util.Map;

public class Parser {
	int index;
	int lastIndex;
	int length;
	String sql;

	private Map<String, Object> varList = new HashMap<String, Object>();

	public Collection<String> getVarList() {
		return varList.keySet();
	}

	public Parser(String sql) {
		index = 0;
		lastIndex = 0;
		this.sql = "{" + sql + "}";
		length = this.sql.length();

	}

	public Expression Parse() {
		return ParseLiteral();
	}

	private Expression ParseLiteral() {
		int braceCount = 0;

		SkipBlank();
		CheckLeftBrace('{');
		braceCount++;

		index++;
		lastIndex = index;
		LiteralExpression root = new LiteralExpression();
		boolean isQuota = false;
		boolean isEscaped = false;
		boolean isInNamedVar = false;
		int namedVarStartedIndex = 0;
		while (index < length) {
			char c = sql.charAt(index);

			if (c == '\'')// 'abc
			{
				if (isQuota == false) {
					isEscaped = false;
					isQuota = true;
				} else if (IsEscapeChar()) // 'abc''
				{
					isEscaped = true;
				} else if (isEscaped) // 'abc''
				{
					// conitinue
					isEscaped = false;
				} else if (NextCharIsWordEnd()) // 'abc'''
				{
					isQuota = false;
				}

			} else if (isQuota == false) {
				if (c == '@') {
					Token token = TryGetToken();
					if (token != Token.Unsupported) {
						StringExpression sexp = new StringExpression(sql
								.substring(lastIndex, index));
						root.Append(sexp);
						lastIndex = index + token.toString().length() + 1;
						index = lastIndex;
						Expression tokenExp = ParseToken(token);
						root.Append(tokenExp);
						index--; // compensate
					}
				} else if (c == ':') {
					isInNamedVar = true;
					namedVarStartedIndex = index;
				} else if (isInNamedVar && NextCharIsWordEndForNamedVar()) {
					String varName = sql.substring(namedVarStartedIndex + 1,
							index + 1);
					varList.put(varName, null);
					isInNamedVar = false;
				} else if (IsBlank(c)) {
				} else if (c == '{') // { ....{
				{
					braceCount++;
				} else if (c == '}') {
					if (braceCount == 1)// {.....}
					{
						break;
					} else // { ...{ ....}
					{
						braceCount--;
					}
				}
			}
			index++;
		}

		if (index < length && sql.charAt(index) == '}') {
			String result = sql.substring(lastIndex, index);
			StringExpression sexp = new StringExpression(result);
			lastIndex = index + 1;
			index++;
			root.Append(sexp);
		} else {
			throw new RuntimeException("Syntax Error, Should end } char at "
					+ index);
		}
		return root;
	}

	private boolean IsEscapeChar() {
		if (index + 1 < length && sql.charAt(index + 1) == '\'') {
			return true;
		} else {
			return false;
		}
	}

	private void CheckLeftBrace(char c) {
		if (sql.charAt(index) != c) {
			throw new RuntimeException("Syntax Error, Should Start + [" + c
					+ "] char at " + index);
		}
	}

	private void CheckRightBrace(char c) {
		if (sql.charAt(index) != c) {
			throw new RuntimeException("Syntax Error, Should End + [" + c
					+ "] char at " + index);
		}
	}

	private Expression ParseToken(Token token) {
		if (token == Token.If) {
			return ParseIf();
		} else if (token == Token.And || token == Token.Or) {
			return ParseAndOrExp(token);
		} else if (token == Token.Where) {
			return ParseWhere();
		} else if (token == Token.In) {
			return ParseIn();
		}

		throw new RuntimeException("Not support token" + token);
	}

	private Expression ParseIn() {
		int braceCount = 0;

		SkipBlank();
		CheckLeftBrace('(');
		braceCount++;

		index++;
		lastIndex = index;
		InExpression root = new InExpression();
		String columnName = null;
		String propertyName = null;

		boolean isInNamedVar = false;
		int namedVarStartedIndex = 0;
		while (index < length) {
			char c = sql.charAt(index);
			if ((c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z') || c == '.'
					|| c == '_') {
				if (isInNamedVar == false) {
					isInNamedVar = true;
					namedVarStartedIndex = index;
				} else if (NextCharIsWordEndForNamedVar()) {
					String varName = sql.substring(namedVarStartedIndex,
							index + 1);
					if (columnName == null) {
						columnName = varName;
					} else if (propertyName == null) {
						propertyName = varName;
					} else {
						throw new RuntimeException(
								"Syntax Error. Invalid char in @in expression. @in expression : @in(columnName, propertyName)");
					}
					isInNamedVar = false;
				}
			} else if (IsBlank(c)) {
			} else if (c == ',') {
			} else if (c == ')') {
				break;
			} else {
				throw new RuntimeException(
						"Syntax Error. Invalid char in @in expression. @in expression : @in(columnName, propertyName)");
			}

			index++;
		}

		if (index < length && sql.charAt(index) == ')') {
			if (columnName == null || propertyName == null) {
				throw new RuntimeException(
						"Syntax Error. Invalid char in @in expression. @in expression : @in(columnName, propertyName)");
			}
			root.setColumnName(columnName);
			root.setPropertyName(propertyName);

			lastIndex = index + 1;
			index++;
		} else {
			throw new RuntimeException("Syntax Error, Should end } char at "
					+ index);
		}
		return root;
	}

	private void CheckEnd() {
		if (index >= length) {
			throw new RuntimeException("Syntax error");
		}
	}

	private void SkipBlank() {

		while (index < length) {
			char c = sql.charAt(index);
			if (IsBlank(c)) {
				index++;
				continue;
			}
			break;
		}
	}

	private static boolean IsBlank(char c) {
		return c == '\r' || c == '\n' || c == '\t' || c == ' ';
	}

	private Expression ParseWhere() {
		int braceCount = 0;
		SkipBlank();
		CheckEnd();
		CheckLeftBrace('{');
		braceCount++;
		index++;
		WhereExpression whereExp = new WhereExpression();

		while (index < length) {
			char c = sql.charAt(index);
			if (c == '@') {
				Token token = TryGetToken();
				if (token != Token.Unsupported) {
					lastIndex = index + token.toString().length() + 1;
					index = lastIndex;
					Expression tokenExp = ParseToken(token);
					whereExp.Append(tokenExp);
					index--; // compensate
				} else {
					throw new RuntimeException(
							"Syntax Error, In Or, And expression, @ must be follow a legal token.");
				}
			} else if (c == '}') {
				break;
			} else if (IsBlank(c)) {
			} else {
				throw new RuntimeException(
						"Syntax Error, In Or, error char at location: " + index);
			}
			index++;
		}

		if (sql.charAt(index) == '}') {
			index++;
			lastIndex = index;
		} else {
			CheckEnd();
			if (sql.charAt(index) != '}') {
				throw new RuntimeException(
						"Syntax Error, Should end } char at " + index);
			}
		}
		return whereExp;
	}

	private Expression ParseAndOrExp(Token rooToken) {
		int braceCount = 0;
		SkipBlank();
		CheckEnd();
		CheckLeftBrace('{');
		braceCount++;
		index++;
		Expression expression = null;
		if (rooToken == Token.And) {
			expression = new AndExpression();
		} else if (rooToken == Token.Or) {
			expression = new OrExpression();
		} else {
			throw new RuntimeException("Only And/ Or token are supported.");
		}

		while (index < length) {
			char c = sql.charAt(index);
			if (c == '@') {
				Token token = TryGetToken();
				if (token != Token.Unsupported) {
					lastIndex = index + token.toString().length() + 1;
					index = lastIndex;
					Expression tokenExp = ParseToken(token);
					expression.Append(tokenExp);
					index--; // compensate
				} else {
					throw new RuntimeException(
							"Syntax Error, In Or, And expression, @ must be follow a legal token.");
				}
			} else if (c == ',') {

			} else if (IsBlank(c)) {
			} else if (c == '{') // @or{ {} }
			{
				expression.Append(ParseLiteral());
				index--; // compensate
			} else if (sql.charAt(index) == '}') {
				break;
			} else {
				throw new RuntimeException(
						"Syntax Error, In Or, error char at location: " + index);
			}
			index++;
		}

		if (sql.charAt(index) == '}') {
			index++;
			lastIndex = index;
		} else {
			CheckEnd();
			if (sql.charAt(index) != '}') {
				throw new RuntimeException(
						"Syntax Error, Should end } char at " + index);
			}
		}
		return expression;
	}

	private Expression ParseIf() {
		IfExpression ifExpression = new IfExpression();
		ConditionalExpression firstIfExp = new ConditionalExpression();

		SkipBlank();
		CheckEnd();
		firstIfExp.setCondition(ParseCondition());
		SkipBlank();
		CheckLeftBrace('{');
		firstIfExp.setExpression(ParseLiteral());
		ifExpression.Append(firstIfExp);

		while (index < length) {
			char c = sql.charAt(index);
			if (c == '@') {
				Token token = TryGetToken();
				if (token != Token.Unsupported) {
					lastIndex = index + token.toString().length() + 1;
					index = lastIndex;
					if (token == Token.ElseIf) {
						ConditionalExpression condExpr = new ConditionalExpression();
						SkipBlank();
						CheckEnd();
						condExpr.setCondition(ParseCondition());
						SkipBlank();
						CheckLeftBrace('{');
						condExpr.setExpression(ParseLiteral());

						ifExpression.Append(condExpr);
					} else if (token == Token.Else) {
						SkipBlank();
						CheckEnd();
						CheckLeftBrace('{');
						Expression exp = ParseLiteral();
						ifExpression.setDefaultExp(exp);
					} else {
						throw new RuntimeException("Unsupported token " + token);
					}
					index--; // compensate
				} else {
					throw new RuntimeException(
							"Syntax Error, In expression, @ must be follow a legal token.");
				}
			} else if (IsBlank(c)) {
			} else {
				break;
			}
			index++;
		}

		return ifExpression;
	}

	private String ParseCondition() {
		String result = "";
		SkipBlank();
		CheckLeftBrace('(');
		int braceCount = 1;
		index++;
		lastIndex = index;
		boolean isQuota = false;
		boolean isEscaped = false;

		while (index < length) {
			char c = sql.charAt(index);
			if (c == '"')// "abc
			{
				if (isQuota == false) {
					isEscaped = false;
					isQuota = true;
				} else if (c == '\\') // "abc\"
				{
					isEscaped = true;
				} else if (isEscaped) // "abc\"
				{
					// conitinue
					isEscaped = false;
				} else if (NextCharIsWordEnd()) // "abc\""
				{
					isQuota = false;
				}

			} else if (isQuota == false) {
				if (c == '(') // ( ....(
				{
					braceCount++;
				} else if (c == ')') {
					if (braceCount == 1)// (.....)
					{
						break;
					} else // ( ...( ....(
					{
						braceCount--;
					}
				}
			}
			index++;
		}

		if (index < length && sql.charAt(index) == ')') {
			result = sql.substring(lastIndex, index);
			index++;
			lastIndex = index;
		} else {
			CheckEnd();
			CheckRightBrace(')');
		}
		return result;
	}

	private Token TryGetToken() {
		Token token = null;
		if (index + 2 < length)// @if, @or
		{
			if ((sql.charAt(index + 1) == 'i' || sql.charAt(index + 1) == 'I')
					&& (sql.charAt(index + 2) == 'f' || sql.charAt(index + 2) == 'F')) {
				token = Token.If;
				return token;
			}
			if ((sql.charAt(index + 1) == 'o' || sql.charAt(index + 1) == 'O')
					&& (sql.charAt(index + 2) == 'r' || sql.charAt(index + 2) == 'R')) {
				token = Token.Or;
				return token;
			}
		}

		if (index + 3 < length)// @and
		{
			if ((sql.charAt(index + 1) == 'a' || sql.charAt(index + 1) == 'A')
					&& (sql.charAt(index + 2) == 'n' || sql.charAt(index + 2) == 'N')
					&& (sql.charAt(index + 3) == 'd' || sql.charAt(index + 3) == 'D')) {
				token = Token.And;
				return token;
			}

		}
		if (index + 5 < length)// @where
		{
			if ("where".equals(sql.substring(index + 1, index + 1 + 5)
					.toLowerCase())) {
				token = Token.Where;
				return token;
			}
		}

		if (index + 6 < length)// @elseif
		{
			if ("elseif".equals(sql.substring(index + 1, index + 1 + 6)
					.toLowerCase())) {
				token = Token.ElseIf;
				return token;
			}
		}

		if (index + 4 < length)// @else
		{
			if ("else".equals(sql.substring(index + 1, index + 1 + 4)
					.toLowerCase())) {
				token = Token.Else;
				return token;
			}
		}

		if (index + 2 < length)// @in
		{
			if ("in".equals(sql.substring(index + 1, index + 1 + 2)
					.toLowerCase())) {
				token = Token.In;
				return token;
			}
		}

		token = Token.Unsupported;
		return token;
	}

	private boolean NextCharIsWordEnd() {
		if (index < length - 1) {
			char c = sql.charAt(index + 1);
			if (c == '\r' || c == '\n' || c == '\t' || c == ' ' // must be in
					// quota status
					|| c == '}' // for }, must be in quota status, i.e. 'abcd'}
					|| c == ')' // for ), must be in quota status, i.e. 'abcd')
					|| c == '<' || c == '>' || c == '=') //
			{
				return true;
			}
			return false;
		}
		return true;
	}

	private boolean NextCharIsWordEndForNamedVar() {
		if (index < length - 1) {
			char c = sql.charAt(index + 1);
			if (c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z' || c == '_'
					|| c >= '0' && c <= '9' || c == '.') {
				return false;
			}
			return true;
		}
		return true;
	}

}
