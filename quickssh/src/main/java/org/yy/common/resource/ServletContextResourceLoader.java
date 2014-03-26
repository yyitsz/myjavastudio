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

import java.net.URL;

import javax.servlet.ServletContext;

import org.yy.common.util.LightCommonsException;


/**
 * @author GL
 * @since 2008-4-16 下午03:25:58
 */
public class ServletContextResourceLoader extends AbstractResourceLoader{
    private final ServletContext context;
    private final String prefix;
    public ServletContextResourceLoader(ServletContext context) {
        this(context,"");
    }

    public ServletContextResourceLoader(ServletContext context, String prefix) {
        super();
        this.context = context;
        if(prefix.length()>1 && !prefix.endsWith("/"))
        	prefix = prefix + "/";
        if(!prefix.startsWith("/"))
        	prefix = "/"+prefix;
        this.prefix = prefix;
    }

    //no java-doc
    public Resource getResource(String location) {
    	if(location.startsWith("/"))
    		location =location.substring(1);
    	try {
			URL url = context.getResource(prefix+location);
			if(url==null)
				return null;
			return new URLResource(url);
		} catch (Exception e) {
			throw new LightCommonsException("unable to get Url of "+prefix+location+" cause by:"+e.getMessage(),e);
		}
        
    }
}
