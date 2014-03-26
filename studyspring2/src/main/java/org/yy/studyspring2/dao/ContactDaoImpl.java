package org.yy.studyspring2.dao;

import java.util.List;

import javax.annotation.Resource;

import org.hibernate.SessionFactory;
import org.springframework.stereotype.Repository;
import org.yy.studyspring2.model.Contact;
@Repository
public class ContactDaoImpl implements ContactDao{

	@Resource
	private SessionFactory sessionFactory;
	
	public void addContact(Contact contact) {
		sessionFactory.getCurrentSession().save(contact);
		
	}

	@SuppressWarnings("unchecked")
	public List<Contact> listContact() {
		
		return sessionFactory.getCurrentSession().createQuery("from Contact").list();
	}


	public void removeContact(Integer id) {
		
		Contact contact = (Contact) sessionFactory.getCurrentSession().load(Contact.class, id);
		if(contact != null){
			sessionFactory.getCurrentSession().delete(contact);
			
		}
	}

}
