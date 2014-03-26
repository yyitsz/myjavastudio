/*
 * Copyright 2002-2008 the original author or authors.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

package org.yy.common.util;

import java.lang.annotation.Annotation;
import java.lang.reflect.Array;
import java.lang.reflect.Constructor;
import java.lang.reflect.Field;
import java.lang.reflect.InvocationTargetException;
import java.lang.reflect.Method;
import java.lang.reflect.Modifier;
import java.lang.reflect.ParameterizedType;
import java.lang.reflect.Type;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collection;
import java.util.HashMap;
import java.util.Iterator;
import java.util.LinkedHashMap;
import java.util.LinkedHashSet;
import java.util.List;
import java.util.Map;
import java.util.Set;
import java.util.Map.Entry;

/**
 * Simple utility class for working with the reflection API and handling
 * reflection exceptions.
 *
 * <p>Only intended for internal use.
 *
 * @author Juergen Hoeller
 * @author Rob Harrop
 * @author Rod Johnson
 * @author Costin Leau
 * @author Sam Brannen
 * @since 1.2.2
 */
public abstract class ReflectionUtils {

	/**
	 * Attempt to find a {@link Field field} on the supplied {@link Class} with
	 * the supplied <code>name</code> and {@link Class type}. Searches all
	 * superclasses up to {@link Object}.
	 * @param clazz the class to introspect
	 * @param name the name of the field
	 * @param type the type of the field
	 * @return the corresponding Field object, or <code>null</code> if not found
	 * @throws IllegalArgumentException if the class or field type is
	 * <code>null</code> or if the field name is <em>empty</em>
	 */
	public static Field findField(final Class clazz, final String name, final Class type) {
		Assert.notNull(clazz, "The 'class to introspect' supplied to findField() can not be null.");
		Assert.hasText(name, "The field name supplied to findField() can not be empty.");
		Assert.notNull(type, "The field type supplied to findField() can not be null.");
		Class searchType = clazz;
		while (!Object.class.equals(searchType) && searchType != null) {
			final Field[] fields = searchType.getDeclaredFields();
			for (int i = 0; i < fields.length; i++) {
				Field field = fields[i];
				if (name.equals(field.getName()) && type.equals(field.getType())) {
					return field;
				}
			}
			searchType = searchType.getSuperclass();
		}
		return null;
	}

	/**
	 * Set the field represented by the supplied {@link Field field object} on
	 * the specified {@link Object target object} to the specified
	 * <code>value</code>. In accordance with
	 * {@link Field#set(Object, Object)} semantics, the new value is
	 * automatically unwrapped if the underlying field has a primitive type.
	 * <p>Thrown exceptions are handled via a call to
	 * {@link #handleReflectionException(Exception)}.
	 * @param field the field to set
	 * @param target the target object on which to set the field
	 * @param value the value to set; may be <code>null</code>
	 */
	public static void setField(Field field, Object target, Object value) {
		try {
			field.set(target, value);
		}
		catch (IllegalAccessException ex) {
			handleReflectionException(ex);
			throw new IllegalStateException("Unexpected reflection exception - " + ex.getClass().getName() + ": " +
					ex.getMessage());
		}
	}

	/**
	 * Attempt to find a {@link Method} on the supplied class with the supplied name
	 * and no parameters. Searches all superclasses up to <code>Object</code>.
	 * <p>Returns <code>null</code> if no {@link Method} can be found.
	 * @param clazz the class to introspect
	 * @param name the name of the method
	 * @return the Method object, or <code>null</code> if none found
	 */
	public static Method findMethod(Class clazz, String name) {
		return findMethod(clazz, name, new Class[0]);
	}

	/**
	 * Attempt to find a {@link Method} on the supplied class with the supplied name
	 * and parameter types. Searches all superclasses up to <code>Object</code>.
	 * <p>Returns <code>null</code> if no {@link Method} can be found.
	 * @param clazz the class to introspect
	 * @param name the name of the method
	 * @param paramTypes the parameter types of the method
	 * @return the Method object, or <code>null</code> if none found
	 */
	public static Method findMethod(Class clazz, String name, Class[] paramTypes) {
		Assert.notNull(clazz, "Class must not be null");
		Assert.notNull(name, "Method name must not be null");
		Class searchType = clazz;
		while (!Object.class.equals(searchType) && searchType != null) {
			Method[] methods = (searchType.isInterface() ? searchType.getMethods() : searchType.getDeclaredMethods());
			for (int i = 0; i < methods.length; i++) {
				Method method = methods[i];
				if (name.equals(method.getName()) && Arrays.equals(paramTypes, method.getParameterTypes())) {
					return method;
				}
			}
			searchType = searchType.getSuperclass();
		}
		return null;
	}

