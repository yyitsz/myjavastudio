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
package org.yy.common.template;

import java.io.IOException;
import java.util.HashMap;
import java.util.Map;

import org.yy.common.resource.ResourceLoader;
import org.yy.common.util.StringUtils;

/**
 * @author gl
 * @since Jun 16, 2008
 */
public class MultiTemplateFactory extends AbstractTemplateFactory{
	private Map<String, TemplateFactory> factoryMap=new HashMap<String, TemplateFactory>();
	private TemplateFactory defaultEngine;
	
	@Override
	public Template compileSource(String name, String source) throws IOException {
		String ext = StringUtils.getFilenameExtension(name);
		TemplateFactory factory = get(ext);
		if(factory==null)
			throw new IllegalStateException("Unknow Template Engine for ["+name+"]");
		return factory.compile(name, source);
	}

	/**
	 * select factory for specified engine.
	 * 
	 * @param engine e.g. ctl
	 * @param factory e.g. new CommonTemplateFactory()
	 * 
	 */
	public void put(String engine,TemplateFactory factory){
		factoryMap.put(engine, factory);
		factory.setResourceLoader(getResourceLoader());
	}
	
	/**
	 * remove engine to support
	 * @param engine
	 */
	public void remove(String engine){
		factoryMap.remove(engine);
	}

	public TemplateFactory get(String engine){
		TemplateFactory ret= factoryMap.get(engine);
		if(ret==null)
			return defaultEngine;
		return ret;
	}
	
	public TemplateFactory getDefaultEngine() {
		return defaultEngine;
	}

	public void setDefaultEngine(TemplateFactory defaultEngine) {
		this.defaultEngine = defaultEngine;
	}

	@Override
	protected void initResourceLoader(ResourceLoader resourceLoader) {
		for(TemplateFactory factory : factoryMap.values()){
			factory.setResourceLoader(resourceLoader);
		}
	}

}
