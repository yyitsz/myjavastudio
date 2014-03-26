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

final class LogProviderLog4J extends AbstractLogProvider {
    public static final LogProvider INSTANCE = new LogProviderLog4J();

    private LogProviderLog4J() {
    }

    @Override
    public Log getLog(Class clazz) {
    	return new Log4JLogger(org.apache.log4j.Logger.getLogger(clazz));
    }
    
    public Log getLog(final String name) {
        return new Log4JLogger(org.apache.log4j.Logger.getLogger(name));
    }

    private static class Log4JLogger implements Log {
        private final org.apache.log4j.Logger log4JLogger;

        public Log4JLogger(final org.apache.log4j.Logger log4JLogger) {
            this.log4JLogger = log4JLogger;
        }

        public void error(final String message) {
            log4JLogger.error(message);
        }

        public void warn(final String message) {
            log4JLogger.warn(message);
        }

        public void info(final String message) {
            log4JLogger.info(message);
        }

        public void debug(final String message) {
            log4JLogger.debug(message);
        }

        public boolean isErrorEnabled() {
            return log4JLogger.isEnabledFor(org.apache.log4j.Level.ERROR);
        }

        public boolean isWarnEnabled() {
            return log4JLogger.isEnabledFor(org.apache.log4j.Level.WARN);
        }

        public boolean isInfoEnabled() {
            return log4JLogger.isEnabledFor(org.apache.log4j.Level.INFO);
        }

        public boolean isDebugEnabled() {
            return log4JLogger.isEnabledFor(org.apache.log4j.Level.DEBUG);
        }

        public boolean isFatalEnabled() {
        	return log4JLogger.isEnabledFor(org.apache.log4j.Level.FATAL);
        }

        public boolean isTraceEnabled() {
        	return isDebugEnabled();
        }

		public void debug(Object message) {
			log4JLogger.debug(message);

		}

		public void debug(Object message, Throwable throwable) {
			log4JLogger.debug(message, throwable);
		}

		public void error(Object message) {
			log4JLogger.error(message);
		}

		public void error(Object message, Throwable throwable) {
			log4JLogger.error(message, throwable);
		}

		public void fatal(Object message) {
			log4JLogger.fatal(message);
		}

		public void fatal(Object message, Throwable throwable) {
			log4JLogger.fatal(message, throwable);
		}

		public void info(Object message) {
			log4JLogger.info(message);
		}

		public void info(Object message, Throwable throwable) {
			log4JLogger.info(message, throwable);
		}

		public void trace(Object message) {
			log4JLogger.debug(message);
		}

		public void trace(Object message, Throwable throwable) {
			log4JLogger.debug(message, throwable);
		}

		public void warn(Object message) {
			log4JLogger.warn(message);
		}

		public void warn(Object message, Throwable throwable) {
			log4JLogger.warn(message, throwable);
		}

    }
}
