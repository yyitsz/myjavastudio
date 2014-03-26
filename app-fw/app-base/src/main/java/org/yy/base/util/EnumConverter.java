package org.yy.base.util;

import org.apache.commons.beanutils.Converter;

public class EnumConverter implements Converter {

	@SuppressWarnings("unchecked")
	public Object convert(Class type, Object value) {
	
		if(value == null || value.getClass() == type)
		{
			return value;
		}
		
		return Enum.valueOf(type, value.toString());
		
	}

}
