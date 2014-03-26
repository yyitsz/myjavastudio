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

final class LogProviderSLF4J extends AbstractLogProvider {
    public static final LogProvider INSTANCE = new LogProviderSLF4J();

    private LogProviderSLF4J() {
    }

    @Override
    public Log getLog(Class clazz) {
    	return new SLF4JLogger(org.slf4j.LoggerFactory.getLogger(clazz));
    }
    
    public Log getLog(final String name) {
        return new SLF4JLogger(org.slf4j.LoggerFactory.getLogger(name));
    }

    private static class SLF4JLogger implements Log {
        private final org.slf4j.Logger slf4jLogger;

        public SLF4JLogger(final org.slf4j.Logger slf4jLogger) {
            this.slf4jLogger = slf4jLogger;
        }

        public void error(final String message) {
            slf4jLogger.error(message);
        }

        public void warn(final String message) {
            slf4jLogger.warn(message);
        }

        public void info(final String message) {
            slf4jLogger.info(message);
        }

        public void debug(final String message) {
            slf4jLogger.debug(message);
        }

        public boolean isErrorEnabled() {
            return slf4jLogger.isErrorEnabled();
        }

        public boolean isWarnEnabled() {
            return slf4jLogger.isWarnEnabled();
        }

        public boolean isInfoEnabled() {
            return slf4jLogger.isInfoEnabled();
        }

        public boolean isDebugEnabled() {
            return slf4jLogger.isDebugEnabled();
        }

        public boolean isFatalEnabled() {
        	return slf4jLogger.isErrorEnabled();
        }

        public boolean isTraceEnabled() {
        	return slf4jLogger.isDebugEnabled();
        }

		public void debug(Object message) {
			slf4jLogger.debug(BasicLogFormatter.toMessage(message));
		}

		public void debug(Object message, Throwable throwable) {
			slf4jLogger.debug(BasicLogFormatter.toMessage(message, throwable));
		}

		public void error(Object message) {
			slf4jLogger.error(BasicLogFormatter.toMessage(message));
		}

		public void error(Object message, Throwable throwable) {
			slf4jLogger.error(BasicLogFormatter.toMessage(message, throwable));
		}

		public void fatal(Object message) {
			error(message);
		}

		public void fatal(Object message, Throwable throwable) {
			error(message, throwable);
		}

		public void info(Object message) {
			slf4jLogger.info(BasicLogFormatter.toMessage(message));
		}

		public void info(Object message, Throwable throwable) {
			slf4jLogger.info(BasicLogFormatter.toMessage(message));
		}

		public void trace(Object message) {
			slf4jLogger.debug(BasicLogFormatter.toTraceMessage(message));
		}

		public void trace(Object message, Throwable throwable) {
			slf4jLogger.debug(BasicLogFormatter.toTraceMessage(message, throwable));
		}

		public void warn(Object message) {
			slf4jLogger.warn(BasicLogFormatter.toMessage(message));
		}

		public void warn(Object message, Throwable throwable) {
			slf4jLogger.warn(BasicLogFormatter.toMessage(message,throwable));
		}
    }
}
