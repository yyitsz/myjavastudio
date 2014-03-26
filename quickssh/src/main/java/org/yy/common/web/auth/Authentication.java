package org.yy.common.web.auth;



/**
 * one user one SecurityManager
 * @author <a href="mailto:gl@kindsoft.cn">桂健雄</a>
 * @since 2007-4-27
 */
public interface Authentication {
	/**
	 * get the Login user
	 * @return
	 */
	IUser getUser();
	
//	/**
//	 * 为目标设置代理.要对service和dao进行深层次的控制,必须对service对象和dao对象调用此方法
//	 * @param target Dao 或 Service 的实例
//	 * @return 经过proxy处理的对象
//	 */
//	Object proxy(Object target);

	/**
	 * 是否拥有某权限
	 * @param key 权限
	 * @return
	 */
	boolean has(String key);
	
	/**
	 * url是否可以访问
	 * @param servletPath
	 * @return
	 */
	boolean urlAccessible(String servletPath);
	
	/**
//	 * 方法是否可以访问
//	 * @param method 方法
//	 * @return
//	 */
//	boolean methodAccessible(Method method);
}
