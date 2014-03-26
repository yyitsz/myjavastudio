package org.yy.studyspring2.services.impl;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.yy.studyspring2.dao.DocumentDao;
import org.yy.studyspring2.model.Document;

@Service
@Transactional
public class DocumentServiceImpl implements DocumentService {
	@Resource
	private DocumentDao docDao;
	
	@Transactional(readOnly=true)
	public List<Document> getAll(){
		return docDao.getAll();
	}
	
	public Document get(Long id){
		return docDao.get(id);
	}
	
	public void save(Document doc){
		docDao.save(doc);
	}
	
	public void update(Document doc){
		docDao.update(doc);
	}
	
	public void delete(Long id){
		docDao.delete(id);
	}
	
	public void delete(Document doc){
		docDao.delete(doc);
	}
	
}