	public static Method findMethod(Class<?> clazz,String name,int params){
		for(Method m : clazz.getMethods()){
			if(m.getName().equals(name) && m.getParameterTypes().length==params){
				return m;
			}
		}
		return null;
	}
	/**
	 * Invoke the specified {@link Method} against the supplied target object
	 * with no arguments. The target object can be <code>null</code> when
	 * invoking a static {@link Method}.
	 * <p>Thrown exceptions are handled via a call to {@link #handleReflectionException}.
	 * @param method the method to invoke
	 * @param target the target object to invoke the method on
	 * @return the invocation result, if any
	 * @see #invokeMethod(java.lang.reflect.Method, Object, Object[])
	 */
	public static Object invokeMethod(Method method, Object target) {
		return invokeMethod(method, target, null);
	}

	/**
	 * Invoke the specified {@link Method} against the supplied target object
	 * with the supplied arguments. The target object can be <code>null</code>
	 * when invoking a static {@link Method}.
	 * <p>Thrown exceptions are handled via a call to {@link #handleReflectionException}.
	 * @param method the method to invoke
	 * @param target the target object to invoke the method on
	 * @param args the invocation arguments (may be <code>null</code>)
	 * @return the invocation result, if any
	 */
	public static Object invokeMethod(Method method, Object target, Object[] args) {
		try {
			return method.invoke(target, args);
		}
		catch (Exception ex) {
			handleReflectionException(ex);
		}
		throw new IllegalStateException("Should never get here");
	}

	/**
	 * Invoke the specified JDBC API {@link Method} against the supplied
	 * target object with no arguments.
	 * @param method the method to invoke
	 * @param target the target object to invoke the method on
	 * @return the invocation result, if any
	 * @throws SQLException the JDBC API SQLException to rethrow (if any)
	 * @see #invokeJdbcMethod(java.lang.reflect.Method, Object, Object[])
	 */
	public static Object invokeJdbcMethod(Method method, Object target) throws SQLException {
		return invokeJdbcMethod(method, target, null);
	}

	/**
	 * Invoke the specified JDBC API {@link Method} against the supplied
	 * target object with the supplied arguments.
	 * @param method the method to invoke
	 * @param target the target object to invoke the method on
	 * @param args the invocation arguments (may be <code>null</code>)
	 * @return the invocation result, if any
	 * @throws SQLException the JDBC API SQLException to rethrow (if any)
	 * @see #invokeMethod(java.lang.reflect.Method, Object, Object[])
	 */
	public static Object invokeJdbcMethod(Method method, Object target, Object[] args) throws SQLException {
		try {
			return method.invoke(target, args);
		}
		catch (IllegalAccessException ex) {
			handleReflectionException(ex);
		}
		catch (InvocationTargetException ex) {
			if (ex.getTargetException() instanceof SQLException) {
				throw (SQLException) ex.getTargetException();
			}
			handleInvocationTargetException(ex);
		}
		throw new IllegalStateException("Should never get here");
	}

	/**
	 * Handle the given reflection exception. Should only be called if
	 * no checked exception is expected to be thrown by the target method.
	 * <p>Throws the underlying RuntimeException or Error in case of an
	 * InvocationTargetException with such a root cause. Throws an
	 * IllegalStateException with an appropriate message else.
	 * @param ex the reflection exception to handle
	 */
	public static void handleReflectionException(Exception ex) {
		if (ex instanceof NoSuchMethodException) {
			throw new IllegalStateException("Method not found: " + ex.getMessage());
		}
		if (ex instanceof IllegalAccessException) {
			throw new IllegalStateException("Could not access method: " + ex.getMessage());
		}
		if (ex instanceof InvocationTargetException) {
			handleInvocationTargetException((InvocationTargetException) ex);
		}
		if (ex instanceof RuntimeException) {
			throw (RuntimeException) ex;
		}
		handleUnexpectedException(ex);
	}

