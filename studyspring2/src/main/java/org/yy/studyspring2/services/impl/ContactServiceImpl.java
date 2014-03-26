package org.yy.studyspring2.services.impl;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.yy.studyspring2.dao.ContactDao;
import org.yy.studyspring2.model.Contact;
import org.yy.studyspring2.services.ContactService;
@Service
public class ContactServiceImpl implements ContactService{

	@Resource
	private ContactDao contactDao;
	
	@Transactional
	public void addContact(Contact contact) {
		contactDao.addContact(contact);
		//我们实验
	}

	@Transactional
	public List<Contact> listContact() {
		
		return contactDao.listContact();
	}

	@Transactional
	public void removeContact(Integer id) {
		
		contactDao.removeContact(id);
	}

}
