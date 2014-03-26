package org.yy.studyspring2.services;

import java.util.List;

import org.yy.studyspring2.model.Contact;

public interface ContactService {
	public void addContact(Contact contact);
	public List<Contact> listContact();
	public void removeContact(Integer id);
}
