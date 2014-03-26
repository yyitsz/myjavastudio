/* 
 * Elitemark lightweight Commons Project
 * http://www.elitemark.org/commons
 * Copyright (C) 2007 Jason Green
 * email: guileen@gmail.com
 *
 * License: Apache License 2.0 
 * (http://www.apache.org/licenses/LICENSE-2.0)
 *
 */
package org.yy.common.resource;

/**
 * @author GL
 * @since 2008-4-16 下午03:25:25
 */
public class ClassPathResourceLoader extends AbstractResourceLoader{

	private String prefix;
	
	public ClassPathResourceLoader() {
		this("");
	}
	
	public ClassPathResourceLoader(String prefix) {
		super();
		if(prefix.startsWith("/"))
			prefix = prefix.substring(1);
		if(!prefix.endsWith("/"))
			prefix = prefix + "/";
		this.prefix = prefix;
	}

	public Resource getResource(String location) {
		if(location.startsWith("/"))
			location = location.substring(1);
		return new ClassPathResource(prefix+location);
	}

}
