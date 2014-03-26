package org.yy.obfuscation.service;

import org.springframework.transaction.annotation.Transactional;
import org.yy.obfuscation.model.Profile;
import org.yy.obfuscation.model.User;

public interface UserService {

	@Transactional
	public void saveUser(User user);

	@Transactional
	public void deleteUser(User user);

	@Transactional
	public void saveProfile(Profile profile);

	@Transactional
	public void deleteProfile(Profile profile);

}