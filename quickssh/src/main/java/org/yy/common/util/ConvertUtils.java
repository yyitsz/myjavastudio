package org.yy.common.util;

import java.lang.reflect.Method;
import java.lang.reflect.Modifier;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

/**
 * TODO: 使用NumberUtils的类型转换
 * @author GL
 */
public class ConvertUtils {

	private static Date safeParseDate(String format,String source){
		try {
			return new SimpleDateFormat(format).parse(source);
		} catch (ParseException e) {
			return null;
		}
	}
	 
	/**
	 * use current date.format time.format settings to parse String to Date.
	 * @param source
	 * @return
	 */
	public static Date dateOf(final String source){
		Date date = safeParseDate(CommonsGlobal.getDateFormat()+" hh:mm:ss", source);
		if(date == null)
			date = safeParseDate(CommonsGlobal.getDateFormat()+" hh:mm", source);
		if(date==null)
			date = safeParseDate(CommonsGlobal.getDateFormat(), source);
		if(date==null)
			date = safeParseDate("hh:mm:ss", source);
		if(date==null)
			date = safeParseDate("hh:mm", source);
		if(date==null)
			throw new LightCommonsException("can't parse '"+source+"' to Date, accepted date formats:'"+CommonsGlobal.getDateFormat()+"[ hh:mm[:ss]]','hh:mm[:ss]'");
		return date;
	}
	
	/**
	 * 
	 * @param value yyyy-MM-dd [hh:mm:ss.SSS][AM|PM]
	 * @return
	 */
    public static Date dateOfAny(final String value) {
    	if(value==null || value.trim().length()==0)
			return null;
        Calendar calendat = Calendar.getInstance();
        final String datePattern = "[0-9]{4}-([0-1]?[0-9])-(([0-3]?[0-9])|([3][0-1]))";
        final String timePattern = "(([0-1]?[0-9])|([2][0-3]))((:([0-5]){0,1}([0-9]){1}){1,2})";
        final String timesPattern = " ([0-1]?[0-9]){1}(((:([0-5]){0,1}([0-9]){1}){1,2}) (([AP]M)|([ap]m)))?";
        Pattern p = Pattern.compile(datePattern);
        Matcher m = p.matcher(value);
        m.find();
        final String date_String = m.group();
        if (date_String != null) {
            final String[] test = date_String.split("-");
            if (test.length == 3) {
                calendat.set(Calendar.YEAR, Integer.parseInt(test[0].trim()));
                calendat.set(Calendar.MONTH,
                        Integer.parseInt(test[1].trim()) - 1);
                calendat.set(Calendar.DAY_OF_MONTH, Integer.parseInt(test[2]
                        .trim()));
            }
        }

        if ((value.indexOf("pm") != -1)
                || (value.indexOf("PM") != -1)
                || (value.indexOf("am") != -1)
                || (value.indexOf("AM") != -1)) {
            p = Pattern.compile(timesPattern);
            m = p.matcher(value);
            m.find();
            String time_String = m.group();
            if (time_String != null) {
                final String apm = time_String.substring(time_String.trim()
                        .indexOf(" ") + 1);
                if (apm.trim().equalsIgnoreCase("pm")) {
                    time_String = time_String.trim().substring(0,
                            time_String.trim().indexOf(" "));
                    final String[] test = time_String.split(":");
                    if (test.length == 3) {
                        calendat.set(Calendar.HOUR_OF_DAY, Integer
                                .parseInt(test[0].trim()) + 12);
                        calendat.set(Calendar.MINUTE, Integer.parseInt(test[1]
                                .trim()));
                        calendat.set(Calendar.SECOND, Integer.parseInt(test[2]
                                .trim()));
                    }
                    if (test.length == 2) {
                        calendat.set(Calendar.HOUR_OF_DAY, Integer
                                .parseInt(test[0].trim()) + 12);
                        calendat.set(Calendar.MINUTE, Integer.parseInt(test[1]
                                .trim()));
                        calendat.set(Calendar.SECOND, 0);
                    }
                } else {
                    final String[] test = time_String.split(":");
                    calendat = setTime(calendat, test);
                }
            }
        } else {
            p = Pattern.compile(timePattern);
            m = p.matcher(value);
            final Boolean isFind = m.find();
            if (isFind == true) {
                final String time_String = m.group();
                if (time_String != null) {
                    final String[] test = time_String.split(":");
                    calendat = setTime(calendat, test);
                }
            } else {
                calendat.set(Calendar.HOUR_OF_DAY, 0);
                calendat.set(Calendar.MINUTE, 0);
                calendat.set(Calendar.SECOND, 0);
            }

        }
        return calendat.getTime();
    }

    
    private static Calendar setTime(final Calendar calendat, final String[] test) {
        if (test.length == 3) {
            calendat
                    .set(Calendar.HOUR_OF_DAY, Integer.parseInt(test[0].trim()));
            calendat.set(Calendar.MINUTE, Integer.parseInt(test[1].trim()));
            calendat.set(Calendar.SECOND, Integer.parseInt(test[2].trim()));
        }
        if (test.length == 2) {
            calendat
                    .set(Calendar.HOUR_OF_DAY, Integer.parseInt(test[0].trim()));
            calendat.set(Calendar.MINUTE, Integer.parseInt(test[1].trim()));
            calendat.set(Calendar.SECOND, 0);
        }
        return calendat;
    }

