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

final class LogProviderJCL extends AbstractLogProvider {
    public static final LogProvider INSTANCE = new LogProviderJCL();

    private LogProviderJCL() {
    }

    @Override
    public Log getLog(Class clazz) {
    	return new JCLLogger(org.apache.commons.logging.LogFactory.getLog(clazz));
    }
    
    public Log getLog(final String name) {
        return new JCLLogger(org.apache.commons.logging.LogFactory.getLog(name));
    }

    private static class JCLLogger implements Log {
        private final org.apache.commons.logging.Log jclLog;

        public JCLLogger(final org.apache.commons.logging.Log jclLog) {
            this.jclLog = jclLog;
        }

		public void debug(Object obj) {
			jclLog.debug(obj);
		}

		public void debug(Object obj, Throwable throwable) {
			jclLog.debug(obj, throwable);
		}

		public void error(Object obj) {
			jclLog.error(obj);
		}

		public void error(Object obj, Throwable throwable) {
			jclLog.error(obj, throwable);
		}

		public void fatal(Object obj) {
			jclLog.fatal(obj);
		}

		public void fatal(Object obj, Throwable throwable) {
			jclLog.fatal(obj, throwable);
		}

		public void info(Object obj) {
			jclLog.info(obj);
		}

		public void info(Object obj, Throwable throwable) {
			jclLog.info(obj, throwable);
		}

		public boolean isDebugEnabled() {
			return jclLog.isDebugEnabled();
		}

		public boolean isErrorEnabled() {
			return jclLog.isErrorEnabled();
		}

		public boolean isFatalEnabled() {
			return jclLog.isFatalEnabled();
		}

		public boolean isInfoEnabled() {
			return jclLog.isInfoEnabled();
		}

		public boolean isTraceEnabled() {
			return jclLog.isTraceEnabled();
		}

		public boolean isWarnEnabled() {
			return jclLog.isWarnEnabled();
		}

		public void trace(Object obj) {
			jclLog.trace(obj);
		}

		public void trace(Object obj, Throwable throwable) {
			jclLog.trace(obj, throwable);
		}

		public void warn(Object obj) {
			jclLog.warn(obj);
		}

		public void warn(Object obj, Throwable throwable) {
			jclLog.warn(obj, throwable);
		}

    }
}
