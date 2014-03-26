package org.yy.common.logger;

abstract class AbstractLogProvider implements LogProvider{
	public Log getLog(Class clazz) {
		return getLog(clazz.getName());
	}
}
