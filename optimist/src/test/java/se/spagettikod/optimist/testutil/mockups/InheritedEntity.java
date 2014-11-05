package se.spagettikod.optimist.testutil.mockups;

import se.spagettikod.optimist.OptimisticLocking;

@OptimisticLocking("inherited_entity")
public class InheritedEntity extends Entity {

	private String additionalValue;

	public String getAdditionalValue() {
		return additionalValue;
	}

	public void setAdditionalValue(String additionalValue) {
		this.additionalValue = additionalValue;
	}

}
