package org.yy.studymybatis.dao.impl;

import java.util.List;

import org.apache.ibatis.session.SqlSession;
import org.apache.ibatis.session.SqlSessionFactory;
import org.yy.studymybatis.dao.ContactDao;
import org.yy.studymybatis.mapper.ContactMapper;
import org.yy.studymybatis.model.Contact;
import org.yy.studymybatis.util.MyBatisConnectionFactory;

public class ContactDaoImpl2 implements ContactDao {
	private SqlSessionFactory sqlSessionFactory;

	public ContactDaoImpl2() {
		sqlSessionFactory = MyBatisConnectionFactory.getFactory();
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see org.yy.studymybatis.dao.impl.ContactDao#selectAll()
	 */

	public List<Contact> selectAll() {
		SqlSession session = this.sqlSessionFactory.openSession();
		try {
			ContactMapper mapper = session.getMapper(ContactMapper.class);
			List<Contact> list = mapper.selectAll();
			return list;
		} finally {
			session.close();
		}
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see org.yy.studymybatis.dao.impl.ContactDao#selectById(int)
	 */
	public Contact selectById(int id) {

		SqlSession session = sqlSessionFactory.openSession();

		try {
			ContactMapper mapper = session.getMapper(ContactMapper.class);
			Contact contact = mapper.selectById(id);
			return contact;
		} finally {
			session.close();
		}
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * org.yy.studymybatis.dao.impl.ContactDao#update(org.yy.studymybatis.model
	 * .Contact)
	 */
	public void update(Contact contact) {

		SqlSession session = sqlSessionFactory.openSession();

		try {
			ContactMapper mapper = session.getMapper(ContactMapper.class);
			mapper.update(contact);
			session.commit();
		} finally {
			session.close();
		}
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * org.yy.studymybatis.dao.impl.ContactDao#insert(org.yy.studymybatis.model
	 * .Contact)
	 */
	public void insert(Contact contact) {

		SqlSession session = sqlSessionFactory.openSession();

		try {
			ContactMapper mapper = session.getMapper(ContactMapper.class);
			mapper.insert(contact);
			session.commit();
		} finally {
			session.close();
		}
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see org.yy.studymybatis.dao.impl.ContactDao#delete(int)
	 */
	public void deleteById(int id) {

		SqlSession session = sqlSessionFactory.openSession();

		try {
			ContactMapper mapper = session.getMapper(ContactMapper.class);
			mapper.deleteById(id);
			session.commit();
		} finally {
			session.close();
		}
	}

	@Override
	public void delete(Contact contact) {
		SqlSession session = sqlSessionFactory.openSession();

		try {
			ContactMapper mapper = session.getMapper(ContactMapper.class);
			mapper.delete(contact);
			session.commit();
		} finally {
			session.close();
		}
		
	}
}
