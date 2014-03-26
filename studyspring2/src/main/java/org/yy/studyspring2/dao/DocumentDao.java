package org.yy.studyspring2.dao;

import java.util.List;

import org.yy.studyspring2.model.Document;

public interface DocumentDao {

	@SuppressWarnings("unchecked")
	public List<Document> getAll();

	public Document get(long id);

	public void save(Document doc);

	public Document update(Document doc);

	public void delete(Long id);
	
	public void delete(Document doc);

}