    /**
     * convert zh_CN to a locale Object
     *
     * @param localeString
     * @return
     */
    public static Locale localeOf(final String localeString) {
        if (localeString == null) {
            return Locale.getDefault();
        }
        final String[] vars = localeString.trim().split("_", 3);
        if (vars.length == 1) {
            return new Locale(vars[0]);
        } else if (vars.length == 2) {
            return new Locale(vars[0], vars[1]);
        } else if (vars.length == 3) {
            return new Locale(vars[0], vars[1], vars[2]);
        } else {
            return new Locale("");
        }
    }

    private static Map<Class<?>, Method> valueOfMethods=new HashMap<Class<?>, Method>();

    /**
     * Convert charSequece to targetClass
     * @param <T>
     * @param value
     * @param targetClass
     * @return
     */
    public static <T> T convert(CharSequence value,Class<T> targetClass){
    	if(value == null || targetClass.isAssignableFrom(value.getClass()))
			return (T) value;
    	Class<T> wrappedClass = ReflectionUtils.getPrimWrap(targetClass);
    	String strValue = value.toString();
    	if(Date.class.equals(wrappedClass)){
			try {
				if(strValue==null || strValue.trim().length()==0)
					return null;
				return (T) dateOf(strValue);
			} catch (Exception e) {
				throw new IllegalArgumentException("can not covert \""+strValue+"\" to "+wrappedClass);
			}
		}else if(Boolean.class.equals(wrappedClass)){
			return (T) booleanOf(strValue);
		}

    	if(Number.class.isAssignableFrom(wrappedClass)){
    		return (T) NumberUtils.parseNumber(strValue, wrappedClass);
    	}
    	
		Method valueOf= null;
		if(!valueOfMethods.containsKey(wrappedClass)){
			try {
				valueOf = wrappedClass.getMethod("valueOf", String.class);
				if(valueOf!=null && Modifier.isPublic(valueOf.getModifiers()) &&Modifier.isStatic(valueOf.getModifiers())){
					valueOfMethods.put(wrappedClass, valueOf);
				}else{
					valueOf = null;
					valueOfMethods.put(wrappedClass, null);
				}
			} catch (Throwable e1) {
			}
		}else{
			valueOf = valueOfMethods.get(wrappedClass);
		}
		if(valueOf!=null){
			try {
				Object ret = valueOf.invoke(null, strValue);
				if(ret!=null)
					return (T) ret;
			} catch (Throwable e) {
			}
		}
		String lower = strValue.toLowerCase();
		if("null".equals(lower) || "n/a".equals(lower) || "nil".equals(lower)){
			return null;
		}
		throw new UnsupportedOperationException("can not convert to "+targetClass);
    }
    
    public static Boolean booleanOf(String value){
    	String lower = value.toLowerCase();
    	if("true".equals(lower) || "on".equals(lower) || "yes".equals(lower) || "y".equals(lower)){
			return Boolean.TRUE;
		}else if("false".equals(lower) || "off".equals(lower) || "no".equals(lower) || "n".equals(lower)){
			return Boolean.FALSE;
		}else if("null".equals(lower) || "n/a".equals(lower) || "nil".equals(lower)){
			return null;
		}else{
			//TODO: 是否应该抛出异常？
			return Boolean.FALSE;
		}
    }

	public static <T> T convert(Object value, Class<T> toClass) {
		if(value == null || toClass.isAssignableFrom(value.getClass()))
			return (T) value;
		if(value instanceof CharSequence){
			return convert((CharSequence)value, toClass);
		}
		return null;
	}
	
	public static boolean isNull(String value){
		String lower = value.toLowerCase();
		return "null".equals(lower) || "n/a".equals(lower) || "nil".equals(lower);
	}
	
	public static String toString(Object model){
		if(model == null)
			return "null";
		if(model instanceof Enum){
			Enum e = (Enum) model;
			return e.name();
		}if(model instanceof Date){
			String ret = new SimpleDateFormat(CommonsGlobal.getValue(CommonsGlobal.DATE_FORMAT)).format((Date)model);
			return ret;
		}
		return model.toString();
	}
}
