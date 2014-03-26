package org.yy.studyspring2.services.impl;

import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

import javax.annotation.Resource;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.dao.DataAccessException;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.authority.GrantedAuthorityImpl;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.yy.studyspring2.dao.UserDao;
import org.yy.studyspring2.model.User;

@Service
@Transactional(readOnly = true)
public class UserDetailsServiceImpl implements UserDetailsService {

	protected static Logger logger = LoggerFactory
			.getLogger(UserDetailsServiceImpl.class);
	@Resource
	private UserDao userDao;

	@Override
	public UserDetails loadUserByUsername(String username)
			throws UsernameNotFoundException, DataAccessException {

		UserDetails user = null;
		try {
			User dbUser = userDao.getUserByName(username);
			user = new org.springframework.security.core.userdetails.User(
					dbUser.getUserName(), dbUser.getPassword(), true, true,
					true, true, getAuthorities(dbUser.getAccess()));
		} catch (Exception ex) {
			logger.error("error in retrieving user.");
			throw new UsernameNotFoundException("Error in retrieing user");
		}
		return user;
	}

	private Collection<GrantedAuthority> getAuthorities(Integer access) {
		List<GrantedAuthority> authList = new ArrayList<GrantedAuthority>(2);
		authList.add(new GrantedAuthorityImpl("ROLE_USER"));
		if(((Integer)1).equals(access)){
			logger.debug("Grant ROLE_ADMIN to this user.");
			authList.add(new GrantedAuthorityImpl("ROLE_ADMIN"));
		}
		return authList;

	}

}
