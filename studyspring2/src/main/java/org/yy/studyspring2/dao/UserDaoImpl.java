package org.yy.studyspring2.dao;

import java.util.List;

import javax.annotation.Resource;

import org.hibernate.SessionFactory;
import org.springframework.stereotype.Repository;
import org.yy.studyspring2.model.Contact;
import org.yy.studyspring2.model.User;

@Repository
public class UserDaoImpl implements UserDao {

	@Resource
	private SessionFactory sessionFactory;

	public void addUser(User user) {
		sessionFactory.getCurrentSession().save(user);

	}

	@SuppressWarnings("unchecked")
	public List<User> listUser() {

		return sessionFactory.getCurrentSession().createQuery("from User")
				.list();
	}

	@SuppressWarnings("unchecked")
	public User getUserByName(String userName) {

		List<User> users = sessionFactory.getCurrentSession().createQuery(
				"from User where userName=:userName").setParameter("userName",
				userName).list();

		if (users == null || users.size() == 0) {

			return null;
		}

		return users.get(0);

	}

	public void removeUser(Long id) {

		User user = (User) sessionFactory.getCurrentSession().load(
				Contact.class, id);
		if (user != null) {
			sessionFactory.getCurrentSession().delete(user);

		}
	}

}
