package org.yy.studymybatis.dao;

import java.util.List;

import org.yy.studymybatis.model.Contact;

public interface ContactDao {

	public List<Contact> selectAll();

	public Contact selectById(int id);

	/**
	 * Updates an instance of Contact in the database.
	 * 
	 * @param contact
	 *            the instance to be updated.
	 */
	public void update(Contact contact);

	/**
	 * Insert an instance of Contact into the database.
	 * 
	 * @param contact
	 *            the instance to be persisted.
	 */
	public void insert(Contact contact);

	/**
	 * Delete an instance of Contact from the database.
	 * 
	 * @param id
	 *            primary key value of the instance to be deleted.
	 */
	public void deleteById(int id);
	
	public void delete(Contact contact);

}