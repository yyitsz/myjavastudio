/**
 * 2007-4-27 下午08:45:02
 */
package org.yy.common.web.auth;

import java.lang.reflect.Method;
import java.util.List;

/**
 * @author <a href="mailto:gl@kindsoft.cn">桂健雄</a>
 * @since 2007-4-27
 */
public interface Permission {

	/**
	 * get the key
	 * 
	 * @return the key
	 */
	public String getKey();

	/**
	 * get the methods
	 * 
	 * @return the methods
	 */
	public List<Method> getMethods();

	/**
	 * get the urls
	 * 
	 * @return the urls
	 */
	public List<String> getUrls();
}