	/**
	 * Handle the given invocation target exception. Should only be called if
	 * no checked exception is expected to be thrown by the target method.
	 * <p>Throws the underlying RuntimeException or Error in case of such
	 * a root cause. Throws an IllegalStateException else.
	 * @param ex the invocation target exception to handle
	 */
	public static void handleInvocationTargetException(InvocationTargetException ex) {
		rethrowRuntimeException(ex.getTargetException());
	}

	/**
	 * Rethrow the given {@link Throwable exception}, which is presumably the
	 * <em>target exception</em> of an {@link InvocationTargetException}.
	 * Should only be called if no checked exception is expected to be thrown by
	 * the target method.
	 * <p>Rethrows the underlying exception cast to an {@link RuntimeException}
	 * or {@link Error} if appropriate; otherwise, throws an
	 * {@link IllegalStateException}.
	 * @param ex the exception to rethrow
	 * @throws RuntimeException the rethrown exception
	 */
	public static void rethrowRuntimeException(Throwable ex) {
		if (ex instanceof RuntimeException) {
			throw (RuntimeException) ex;
		}
		if (ex instanceof Error) {
			throw (Error) ex;
		}
		handleUnexpectedException(ex);
	}

	/**
	 * Rethrow the given {@link Throwable exception}, which is presumably the
	 * <em>target exception</em> of an {@link InvocationTargetException}.
	 * Should only be called if no checked exception is expected to be thrown by
	 * the target method.
	 * <p>Rethrows the underlying exception cast to an {@link Exception} or
	 * {@link Error} if appropriate; otherwise, throws an
	 * {@link IllegalStateException}.
	 * @param ex the exception to rethrow
	 * @throws Exception the rethrown exception (in case of a checked exception)
	 */
	public static void rethrowException(Throwable ex) throws Exception {
		if (ex instanceof Exception) {
			throw (Exception) ex;
		}
		if (ex instanceof Error) {
			throw (Error) ex;
		}
		handleUnexpectedException(ex);
	}

	/**
	 * Throws an IllegalStateException with the given exception as root cause.
	 * @param ex the unexpected exception
	 */
	private static void handleUnexpectedException(Throwable ex) {
		// Needs to avoid the chained constructor for JDK 1.4 compatibility.
		IllegalStateException isex = new IllegalStateException("Unexpected exception thrown");
		isex.initCause(ex);
		throw isex;
	}

	/**
	 * Determine whether the given method explicitly declares the given exception
	 * or one of its superclasses, which means that an exception of that type
	 * can be propagated as-is within a reflective invocation.
	 * @param method the declaring method
	 * @param exceptionType the exception to throw
	 * @return <code>true</code> if the exception can be thrown as-is;
	 * <code>false</code> if it needs to be wrapped
	 */
	public static boolean declaresException(Method method, Class exceptionType) {
		Assert.notNull(method, "Method must not be null");
		Class[] declaredExceptions = method.getExceptionTypes();
		for (int i = 0; i < declaredExceptions.length; i++) {
			Class declaredException = declaredExceptions[i];
			if (declaredException.isAssignableFrom(exceptionType)) {
				return true;
			}
		}
		return false;
	}


	/**
	 * Determine whether the given field is a "public static final" constant.
	 * @param field the field to check
	 */
	public static boolean isPublicStaticFinal(Field field) {
		int modifiers = field.getModifiers();
		return (Modifier.isPublic(modifiers) && Modifier.isStatic(modifiers) && Modifier.isFinal(modifiers));
	}

	/**
	 * Make the given field accessible, explicitly setting it accessible if necessary.
	 * The <code>setAccessible(true)</code> method is only called when actually necessary,
	 * to avoid unnecessary conflicts with a JVM SecurityManager (if active).
	 * @param field the field to make accessible
	 * @see java.lang.reflect.Field#setAccessible
	 */
	public static void makeAccessible(Field field) {
		if (!Modifier.isPublic(field.getModifiers()) ||
				!Modifier.isPublic(field.getDeclaringClass().getModifiers())) {
			field.setAccessible(true);
		}
	}

	/**
	 * Make the given method accessible, explicitly setting it accessible if necessary.
	 * The <code>setAccessible(true)</code> method is only called when actually necessary,
	 * to avoid unnecessary conflicts with a JVM SecurityManager (if active).
	 * @param method the method to make accessible
	 * @see java.lang.reflect.Method#setAccessible
	 */
	public static void makeAccessible(Method method) {
		if (!Modifier.isPublic(method.getModifiers()) ||
				!Modifier.isPublic(method.getDeclaringClass().getModifiers())) {
			method.setAccessible(true);
		}
	}

