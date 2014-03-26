package org.yy.base.dao.dynamic2;

public class ConditionalExpression extends Expression {
	private String condition;

	public Expression getExpression() {
		if (lists.size() > 0) {
			return lists.get(0);
		} else {
			return null;
		}
	}

	public String getCondition() {
		return condition;
	}

	public void setCondition(String condition) {
		this.condition = condition;
	}

	public void setExpression(Expression value) {
		if (lists.size() > 0) {
			lists.set(0, value);
		} else {
			lists.add(value);
		}
	}

	public String Eval(ExpressionContext ctx) {
		if (Eval(ctx, condition)) {
			return getExpression().Eval(ctx);
		}
		return null;
	}

	private boolean Eval(ExpressionContext ctx, String condition) {
		Object o = ctx.GetValue(condition);
		if (o == null) {
			return false;
		}
		if (o.getClass() == Boolean.class) {
			return ((Boolean) o).booleanValue();
		}
		return false;
	}
}
