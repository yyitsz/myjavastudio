package org.yy.base.dao.dynamic2;

public class LiteralExpression extends Expression {

	public String Eval(ExpressionContext ctx) {
		StringBuilder sb = new StringBuilder();
		for (Expression ex : lists) {
			sb.append(ex.Eval(ctx));
			sb.append(" ");
		}
		return sb.toString();
	}
}