	/**
	 * Make the given constructor accessible, explicitly setting it accessible if necessary.
	 * The <code>setAccessible(true)</code> method is only called when actually necessary,
	 * to avoid unnecessary conflicts with a JVM SecurityManager (if active).
	 * @param ctor the constructor to make accessible
	 * @see java.lang.reflect.Constructor#setAccessible
	 */
	public static void makeAccessible(Constructor ctor) {
		if (!Modifier.isPublic(ctor.getModifiers()) ||
				!Modifier.isPublic(ctor.getDeclaringClass().getModifiers())) {
			ctor.setAccessible(true);
		}
	}


	/**
	 * Perform the given callback operation on all matching methods of the
	 * given class and superclasses.
	 * <p>The same named method occurring on subclass and superclass will
	 * appear twice, unless excluded by a {@link MethodFilter}.
	 * @param targetClass class to start looking at
	 * @param mc the callback to invoke for each method
	 * @see #doWithMethods(Class, MethodCallback, MethodFilter)
	 */
	public static void doWithMethods(Class targetClass, MethodCallback mc) throws IllegalArgumentException {
		doWithMethods(targetClass, mc, null);
	}

	/**
	 * Perform the given callback operation on all matching methods of the
	 * given class and superclasses.
	 * <p>The same named method occurring on subclass and superclass will
	 * appear twice, unless excluded by the specified {@link MethodFilter}.
	 * @param targetClass class to start looking at
	 * @param mc the callback to invoke for each method
	 * @param mf the filter that determines the methods to apply the callback to
	 */
	public static void doWithMethods(Class targetClass, MethodCallback mc, MethodFilter mf)
			throws IllegalArgumentException {

		// Keep backing up the inheritance hierarchy.
		do {
			Method[] methods = targetClass.getDeclaredMethods();
			for (int i = 0; i < methods.length; i++) {
				if (mf != null && !mf.matches(methods[i])) {
					continue;
				}
				try {
					mc.doWith(methods[i]);
				}
				catch (IllegalAccessException ex) {
					throw new IllegalStateException(
							"Shouldn't be illegal to access method '" + methods[i].getName() + "': " + ex);
				}
			}
			targetClass = targetClass.getSuperclass();
		}
		while (targetClass != null);
	}

	/**
	 * Get all declared methods on the leaf class and all superclasses.
	 * Leaf class methods are included first.
	 */
	public static Method[] getAllDeclaredMethods(Class leafClass) throws IllegalArgumentException {
		final List list = new ArrayList(32);
		doWithMethods(leafClass, new MethodCallback() {
			public void doWith(Method method) {
				list.add(method);
			}
		});
		return (Method[]) list.toArray(new Method[list.size()]);
	}


	/**
	 * Invoke the given callback on all fields in the target class,
	 * going up the class hierarchy to get all declared fields.
	 * @param targetClass the target class to analyze
	 * @param fc the callback to invoke for each field
	 */
	public static void doWithFields(Class targetClass, FieldCallback fc) throws IllegalArgumentException {
		doWithFields(targetClass, fc, null);
	}

	/**
	 * Invoke the given callback on all fields in the target class,
	 * going up the class hierarchy to get all declared fields.
	 * @param targetClass the target class to analyze
	 * @param fc the callback to invoke for each field
	 * @param ff the filter that determines the fields to apply the callback to
	 */
	public static void doWithFields(Class targetClass, FieldCallback fc, FieldFilter ff)
			throws IllegalArgumentException {

		// Keep backing up the inheritance hierarchy.
		do {
			// Copy each field declared on this class unless it's static or file.
			Field[] fields = targetClass.getDeclaredFields();
			for (int i = 0; i < fields.length; i++) {
				// Skip static and final fields.
				if (ff != null && !ff.matches(fields[i])) {
					continue;
				}
				try {
					fc.doWith(fields[i]);
				}
				catch (IllegalAccessException ex) {
					throw new IllegalStateException(
							"Shouldn't be illegal to access field '" + fields[i].getName() + "': " + ex);
				}
			}
			targetClass = targetClass.getSuperclass();
		}
		while (targetClass != null && targetClass != Object.class);
	}

