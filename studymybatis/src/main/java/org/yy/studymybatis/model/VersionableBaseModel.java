package org.yy.studymybatis.model;

public class VersionableBaseModel extends BaseModel{

	private Long version;
	private Long previousVersion;
	
	public Long getVersion() {
		return version;
	}

	public void setVersion(Long version) {
		this.version = version;
	}

	public Long getPreviousVersion() {
		return previousVersion;
	}

	public void setPreviousVersion(Long previousVersion) {
		this.previousVersion = previousVersion;
	}
	
	
	
}
