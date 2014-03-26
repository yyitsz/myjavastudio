package org.yy.common.web.auth.impl;

import java.lang.reflect.Method;
import java.util.ArrayList;
import java.util.List;

import org.yy.common.util.StringUtils;
import org.yy.common.web.auth.Permission;


/**
 * @author <a href="mailto:gl@kindsoft.cn">桂健雄</a>
 * @since 2007-4-27
 */
public class PermissionBean implements Permission{
	String key;
	List<Method> methods;
	List<String> urls;
	/**
	 * get the key
	 * @return the key
	 */
	public String getKey() {
		return key;
	}
	/**
	 * set the key
	 * @param key the key to set
	 */
	public void setKey(String key) {
		this.key = key;
	}
	/**
	 * get the methods
	 * @return the methods
	 */
	public List<Method> getMethods() {
		return methods;
	}
	/**
	 * set the methods
	 * @param methods the methods to set
	 */
	public void setMethods(List<Method> methods) {
		this.methods = methods;
	}
	/**
	 * get the urls
	 * @return the urls
	 */
	public List<String> getUrls() {
		return urls;
	}
	/**
	 * set the urls
	 * @param urls the urls to set
	 */
	public void setUrls(List<String> urls) {
		if(this.urls==null)
			this.urls = new ArrayList<String>();
		
		for(String url:urls){
			this.urls.add(StringUtils.toRegxp(url));
		}
	}
}