	/**
	 * Given the source object and the destination, which must be the same class
	 * or a subclass, copy all fields, including inherited fields. Designed to
	 * work on objects with public no-arg constructors.
	 * @throws IllegalArgumentException if the arguments are incompatible
	 */
	public static void shallowCopyFieldState(final Object src, final Object dest) throws IllegalArgumentException {
		if (src == null) {
			throw new IllegalArgumentException("Source for field copy cannot be null");
		}
		if (dest == null) {
			throw new IllegalArgumentException("Destination for field copy cannot be null");
		}
		if (!src.getClass().isAssignableFrom(dest.getClass())) {
			throw new IllegalArgumentException("Destination class [" + dest.getClass().getName() +
					"] must be same or subclass as source class [" + src.getClass().getName() + "]");
		}
		doWithFields(src.getClass(), new FieldCallback() {
			public void doWith(Field field) throws IllegalArgumentException, IllegalAccessException {
				makeAccessible(field);
				Object srcValue = field.get(src);
				field.set(dest, srcValue);
			}
		}, COPYABLE_FIELDS);
	}


	/**
	 * Action to take on each method.
	 */
	public static interface MethodCallback {

		/**
		 * Perform an operation using the given method.
		 * @param method the method to operate on
		 */
		void doWith(Method method) throws IllegalArgumentException, IllegalAccessException;
	}


	/**
	 * Callback optionally used to method fields to be operated on by a method callback.
	 */
	public static interface MethodFilter {

		/**
		 * Determine whether the given method matches.
		 * @param method the method to check
		 */
		boolean matches(Method method);
	}


	/**
	 * Callback interface invoked on each field in the hierarchy.
	 */
	public static interface FieldCallback {

		/**
		 * Perform an operation using the given field.
		 * @param field the field to operate on
		 */
		void doWith(Field field) throws IllegalArgumentException, IllegalAccessException;
	}


	/**
	 * Callback optionally used to filter fields to be operated on by a field callback.
	 */
	public static interface FieldFilter {

		/**
		 * Determine whether the given field matches.
		 * @param field the field to check
		 */
		boolean matches(Field field);
	}


	/**
	 * Pre-built FieldFilter that matches all non-static, non-final fields.
	 */
	public static FieldFilter COPYABLE_FIELDS = new FieldFilter() {
		public boolean matches(Field field) {
			return !(Modifier.isStatic(field.getModifiers()) ||
					Modifier.isFinal(field.getModifiers()));
		}
	};

    public static final int GETTER_OR_SETTER  = 0;
    public static final int GETTER_AND_SETTER = 3;
    public static final int GETTER            = 1;
    public static final int SETTER            = 2;

    public static Class getSuperGenericClass(final Class clazz) {
        final Type type = clazz.getGenericSuperclass();
        if (type instanceof ParameterizedType) {
            if (type != null) {
                final Type[] types = ((ParameterizedType) type)
                        .getActualTypeArguments();
                if (types != null) {
                    return (Class) types[0];
                }
            }
        }
        return Object.class;
    }

    public static Type[] getSuperGenericTypes(final Class clazz) {
        final ParameterizedType t = (ParameterizedType) clazz
                .getGenericSuperclass();
        if (t != null) {
            return t.getActualTypeArguments();
        }
        return null;
    }

    public static Type getGenericType(final Type type) {
        if (type instanceof ParameterizedType) {
            if (type != null) {
                final Type[] types = ((ParameterizedType) type)
                        .getActualTypeArguments();
                if (types != null) {
                    return types[0];
                }
            }
        }
        return Object.class;
    }

    public static Type[] getGenericTypes(final Type type) {
        if (type instanceof ParameterizedType) {
            if (type != null) {
                return ((ParameterizedType) type).getActualTypeArguments();
            }
        }
        return new Class[] { Object.class };
    }

    @SuppressWarnings("unchecked")
	public static<T> Class<T> getRawClass(final Type type) {
        if (type instanceof Class) {
            return (Class<T>) type;
        } else if (type instanceof ParameterizedType) {
            return (Class<T>) ((ParameterizedType) type).getRawType();
        }
        return null;
    }
    
    public static<T> Class<T> getParameterizedClass(final Type type,final int i){
    	if(type  instanceof ParameterizedType)
    		return getRawClass(((ParameterizedType)type).getActualTypeArguments()[i]);
    	return null;
    }
    
