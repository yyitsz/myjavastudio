package org.yy.studyspring2.dao;

import java.util.List;

import javax.annotation.Resource;

import org.hibernate.Session;
import org.hibernate.SessionFactory;
import org.springframework.stereotype.Repository;
import org.yy.studyspring2.model.Document;

@Repository
public class DocumentDaoImpl implements DocumentDao {
	@Resource
	private SessionFactory sessionFactory;

	@SuppressWarnings("unchecked")
	public List<Document> getAll() {
		return sessionFactory.getCurrentSession().createQuery("from Document")
				.list();

	}

	public Document get(long id) {
		return (Document) sessionFactory.getCurrentSession().get(
				Document.class, id);

	}

	public void save(Document doc) {
		sessionFactory.getCurrentSession().save(doc);

	}
	
	public Document update(Document doc) {
		return (Document) sessionFactory.getCurrentSession().merge(doc);

	}
	
	public void delete(Long id) {
		Session session = sessionFactory.getCurrentSession();
		Document doc = (Document) session.get(Document.class, id);
		session.delete(doc);

	}
	
	public void delete(Document doc) {
		Session session = sessionFactory.getCurrentSession();
		session.delete(doc);

	}
}
