package se.spagettikod.optimist.testutil.mockups;

import se.spagettikod.optimist.Identity;
import se.spagettikod.optimist.OptimisticLocking;
import se.spagettikod.optimist.Version;

@OptimisticLocking("entity")
public class Entity {

	@Identity("id")
	private Long id;

	private String value;

	@Version("version")
	private Integer version;

	public Long getId() {
		return id;
	}

	public Integer getVersion() {
		return version;
	}

	public String getValue() {
		return value;
	}

	public void setValue(String value) {
		this.value = value;
	}

}