    /**
     * <pre>
     *   class Owner extends Middle<String>{
     *   }
     *   class Middle<A> extends Lookup<Long,A>{
     *   }
     *   ...
     *   getParameterizedTypes(Owner,Lookup) will return [Long,String]
     * </pre>
     * @param owner
     * @param lookup
     * @return
     */
    public static Type[] findParameterizedTypes(Class owner,Class lookup){
    	Class cls = owner;
		while (cls != null) {
			final Type superClass = cls.getGenericSuperclass();
			if (superClass == null) {
				break;
			}
			cls = ReflectionUtils.getRawClass(superClass);
			if (cls.equals(lookup)) {
				if (superClass instanceof ParameterizedType) {
					return ((ParameterizedType)superClass).getActualTypeArguments();
				}
				break;
			}
		}
		return null;
    }
    
    public static List<String> getFields(final Class entityClass) {
        return getFields(entityClass, GETTER_OR_SETTER);
    }

    public static List<String> getFields(final Class entityClass,
            final int getterOrSetter) {
        final List<String> list = new ArrayList<String>();
        for (final Entry<String, Method[]> e : getClassMap(entityClass)
                .entrySet()) {
            if ("class".equals(e.getKey())) {
                continue;
            }
            if (((getterOrSetter & GETTER) != 0) && (e.getValue()[0] == null)) {
                continue;
            }
            if (((getterOrSetter & SETTER) != 0) && (e.getValue()[1] == null)) {
                continue;
            }
            list.add(e.getKey());
        }
        return list;
    }

    protected static Map<Class, Map<String, Method[]>> invokeMap = new HashMap<Class, Map<String, Method[]>>(); // Class->field->[getter,setter]

    protected static Map<String, Method[]> getClassMap(final Class clazz) {
        Map<String, Method[]> map = invokeMap.get(clazz);
        if (map == null) {
            map = new LinkedHashMap<String, Method[]>();
            invokeMap.put(clazz, map);
            // === init fields
            for (final Method m : clazz.getMethods()) {
                final String name = m.getName();
                if ((m.getParameterTypes().length == 0)
                        && name.startsWith("get")) {
                    final String field = StringUtils.uncapitalize(name
                            .substring(3));
                    Method[] ms = map.get(field);
                    if (ms == null) {
                        ms = new Method[2];
                    }
                    ms[0] = m;
                    map.put(field, ms);
                } else if ((m.getParameterTypes().length == 0)
                        && (Boolean.class.equals(m.getReturnType()) || boolean.class
                                .equals(m.getReturnType()))
                        && name.startsWith("is")) {
                    final String field =StringUtils.uncapitalize(name
                            .substring(2));
                    Method[] ms = map.get(field);
                    if (ms == null) {
                        ms = new Method[2];
                    }
                    ms[0] = m;
                    map.put(field, ms);
                } else if ((m.getParameterTypes().length == 1)
                        && name.startsWith("set")) {
                    final String field = StringUtils.uncapitalize(name
                            .substring(3));
                    Method[] ms = map.get(field);
                    if (ms == null) {
                        ms = new Method[2];
                    }
                    ms[1] = m;
                    map.put(field, ms);
                }
            }
        }
        return map;
    }

    protected static Method[] getMethods(final Class clazz, final String field) {
        if ((field == null) || (field.length() == 0)) {
            return null;
        }
        Method[] m = getClassMap(clazz).get(field);
        if (m == null) {
            m = new Method[2];
            final String f = StringUtils.capitalize(field);
            try {
                m[0] = clazz.getMethod("get" + f);
            } catch (final Throwable e) {
            }
            try {
                if (m[0] == null) {
                    m[0] = clazz.getMethod("is" + f);
                }
            } catch (final Throwable e) {
            }
            if (m[0] != null) {
                try {
                    m[1] = clazz.getMethod("set" + f, m[0].getReturnType());
                } catch (final Throwable e) {
                }
            }
        }
        return m;
    }

    public static Type getComponentType(final Type type) {
        Class toClass = null;
        Type[] paramTypes = null;
        if (type instanceof Class) {
            toClass = (Class) type;
        } else if (type instanceof ParameterizedType) {
            toClass = (Class) ((ParameterizedType) type).getRawType();
            paramTypes = ((ParameterizedType) type).getActualTypeArguments();
        }
        if (Collection.class.isAssignableFrom(toClass)) {
            if ((paramTypes != null) && (paramTypes.length == 1)) {
                return paramTypes[0];
            }
        } else if (toClass.isArray()) {
            return toClass.getComponentType();
        } else if ((paramTypes != null) && (paramTypes.length == 1)) {
            return paramTypes[0];
        }
        return Object.class;
    }

