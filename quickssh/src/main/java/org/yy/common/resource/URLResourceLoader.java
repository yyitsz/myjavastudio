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

import java.net.MalformedURLException;


/**
 * @author GL
 * @since 2008-4-16 下午03:28:42
 */
public class URLResourceLoader extends AbstractResourceLoader{

    private final String prefix;

    /**
     * Construct an UrlResourceLoader using specified prefix.
     * <pre>
     *  UrlResourceLoader loader = new UrlResourceLoader("http://www.google.com/images");
     *  Resource res = loader.getResource("my.jpg");
     * </pre>
     * @param perfix e.g. http://www.google.com/images/
     */
    public URLResourceLoader(String prefix) {
        super();
        if(!prefix.endsWith("/"))
			prefix = prefix + "/";
		this.prefix = prefix;
    }

    public Resource getResource(String location) {
        try {
        	if(location.startsWith("/"))
        		location = location.substring(1);
            return new URLResource(prefix+location);
        } catch (MalformedURLException e) {
            e.printStackTrace();
        }
        return null;
    }
}
