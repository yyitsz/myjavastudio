package org.yy.base.dao.dynamic2;

public class StringExpression extends Expression {
	String s;

	public StringExpression(String s) {
		this.s = s;
	}

	public String Eval(ExpressionContext ctx) {
		return s;
	}
}
