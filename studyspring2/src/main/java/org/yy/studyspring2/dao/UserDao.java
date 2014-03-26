package org.yy.studyspring2.dao;

import java.util.List;

import org.yy.studyspring2.model.User;

public interface UserDao {
	public void addUser(User user);

	public List<User> listUser();

	public User getUserByName(String userName);

	public void removeUser(Long id);
}
