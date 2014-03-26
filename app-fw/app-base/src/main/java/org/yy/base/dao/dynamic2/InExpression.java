package org.yy.base.dao.dynamic2;

import java.util.Collection;

public class InExpression extends Expression {
	private String columnName;

	private String propertyName;

	public String getPropertyName() {
		return propertyName;
	}

	public void setPropertyName(String propertyName) {
		this.propertyName = propertyName;
	}

	public String getColumnName() {
		return columnName;
	}

	public void setColumnName(String columnName) {
		this.columnName = columnName;
	}

	public String Eval(ExpressionContext ctx) {
		Object o = ctx.GetValue(this.propertyName);
		StringBuilder sb = new StringBuilder();

		if (o != null && o.getClass() == Collection.class) {
			Collection<?> list = (Collection<?>) o;
			if (list.size() == 0) {
				return "";
			}
			int count = 0;
			for (Object var : list) {
				if (var != null) {
					if (var instanceof String || var instanceof Enum<?>) {
						String tmpString = var.toString();
						if ("".equals(tmpString)) {
							continue;
						}
						sb.append('\'');
						sb.append(tmpString.replace("'", "''"));
						sb.append('\'');
					} else if (var instanceof Number) {
						sb.append(var);
					} else {
						throw new RuntimeException(
								"Unsupported data type in @in expression.");
					}
					count++;
					if (count != list.size()) {
						sb.append(',');
					}

				}
			}

			if (sb.length() > 0) {
				sb.insert(0, " IN (");
				sb.insert(0, this.columnName);
				sb.append(")");
			}

		}
		return sb.toString();
	}

}
