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

import java.util.ArrayList;
import java.util.List;


/**
 * @author GL
 * @since 2008-4-16 下午03:29:01
 */
public class MultiResourceLoader extends AbstractResourceLoader{
    private final List<ResourceLoader> loaders;

    public MultiResourceLoader() {
        super();
        this.loaders = new ArrayList<ResourceLoader>();
    }

    public MultiResourceLoader(List<ResourceLoader> loaders) {
		super();
		this.loaders = loaders;
	}

    public void addLoader(ResourceLoader loader){
    	this.loaders.add(loader);
    }
	//no java-doc
    public Resource getResource(String location) {
        for(ResourceLoader loader : loaders){
            Resource r = loader.getResource(location);
            if(r!=null)
                return r;
        }
        return null;
    }
}
