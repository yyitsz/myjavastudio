package org.yy.studymybatis.dao.impl;

import java.util.List;

import org.apache.ibatis.session.SqlSession;
import org.apache.ibatis.session.SqlSessionFactory;
import org.yy.studymybatis.dao.TagDao;
import org.yy.studymybatis.mapper.TagMapper;
import org.yy.studymybatis.model.Tag;
import org.yy.studymybatis.util.MyBatisConnectionFactory;

public class TagDaoImpl implements TagDao  {
	private SqlSessionFactory sqlSessionFactory;

	public TagDaoImpl() {
		sqlSessionFactory = MyBatisConnectionFactory.getFactory();
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see org.yy.studymybatis.dao.impl.ContactDao#selectAll()
	 */

	public List<Tag> findAll() {
		SqlSession session = this.sqlSessionFactory.openSession();
		try {
			TagMapper mapper = session.getMapper(TagMapper.class);
			List<Tag> list = mapper.findAll();
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
	public Tag findById(int id) {

		SqlSession session = sqlSessionFactory.openSession();

		try {
			TagMapper mapper = session.getMapper(TagMapper.class);
			Tag tag = mapper.findById(id);
			return tag;
		} finally {
			session.close();
		}
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see
	 * org.yy.studymybatis.dao.impl.ContactDao#update(org.yy.studymybatis.model
	 * .Tag)
	 */
	public void update(Tag tag) {

		SqlSession session = sqlSessionFactory.openSession();

		try {
			TagMapper mapper = session.getMapper(TagMapper.class);
			mapper.update(tag);
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
	 * .Tag)
	 */
	public void insert(Tag tag) {

		SqlSession session = sqlSessionFactory.openSession();

		try {
			TagMapper mapper = session.getMapper(TagMapper.class);
			mapper.insert(tag);
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
			TagMapper mapper = session.getMapper(TagMapper.class);
			mapper.deleteById(id);
			session.commit();
		} finally {
			session.close();
		}
	}


	public void delete(Tag tag) {
		SqlSession session = sqlSessionFactory.openSession();

		try {
			TagMapper mapper = session.getMapper(TagMapper.class);
			mapper.delete(tag);
			session.commit();
		} finally {
			session.close();
		}
		
	}
}
