package org.yy.common.util;

import java.nio.charset.Charset;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;
import java.util.Properties;

/**
 * the TestCase will help you understanding.
 * <pre>
 * 		Properties cn =I18nBundle.getBundle("message", "conf", "utf-8", Locale.CHINA);
		Properties tw = I18nBundle.getBundle("message", "conf", "utf-8", Locale.TAIWAN);
		Properties fr = I18nBundle.getBundle("message", "conf", "utf-8", Locale.FRENCH);
		assertEquals("中国名字",cn.getProperty("test.name") );
		assertEquals("中文名字",tw.getProperty("test.name") );
		assertEquals("English Name", fr.getProperty("test.name"));

 * </pre>
 * @see I18nBundleTest
 * @author GL
 * @since 2008-7-24
 */
public abstract class I18nBundle {
	private static Map<String,ExProperties> cachedProperties=new HashMap<String, ExProperties>();
	private static Map<String,Properties> cachedBundle=new HashMap<String, Properties>();
	public static Properties getBundle(String resource) {
		return getBundle(resource,"conf",Charset.defaultCharset().name(),Locale.getDefault());
	}
	
	public static Properties getBundle(String resource,String extention) {
		return getBundle(resource,extention,Charset.defaultCharset().name(),Locale.getDefault());
	}
	
	public static Properties getBundle(String resource,String extention,String encoding) {
		return getBundle(resource,extention,encoding,Locale.getDefault());
	}

	public static Properties getBundle(String path,String extention,String encoding,Locale locale) {
		String bundleName = path+"_"+locale.getLanguage()+"_"+locale.getCountry()+"."+extention+":"+encoding;
		if(!cachedBundle.containsKey(bundleName)){
			Properties prop = new Properties();
			putToProp(prop,path+"."+extention, encoding);
			putToProp(prop,path+"_"+locale.getLanguage()+"."+extention, encoding);
			putToProp(prop,path+"_"+locale.getLanguage()+"_"+locale.getCountry()+"."+extention, encoding);
			cachedBundle.put(bundleName, prop);
		}
		return cachedBundle.get(bundleName);
	}
	
	private static void putToProp(Properties prop,String path,String encoding){
		Properties p = getExProperties(path, encoding);
		if(p!=null)
			prop.putAll(p);
	}
	
	private static ExProperties getExProperties(String path,String encoding){
		if(!cachedProperties.containsKey(path)){
			try{
				ExProperties prop = ExProperties.loadFromClassPath(path, encoding);
				cachedProperties.put(path, prop);
			}catch(LightCommonsException e){
			}
		}
		return cachedProperties.get(path);
	}
}
