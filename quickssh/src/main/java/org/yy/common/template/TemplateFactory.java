package org.yy.common.template;

import java.io.IOException;
import java.io.InputStream;
import java.util.Locale;

import org.yy.common.resource.Resource;
import org.yy.common.resource.ResourceLoader;

/**
 * @author gl
 * @since Jun 16, 2008
 */
public interface TemplateFactory {
	Template compile(String name,String source) throws IOException;

	Template getTemplate(String location,String encoding) throws Exception;
	
	Template getTemplate(String location,Locale local,String encoding) throws Exception;
	
	Template getTemplate(String name,InputStream inputStream, String encoding) throws IOException;

	Template getTemplate(Resource resource, String encoding) throws Exception;
	
	void setResourceLoader(ResourceLoader resourceLoader);
}
