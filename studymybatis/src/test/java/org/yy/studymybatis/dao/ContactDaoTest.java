package org.yy.studymybatis.dao;

import junit.framework.Assert;

import org.junit.Test;
import org.yy.studymybatis.dao.impl.ContactDaoImpl;
import org.yy.studymybatis.model.Contact;

public class ContactDaoTest {
	@Test
	public void SelectData() {
		ContactDao dao = new ContactDaoImpl();
		Contact contact = dao.selectById(1);
		Assert.assertNotNull(contact);
		System.out.println(contact);
	}
	
	@Test
	public void InsertContact() {
		Contact c = new Contact();
		c.setEmail("SS@fsd.com");
		c.setName("SS");
		//c.setPhone("2232323");
		ContactDao dao = new ContactDaoImpl();
		 dao.insert(c);
		Assert.assertTrue(c.getId()> 0);
		System.out.println(c);
	}
	
	@Test
	public void UpdateContact() {
		ContactDao dao = new ContactDaoImpl();
		Contact contact = dao.selectById(1);
		Assert.assertNotNull(contact);
		System.out.println(contact);
		
		contact.setEmail("ABC@ABC.com");
		dao.update(contact);
		
		Contact contact2 = dao.selectById(1);
		Assert.assertNotNull(contact2);
		Assert.assertTrue("ABC@ABC.com".equals(contact2.getEmail()));
		System.out.println(contact2);
		
	}
}
