package org.yy.common.web.auth;

import java.util.Map;


/**
 * @author <a href="mailto:gl@kindsoft.cn">桂健雄</a>
 * @since 2007-4-28
 */
public interface AuthConfig {
	Map<String,Permission> getPermissionMap();
	String getDeniedPage();
	String getLoginPage();
	boolean isIgnore(String servletPath);
}
