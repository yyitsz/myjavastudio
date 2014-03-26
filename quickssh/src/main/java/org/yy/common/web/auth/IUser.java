package org.yy.common.web.auth;

import java.util.Collection;
import java.util.Locale;
import java.util.TimeZone;



/**
 * @author <a href="mailto:gl@kindsoft.cn">桂健雄</a>
 * @since 2007-4-26
 */
public interface IUser {

	/**
	 * 获取一个用户所拥有的权限的key列表
	 * @return
	 */
	Collection<String> getPermissionKeys();
	
	/**
	 * 是否是超级用户
	 * @return
	 */
	boolean isSuperUser();

	/**
	 * 获取用户的界面语言
	 * @return
	 */
	Locale getLocale();
	
	/**
	 * 用户所在时区
	 * @return
	 */
	TimeZone getTimeZone();
}
