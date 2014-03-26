package org.yy.studymybatis.dao;

import junit.framework.Assert;

import org.apache.ibatis.exceptions.PersistenceException;
import org.junit.Test;
import org.yy.studymybatis.dao.impl.ContactDaoImpl;
import org.yy.studymybatis.dao.impl.ContactDaoImpl2;
import org.yy.studymybatis.extend.OptimisticLockException;
import org.yy.studymybatis.model.Contact;
import org.yy.studymybatis.util.Utils;

public class ContactDaoTest2 {
	@Test
	public void selectData() {
		ContactDao dao = new ContactDaoImpl2();
		Contact contact = dao.selectById(1);
		Assert.assertNotNull(contact);
		System.out.println(contact);
	}
	
	@Test
	public void insertContact() {
		Contact c = new Contact();
		c.setEmail("SS@fsd.com");
		c.setName("SS");
		c.setPhone("2232323");
		ContactDao dao = new ContactDaoImpl();
		 dao.insert(c);
		Assert.assertTrue(c.getId()> 0);
		System.out.println(c);
	}
	
	@Test
	public void updateContact() {
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
	
	@Test(expected=PersistenceException.class)
	public void updateContactWithException() {
		ContactDao dao = new ContactDaoImpl();
		Contact contact = dao.selectById(4);
		Contact oldContact =  Utils.deepCopy(contact);
		Assert.assertNotNull(contact);
		System.out.println(contact);
		
		contact.setEmail("ABC@ABC.com");
		dao.update(contact);
		
		Contact contact2 = dao.selectById(4);
		Assert.assertNotNull(contact2);
		Assert.assertTrue("ABC@ABC.com".equals(contact2.getEmail()));
		System.out.println(contact2);
		contact.setEmail("Any@ABC.com");
		dao.update(oldContact);
		
	}
	
	@Test(expected=PersistenceException.class)
	public void deleteContactWithException() {
		ContactDao dao = new ContactDaoImpl();
		Contact contact = dao.selectById(5);
		Contact oldContact =  Utils.deepCopy(contact);
		Assert.assertNotNull(contact);
		System.out.println(contact);
		
		contact.setEmail("ABC@ABC.com");
		dao.update(contact);
		
		Contact contact2 = dao.selectById(5);
		Assert.assertNotNull(contact2);
		Assert.assertTrue("ABC@ABC.com".equals(contact2.getEmail()));
		System.out.println(contact2);
		contact.setEmail("Any@ABC.com");
		dao.delete(oldContact);
		
	}
}
