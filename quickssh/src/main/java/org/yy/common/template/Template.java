/**
 * 
 */
package org.yy.common.template;

import java.io.Writer;
import java.util.Locale;

/**
 * @author gl
 * @since Jun 15, 2008
 */
public interface Template {
	String render(Object rootMap);
	
	String render(Object rootMap,Locale locale);

	void render(Object rootMap, Writer writer);
	
	void render(Object rootMap, Writer writer,Locale locale);
}
