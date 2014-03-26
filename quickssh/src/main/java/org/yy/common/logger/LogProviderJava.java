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

final class LogProviderJava extends AbstractLogProvider {
    public static final LogProvider INSTANCE = new LogProviderJava();

    private LogProviderJava() {
    }
    
    public Log getLog(final String name) {
        return new JavaLogger(java.util.logging.Logger.getLogger(name));
    }

    private class JavaLogger implements Log {
        private final java.util.logging.Logger javaLogger;

        public JavaLogger(final java.util.logging.Logger javaLogger) {
            this.javaLogger = javaLogger;
        }

        public void error(final String message) {
            javaLogger.severe(message);
        }

        public void warn(final String message) {
            javaLogger.warning(message);
        }

        public void info(final String message) {
            javaLogger.info(message);
        }

        public void debug(final String message) {
            javaLogger.fine(message);
        }

        public boolean isErrorEnabled() {
            return javaLogger.isLoggable(java.util.logging.Level.SEVERE);
        }

        public boolean isWarnEnabled() {
            return javaLogger.isLoggable(java.util.logging.Level.WARNING);
        }

        public boolean isInfoEnabled() {
            return javaLogger.isLoggable(java.util.logging.Level.INFO);
        }

        public boolean isDebugEnabled() {
            return javaLogger.isLoggable(java.util.logging.Level.FINE);
        }

		public void debug(Object message) {
			javaLogger.fine(BasicLogFormatter.toTraceMessage(message));
		}

		public void debug(Object message, Throwable throwable) {
			javaLogger.fine(BasicLogFormatter.toTraceMessage(message, throwable));

		}

		public void error(Object message) {
			javaLogger.severe(BasicLogFormatter.toTraceMessage(message));
		}

		public void error(Object message, Throwable throwable) {
			javaLogger.severe(BasicLogFormatter.toTraceMessage(message, throwable));
		}

		public void fatal(Object message) {
			error(message);
		}

		public void fatal(Object message, Throwable throwable) {
			error(message, throwable);
		}

		public void info(Object message) {
			javaLogger.info(BasicLogFormatter.toMessage(message));
		}

		public void info(Object message, Throwable throwable) {
			javaLogger.info(BasicLogFormatter.toMessage(message, throwable));
		}

		public boolean isFatalEnabled() {
			return isErrorEnabled();
		}

		public boolean isTraceEnabled() {
			return isDebugEnabled();
		}

		public void trace(Object message) {
			javaLogger.fine(BasicLogFormatter.toTraceMessage(message));
		}

		public void trace(Object message, Throwable throwable) {
			javaLogger.fine(BasicLogFormatter.toTraceMessage(message, throwable));
		}

		public void warn(Object message) {
			javaLogger.warning(BasicLogFormatter.toMessage(message));
		}

		public void warn(Object message, Throwable throwable) {
			javaLogger.warning(BasicLogFormatter.toMessage(message, throwable));
		}
    }
}
