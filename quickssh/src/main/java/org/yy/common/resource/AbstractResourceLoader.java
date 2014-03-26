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

import java.util.Locale;

/**
 * @author GL
 * @since 2008-4-16 下午03:29:57
 */
public abstract class AbstractResourceLoader implements ResourceLoader{

    public Resource getResource(String location, Locale locale) {
    	return getResource(new String[]{location+"_"+locale.toString(),location+"_"+locale.getLanguage(),location});
    }

    public Resource getResource(String[] locations) {
    	Resource resource;
    	for(String loc : locations){
    		resource = getResource(loc);
    		if(resource!=null)
    			return resource;
    	}
    	return null;
    }

}