    public static Class getFieldClass(final Type type, final String field) {
        return getRawClass(getFieldType(type, field));
    }

    public static Type getFieldType(final Type type, final String field) {
        Class toClass = null;
        Type[] paramTypes = null;
        if (type instanceof Class) {
            toClass = (Class) type;
        } else if (type instanceof ParameterizedType) {
            toClass = (Class) ((ParameterizedType) type).getRawType();
            paramTypes = ((ParameterizedType) type).getActualTypeArguments();
        } else {
            throw new RuntimeException("unknown class of:" + type);
        }

        if (Map.class.isAssignableFrom(toClass)) {
            if ((paramTypes != null) && (paramTypes.length == 2)) {
                return paramTypes[1];
            }
        }
        if (Collection.class.isAssignableFrom(toClass)) {
            return (paramTypes != null) && (paramTypes.length == 1) ? paramTypes[0]
                    : Object.class;
        }
        if (toClass.isArray()) {
            return toClass.getComponentType();
        }
        final Method getter = getGetter(toClass, field);
        if (getter != null) {
            return getter.getGenericReturnType();
        }
        final Method setter = getSetter(toClass, field);
        if (setter != null) {
            return setter.getGenericParameterTypes()[0];
        }
        return null;
    }

    public static Method getGetter(final Class clazz, final String field) {
        final Method[] ms = getMethods(clazz, field);
        return ms == null ? null : ms[0];
    }

    public static Method getSetter(final Class clazz, final String field) {
        final Method[] ms = getMethods(clazz, field);
        return ms == null ? null : ms[1];
    }

    public static List<Annotation> getAnnotations(final Class clazz) {
        final ArrayList<Annotation> list = new ArrayList<Annotation>();
        addAnnotations(clazz, list);
        return list;
    }

    private static void addAnnotations(final Class clazz,
            final List<Annotation> list) {
        if (clazz == null) {
            return;
        }
        for (final Annotation a : clazz.getAnnotations()) {
            if (!list.contains(a)) {
                list.add(a);
            }
        }
        addAnnotations(clazz.getSuperclass(), list);
    }

    /**
     * return the annotations on the field or the getter
     *
     * @param clazz
     * @param field
     * @return
     */
    public static List<Annotation> getAnnotations(final Class clazz,
            final String field) {
        final ArrayList<Annotation> as = new ArrayList<Annotation>();
        try {
            final Field f = clazz.getField(field);
            addTo(as, f.getAnnotations());
        } catch (final Throwable e) {
        }
        Method m = getGetter(clazz, field);
        if (m != null) {
            addTo(as, m.getAnnotations());
        }
        m = getSetter(clazz, field);
        if (m != null) {
            addTo(as, m.getAnnotations());
        }
        return as;
    }

    public static <T> T[] addAll(final T[]... arrays) {
        int len = 0;
        Class<?> comType = null;
        for (final T[] a : arrays) {
            if (a != null) {
                len += a.length;
                if (comType == null) {
                    comType = a.getClass().getComponentType();
                }
            }
        }

        final T[] t = (T[]) Array.newInstance(comType, len);
        int i = 0;
        for (final T[] a : arrays) {
            if (a != null) {
                for (final T com : a) {
                    t[i] = com;
                    i++;
                }
            }
        }
        return t;
    }

    public static Object get(final Object root, final String field) {
        if (root == null) {
            return null;
        }
        if (root instanceof Map) {
            return ((Map) root).get(field);
        } else if (root instanceof List) {
            final int index = Integer.valueOf(field);
            final List list = (List) root;
            if ((index >= list.size()) || (index < 0)) {
                return null;
            } else {
                return list.get(index);
            }
        } else if (root instanceof Set) {
            final int index = Integer.valueOf(field);
            if ((index < 0) || (index >= ((Set) root).size())) {
                return null;
            }
            Object ret = null;
            final Iterator si = ((Set) root).iterator();
            for (int i = 0; i <= index; i++) {
                ret = si.next();
            }
            return ret;
        }
        try {
            return getGetter(root.getClass(), field).invoke(root);
        } catch (final Throwable e) {
        }
        return null;
    }

