package org.yy.base.dao.dynamic2;

public class WhereExpression extends Expression {

	public WhereExpression() {
	}

	public String Eval(ExpressionContext ctx) {
		if (this.lists.size() == 0) {
			return "";
		}

		StringBuilder sb = new StringBuilder();
		String result = this.lists.get(0).Eval(ctx);
		if (result != null && result.trim().length() > 0) {
			sb.append(" WHERE ");
			sb.append(result);
		}

		return sb.toString();
	}
}
