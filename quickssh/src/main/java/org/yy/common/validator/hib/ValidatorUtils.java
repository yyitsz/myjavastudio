package org.yy.common.validator.hib;

import org.hibernate.validator.ClassValidator;
import org.hibernate.validator.InvalidValue;

public class ValidatorUtils {
	private ValidatorUtils(){}
	
	public static <T> InvalidValue[] validator(T bean){
		Class cls = bean.getClass();
		ClassValidator<T> validator = new ClassValidator<T>(cls,new MyMessageIntepolotate());
		
		return validator.getInvalidValues(bean);
	}
}
