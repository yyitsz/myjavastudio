package org.yy.common.web.auth.impl;

import java.util.Collection;
import java.util.HashMap;
import java.util.Map;

import org.yy.common.web.auth.AuthManager;
import org.yy.common.web.auth.Authentication;
import org.yy.common.web.auth.IUser;
import org.yy.common.web.auth.Permission;


/**
 * @author <a href="mailto:gl@kindsoft.cn">桂健雄</a>
 * @since 2007-4-27
 */
public class AuthenticationImpl implements Authentication {

	final IUser user;
	
	final Map<String, Permission> permissionMap;

	final boolean superUser;
	
	public AuthenticationImpl(IUser user) {
		super();
		this.user = user;
		this.permissionMap = new HashMap<String, Permission>();
		this.superUser = user.isSuperUser();
		
		Map<String,Permission> allpm = null;
		if(AuthManager.getAuthConfig() != null)
			allpm=AuthManager.getAuthConfig().getPermissionMap();
		Collection<String> keys = user.getPermissionKeys();
		if(keys!=null){
			for(String key : keys){
				this.permissionMap.put(key, allpm==null ? null : allpm.get(key));
			}
		}
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see kindsoft.auth.SecurityManager#accessible(java.lang.String)
	 */
	public boolean has(String key) {
		return superUser || permissionMap.containsKey(key);
	}

	/**
	 * get the user
	 * 
	 * @return the user
	 */
	public IUser getUser() {
		return user;
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see kindsoft.auth.SecurityManager#urlAccessible(java.lang.String)
	 */
	public boolean urlAccessible(String servletPath) {
		if(superUser)
			return true;
		for (Permission permission : permissionMap.values()) {
			if(permission == null || permission.getUrls() == null){
				continue;
			}
			for (String url : permission.getUrls()) {
				if (servletPath.matches(url))
					return true;
			}
		}
		
		return false;
	}

}
