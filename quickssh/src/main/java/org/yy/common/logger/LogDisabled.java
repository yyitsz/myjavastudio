/*
 * Elitemark lightweight Commons Project
 * http://www.elitemark.org/commons
 * Copyright (C) 2007 Jason Green
 *
 * License: Apache License 2.0
 * (http://www.apache.org/licenses/LICENSE-2.0)
 *
 */
package org.yy.common.logger;

final class LogDisabled implements Log {
    public static final LogDisabled INSTANCE = new LogDisabled();

	public void debug(Object obj) {
	}

	public void debug(Object obj, Throwable throwable) {
	}

	public void error(Object obj) {
	}

	public void error(Object obj, Throwable throwable) {
	}

	public void fatal(Object obj) {
	}

	public void fatal(Object obj, Throwable throwable) {
	}

	public void info(Object obj) {

	}

	public void info(Object obj, Throwable throwable) {

	}

	public boolean isDebugEnabled() {
		return false;
	}

	public boolean isErrorEnabled() {
		return false;
	}

	public boolean isFatalEnabled() {
		return false;
	}

	public boolean isInfoEnabled() {
		return false;
	}

	public boolean isTraceEnabled() {
		return false;
	}

	public boolean isWarnEnabled() {
		return false;
	}

	public void trace(Object obj) {

	}

	public void trace(Object obj, Throwable throwable) {

	}

	public void warn(Object obj) {

	}

	public void warn(Object obj, Throwable throwable) {

	}

}
