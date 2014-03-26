/**
 * Light-commons Project
 * http://light-commons.googlecode.com
 * Copyright (C) 2008 Jason Green
 * email: guileen@gmail.com
 *
 * License: Apache License 2.0 
 * (http://www.apache.org/licenses/LICENSE-2.0)
 *
 */
package org.yy.common.resource;

import java.net.MalformedURLException;
import java.net.URL;

import javax.servlet.ServletContext;

/**
 * 
 * TODO: 是否删除此类，貌似URLResource足矣
 * @author gl
 * @since Jun 30, 2008
 */
public class ServletContextResource extends URLResource{

	public ServletContextResource(ServletContext context,String path) {
		super(getUrl(context, path));
	}
	
	private static URL getUrl(ServletContext context,String path){
		try {
			return context.getResource(path);
		} catch (MalformedURLException e) {
			return null;
		}
	}
}
