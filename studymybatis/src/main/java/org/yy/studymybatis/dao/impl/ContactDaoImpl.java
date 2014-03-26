package org.yy.studymybatis.dao.impl;

import java.util.List;

import org.apache.ibatis.session.SqlSession;
import org.apache.ibatis.session.SqlSessionFactory;
import org.yy.studymybatis.dao.ContactDao;
import org.yy.studymybatis.model.Contact;
import org.yy.studymybatis.util.MyBatisConnectionFactory;

public class ContactDaoImpl implements ContactDao {
	private SqlSessionFactory sqlSessionFactory;

	public ContactDaoImpl() {
		sqlSessionFactory = MyBatisConnectionFactory.getFactory();
	}

	/* (non-Javadoc)
	 * @see org.yy.studymybatis.dao.impl.ContactDao#selectAll()
	 */
	@SuppressWarnings("unchecked")
	public List<Contact> selectAll() {
		SqlSession session = this.sqlSessionFactory.openSession();
		try {
			List<Contact> list = session.selectList("org.yy.studymybatis.mapper.ContactMapper.selectAll");
			return list;
		} finally {
			session.close();
		}
	}

	 /* (non-Javadoc)
	 * @see org.yy.studymybatis.dao.impl.ContactDao#selectById(int)
	 */
	public Contact selectById(int id){
		 
	        SqlSession session = sqlSessionFactory.openSession();
	 
	        try {
	            Contact contact = (Contact) session.selectOne("org.yy.studymybatis.mapper.ContactMapper.selectById",id);
	            return contact;
	        } finally {
	            session.close();
	        }
	    }
	 
	    /* (non-Javadoc)
		 * @see org.yy.studymybatis.dao.impl.ContactDao#update(org.yy.studymybatis.model.Contact)
		 */
	    public void update(Contact contact){
	 
	        SqlSession session = sqlSessionFactory.openSession();
	 
	        try {
	            session.update("org.yy.studymybatis.mapper.ContactMapper.update", contact);
	            session.commit();
	        } finally {
	            session.close();
	        }
	    }
	 
	    /* (non-Javadoc)
		 * @see org.yy.studymybatis.dao.impl.ContactDao#insert(org.yy.studymybatis.model.Contact)
		 */
	    public void insert(Contact contact){
	 
	        SqlSession session = sqlSessionFactory.openSession();
	 
	        try {
	            session.insert("org.yy.studymybatis.mapper.ContactMapper.insert", contact);
	            session.commit();
	        } finally {
	            session.close();
	        }
	    }
	 
	    /* (non-Javadoc)
		 * @see org.yy.studymybatis.dao.impl.ContactDao#delete(int)
		 */
	    public void deleteById(int id){
	 
	        SqlSession session = sqlSessionFactory.openSession();
	 
	        try {
	            session.delete("org.yy.studymybatis.mapper.ContactMapper.deleteById", id);
	            session.commit();
	        } finally {
	            session.close();
	        }
	    }

		@Override
		public void delete(Contact contact) {
			  SqlSession session = sqlSessionFactory.openSession();
				 
		        try {
		            session.insert("org.yy.studymybatis.mapper.ContactMapper.delete", contact);
		            session.commit();
		        } finally {
		            session.close();
		        }
			
		}
}
