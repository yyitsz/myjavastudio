using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace SqlParser
{
    public class InExpression : Expression
    {
        private string columnName;

        public string ColumnName
        {
            get { return columnName; }
            set { columnName = value; }
        }

        private string propertyName;

        public string PropertyName
        {
            get { return propertyName; }
            set { propertyName = value; }
        }



        public override string Eval(IExpressionContext ctx)
        {
            Object o = ctx.GetValue(this.propertyName);
            StringBuilder sb = new StringBuilder();

            if (o != null && o is ICollection)
            {
                   ICollection list = o as ICollection;
                   if (list.Count == 0)
                   {
                       return "";
                   }
                int count = 0;
                foreach (object var in list)
                {
                    if (var != null)
                    {
                        Type type = var.GetType();
                        if (type == typeof(String) || type.IsEnum)
                        {
                            string tmpString = Convert.ToString(var);
                            if (string.IsNullOrEmpty(tmpString))
                            {
                                continue;
                            }
                            sb.Append('\'');
                            sb.Append(tmpString.Replace("'","''"));
                            sb.Append('\'');
                        }
                        else if (type == typeof(Int16)
                            || type == typeof(Int32)
                            || type == typeof(Int64)
                            || type == typeof(UInt16)
                            || type == typeof(UInt32)
                            || type == typeof(UInt64))
                        {
                            sb.Append(var);
                        }
                        else
                        {
                            throw new Exception("Unsupported data type in @in expression.");
                        }
                        count++;
                        if (count != list.Count)
                        {
                            sb.Append(',');
                        }
                        
                    }
                }

                if (sb.Length > 0)
                { 
                    sb.Insert(0, " IN (");
                    sb.Insert(0, this.columnName);
                    sb.Append(")");
                }
               
            }
            return sb.ToString();
        }

      
    }
}