    /**
     *
     * @param root
     * @param field
     * @param value
     * @return true: setted ; false: error to set
     */
    public static boolean set(final Object root, final String field,
            final Object value) {
        if (root == null) {
            return false;
        }
        if (root instanceof Map) {
            ((Map) root).put(field, value);
            return true;
        } else if (root instanceof List) {
            if (field.matches("\\d+")) {
                final int index = Integer.valueOf(field);
                final List list = (List) root;
                if (index >= list.size()) {
                    for (int i = list.size(); i < index; i++) {
                        list.add(null);
                    }
                    list.add(value);
                } else {
                    list.set(index, value);
                }
                return true;
            }
        }

//        if (("*".equals(field) || "[]".equals(field))
//                && (root instanceof Collection)) {
        if(root instanceof Collection){//any field name .!?
            final Collection set = (Collection) root;
            set.add(value);
            return true;
        }

        try {
            final Method m = getSetter(root.getClass(), field);
            m.invoke(root, value);
            return true;
        } catch (final Throwable e) {
            return false;
        }
    }

    @SuppressWarnings("unchecked")
    public static <T> T newInstance(final Class<T> clazz) {
        if (clazz.isInterface()) {
            // Register Default Implmentation for class,else ioc
            if (Map.class.equals(clazz)) {
                return (T) new LinkedHashMap();
            } else if (List.class.equals(clazz)) {
                return (T) new ArrayList();
            } else if (Set.class.equals(clazz)) {
                return (T) new LinkedHashSet();
            } else if (Collection.class.equals(clazz)) {
                return (T) new ArrayList();
            }
        }
        try {
            return clazz.newInstance();
        } catch (final InstantiationException e) {
            e.printStackTrace();
        } catch (final IllegalAccessException e) {
            e.printStackTrace();
        }
        return null;
    }

    public static Object newInstance(final Type type) {
        final Class<?> clazz = getRawClass(type);
        return newInstance(clazz);
    }

    /**
     * @param cls
     * @param field
     * @param name
     * @return
     */
    public static <A extends Annotation> A getAnnotation(final Class cls,
            final String field, final Class<A> annotationType) {
        A a = null;
        final Method getter = getGetter(cls, field);
        if (getter != null) {
            a = getter.getAnnotation(annotationType);
            if (a != null) {
                return a;
            }
        }
        final Method setter = getSetter(cls, field);
        if (setter != null) {
            a = setter.getAnnotation(annotationType);
            if (a != null) {
                return a;
            }
        }
        try {
            final Field f = cls.getField(field);
            if (f != null) {
                a = f.getAnnotation(annotationType);
            }
        } catch (final Throwable e) {
        }
        return a;
    }

    public static <T> void addTo(final List<T> list, final T[] array) {
        if (array != null) {
            for (final T t : array) {
                list.add(t);
            }
        }
    }

    public static Type wrapPrimType(final Type type) {
        if (type instanceof Class) {
            return getPrimWrap((Class) type);
        }
        return type;
    }

    @SuppressWarnings("unchecked")
	public static Class getPrimWrap(final Class primClazz) {
        if (!primClazz.isPrimitive()) {
            return primClazz;
        }
        if (boolean.class.equals(primClazz)) {
            return Boolean.class;
        }
        if (char.class.equals(primClazz)) {
            return Character.class;
        }
        if (int.class.equals(primClazz)) {
            return Integer.class;
        }
        if (long.class.equals(primClazz)) {
            return Long.class;
        }
        if (byte.class.equals(primClazz)) {
            return Byte.class;
        }
        if (short.class.equals(primClazz)) {
            return Short.class;
        }
        if (float.class.equals(primClazz)) {
            return Float.class;
        }
        if (double.class.equals(primClazz)) {
            return Double.class;
        }
        return primClazz;
    }
    
    public static boolean isCommonType(Class clazz){
    	return clazz.isPrimitive() || String.class.equals(clazz) || Number.class.isAssignableFrom(clazz) ||
    	Boolean.class.equals(clazz) || Character.class.equals(clazz) 
	    	|| clazz.getName().startsWith("java.lang.")
	    	|| clazz.getName().startsWith("java.util.") 
	    	|| clazz.getName().startsWith("java.sql.");
    }
    
}
