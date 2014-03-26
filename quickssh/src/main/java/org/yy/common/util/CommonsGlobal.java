package org.yy.common.util;

import java.util.Locale;

/**
 * 此类的设计目标是LightCommons的配置文件
 * @author GL
 * 
 */
public class CommonsGlobal {
	
	public static final String DATE_FORMAT = "date.format";
	public static final String TIME_FORMAT = "time.format";
	private static final String ENCODING = "UTF-8";
	private static String extention;
	private static String path;
	private static ThreadLocal<Locale> threadLocal = new ThreadLocal<Locale>(){
		@Override
		protected Locale initialValue() {
			return Locale.getDefault();
		}
	};
	
	static{
		load("light_commons.conf");
	}
	
	/**
	 * 加载classpath中的配置文件
	 * @param resourceName
	 */
	public static void load(String resourceName){
		//TODO: 在现有配置之上加载额外配置文件，给用户修改配置的机会
		Assert.hasText(resourceName, "resourceName is required for init CommonsGlobal");
		extention = StringUtils.getFilenameExtension(resourceName);
		int sepIndex = resourceName.lastIndexOf(".");
		path = sepIndex != -1 ? resourceName.substring(0,sepIndex) : resourceName ;
	}
	
	public static String getValue(String key){
		return I18nBundle.getBundle(path, extention, ENCODING, getLocale()).getProperty(key);
	}
	
	public static String getDateFormat(){
		return getValue(DATE_FORMAT);
	}
	
	public static String getTimeFormat(){
		return getValue(TIME_FORMAT);
	}
	
	public static void setLocale(Locale locale){
		threadLocal.set(locale);
	}
	
	public static Locale getLocale(){
		return threadLocal.get();
	}
}
