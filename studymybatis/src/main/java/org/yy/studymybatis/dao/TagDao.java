package org.yy.studymybatis.dao;

import java.util.List;

import org.yy.studymybatis.model.Tag;

public interface TagDao {

	public List<Tag> findAll();

	/*
	 * (non-Javadoc)
	 * 
	 * @see org.yy.studymybatis.dao.impl.ContactDao#selectById(int)
	 */
	public Tag findById(int id);

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * org.yy.studymybatis.dao.impl.ContactDao#update(org.yy.studymybatis.model
	 * .Tag)
	 */
	public void update(Tag tag);

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * org.yy.studymybatis.dao.impl.ContactDao#insert(org.yy.studymybatis.model
	 * .Tag)
	 */
	public void insert(Tag tag);

	/*
	 * (non-Javadoc)
	 * 
	 * @see org.yy.studymybatis.dao.impl.ContactDao#delete(int)
	 */
	public void deleteById(int id);

	public void delete(Tag tag);

}