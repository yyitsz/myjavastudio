package org.yy.base.dao.dynamic2;

public class IfExpression extends Expression {

	private Expression defaultExp;

	public Expression getDefaultExp() {
		return defaultExp;
	}

	public void setDefaultExp(Expression defaultExp) {
		this.defaultExp = defaultExp;
	}

	public String Eval(ExpressionContext ctx) {
		if (lists.size() == 0) {
			return "";
		}

		String result = null;
		for (int i = 0; i < lists.size(); i++) {
			Expression ex = lists.get(i);
			result = ex.Eval(ctx);
			if (result != null) {
				break;
			}
		}
		if (result == null && defaultExp != null) {
			result = defaultExp.Eval(ctx);
		}
		if (result == null) {
			result = "";
		}
		return result;
	}
}
