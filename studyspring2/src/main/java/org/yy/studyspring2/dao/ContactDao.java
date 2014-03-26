package org.yy.studyspring2.dao;

import java.util.List;

import org.yy.studyspring2.model.Contact;

public interface ContactDao {
	public void addContact(Contact contact);
	public List<Contact> listContact();
	public void removeContact(Integer id);
}
