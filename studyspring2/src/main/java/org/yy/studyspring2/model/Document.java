package org.yy.studyspring2.model;

import java.sql.Blob;
import java.util.Date;

import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.Id;
import javax.persistence.Temporal;
import javax.persistence.TemporalType;

@Entity
public class Document {
	@Id
	@GeneratedValue
	private Long id;
	private String name;
	private String fileName;
	private String description;
	@javax.persistence.Lob
	private Blob content;
	private String contentType;
	
	@Temporal(TemporalType.TIME)
	private Date createdAt;
	
	
	public Long getId() {
		return id;
	}
	
	public String getContentType() {
		return contentType;
	}

	public void setContentType(String contentType) {
		this.contentType = contentType;
	}

	public void setId(Long id) {
		this.id = id;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public String getFileName() {
		return fileName;
	}
	public void setFileName(String fileName) {
		this.fileName = fileName;
	}
	public String getDescription() {
		return description;
	}
	public void setDescription(String description) {
		this.description = description;
	}
	public Blob getContent() {
		return content;
	}
	public void setContent(Blob content) {
		this.content = content;
	}
	public Date getCreatedAt() {
		return createdAt;
	}
	public void setCreatedAt(Date createdAt) {
		this.createdAt = createdAt;
	}

	@Override
	public String toString() {
		return "Document [id=" + id + ", name=" + name + ", fileName="
				+ fileName + ", description=" + description + ", contentType="
				+ contentType + ", createdAt=" + createdAt + "]";
	}

	
}
