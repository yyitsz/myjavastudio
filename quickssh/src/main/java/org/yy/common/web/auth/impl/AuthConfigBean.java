package org.yy.common.web.auth.impl;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import org.yy.common.util.StringUtils;
import org.yy.common.web.auth.AuthConfig;
import org.yy.common.web.auth.Permission;

/**
 * @author <a href="mailto:gl@kindsoft.cn">桂健雄</a>
 * @since 2007-4-28
 */
public class AuthConfigBean implements AuthConfig {

	Map<String,Permission> permissionMap;

	String deniedPage;

	String loginPage;

	List<String> ignorePages;

	/**
	 * get the deniedPage
	 * 
	 * @return the deniedPage
	 */
	public String getDeniedPage() {
		return deniedPage;
	}

	/**
	 * set the deniedPage
	 * 
	 * @param deniedPage
	 *            the deniedPage to set
	 */
	public void setDeniedPage(String deniedPage) {
		if(deniedPage==null || deniedPage.trim().length()==0)
			return;
		if (deniedPage.startsWith("/")) {
			this.deniedPage = deniedPage;
		} else {
			this.deniedPage = "/" + deniedPage;
		}
		addIgnorePage(this.deniedPage);
	}

	public void addIgnorePage(String ignorePage){
		if(this.ignorePages == null)
			this.ignorePages = new ArrayList<String>();
		this.ignorePages.add(StringUtils.toRegxp(ignorePage));
	}
	
	/**
	 * get the ignorePages
	 * 
	 * @return the ignorePages
	 */
	public List<String> getIgnorePages() {
		return ignorePages;
	}

	/**
	 * set the ignorePages
	 * 
	 * @param ignorePages
	 *            the ignorePages to set
	 */
	public void setIgnorePages(List<String> ignorePages) {
		if(this.ignorePages == null)
			this.ignorePages = new ArrayList<String>();
		for (String p : ignorePages) {
			this.ignorePages.add(StringUtils.toRegxp(p));
		}
	}

	/**
	 * get the loginPage
	 * 
	 * @return the loginPage
	 */
	public String getLoginPage() {
		return loginPage;
	}

	/**
	 * set the loginPage
	 * 
	 * @param loginPage
	 *            the loginPage to set
	 */
	public void setLoginPage(String loginPage) {
		if(loginPage==null || loginPage.trim().length()==0)
			return;
		if (loginPage.startsWith("/")) {
			this.loginPage = loginPage;
		} else {
			this.loginPage = "/" + loginPage;
		}
		addIgnorePage(this.loginPage);
	}

	/**
	 * get the permissions
	 * 
	 * @return the permissions
	 */
	public Map<String,Permission> getPermissionMap() {
		return permissionMap;
	}

	/**
	 * set the permissionMap
	 * @param permissionMap the permissionMap to set
	 */
	public void setPermissionMap(Map<String, Permission> permissionMap) {
		this.permissionMap = permissionMap;
	}

	/* (non-Javadoc)
	 * @see kindsoft.auth.Configuration#isIgnore(java.lang.String)
	 */
	public boolean isIgnore(String servletPath) {
		for(String page : getIgnorePages()){
			if(servletPath.matches(page)){
				return true;
			}
		}
		return false;
	}
	
}
