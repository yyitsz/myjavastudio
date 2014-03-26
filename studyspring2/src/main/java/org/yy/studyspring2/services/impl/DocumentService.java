package org.yy.studyspring2.services.impl;

import java.util.List;

import org.yy.studyspring2.model.Document;

public interface DocumentService {

	public List<Document> getAll();

	public Document get(Long id);

	public void save(Document doc);

	public void update(Document doc);

	public void delete(Long id);

	public void delete(Document doc);

}