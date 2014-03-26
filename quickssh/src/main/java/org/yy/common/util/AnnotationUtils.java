package org.yy.common.util;

import java.lang.annotation.Annotation;
import java.util.ArrayList;
import java.util.List;

public class AnnotationUtils {
	private AnnotationUtils(){}
	
	public static <A extends Annotation> List<Class<?>>  findClassAnnotatedWith(String basePackage,Class<A> annotationClass){
		List<Class<?>> clazzes = new ArrayList<Class<?>>();
		for(Class<?> clazz:PackageUtils.getClasses(basePackage)){
			if(AnnotationUtils.annotatedWith(clazz, annotationClass)){
				clazzes.add(clazz);
			}
		}
		return clazzes;
	}
	
	public static <A extends Annotation> boolean annotatedWith(Class<?> clazz,Class<A> annotationClass){
		return getAnnotation(clazz, annotationClass) != null;
	}
	
	public static <A extends Annotation> A getAnnotation(Class<?> clazz,Class<A> annotationClass){
		return clazz.getAnnotation(annotationClass);
	}
	
	public static <A extends Annotation> A getAnnotation(Class<?> clazz,Class<A> annotationClass,A defaultAnnotation){
		A annotation = clazz.getAnnotation(annotationClass);
		if(annotation == null)
			return defaultAnnotation;
		return annotation;
	}
}
