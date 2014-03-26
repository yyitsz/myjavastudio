package org.yy.common.web.auth;

import javax.servlet.http.HttpSession;

import org.yy.common.web.auth.impl.AuthenticationImpl;

/**
 * 最常用的类
 * @author <a href="mailto:gl@kindsoft.cn">桂健雄</a>
 * @since 2007-4-28
 */
public class AuthManager {
	private static final String AUTHENTICATION_KEY = "LIGHT_COMMONS_AUTHENTICATION";
	private static ThreadLocal<HttpSession> localSession=new ThreadLocal<HttpSession>();
	
	private static AuthConfig authConfig;

	public static Authentication getAuthentication(){
		return (Authentication) getSession().getAttribute(AUTHENTICATION_KEY);
	}
	
	public static void login(IUser user){
		setAuthentication(new AuthenticationImpl(user));
	}
	
	public static void logout(){
		getSession().removeAttribute(AUTHENTICATION_KEY);
	}
	
	private static void setAuthentication(Authentication auth){
		getSession().setAttribute(AUTHENTICATION_KEY, auth);
	}
	
	public static IUser getUser(){
		if(getAuthentication()==null)
			return null;
		return getAuthentication().getUser();
	}
	
	public static boolean hasLogin(){
		return getUser()!=null;
	}

	public static AuthConfig getAuthConfig() {
		return authConfig;
	}

	protected static void init(AuthConfig authConfig) {
		AuthManager.authConfig = authConfig;
	}

	public static void setCurrentSession(HttpSession session){
		localSession.set(session);
	}
	
	/**
	 * 在request结束后，调用此方法，以保证session被释放
	 */
	protected static void cleanThread(){
		localSession.remove();
	}
	
	private static HttpSession getSession(){
		return localSession.get();
	}
	
	public static boolean has(String key){
		return getAuthentication()!=null && getAuthentication().has(key);
	}
}
