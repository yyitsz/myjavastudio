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

import java.io.IOException;
import java.io.Writer;

/**
 * Provides an implementation of the {@link Log} interface that sends output
 * to the specified <code>java.io.Writer</code>.
 * <p>
 * Each log entry is formatted using the
 * {@link BasicLogFormatter#format(String level, String message, String loggerName)}
 * method.
 * <p>
 * Note that each <a href="Logger.html#LoggingLevel">logging level</a> can be
 * enabled independently in this implementation.
 */
public class WriterLogger implements Log {
    private final Writer writer;
    private final String name;

    private boolean      errorEnabled = true;
    private boolean      warnEnabled  = true;
    private boolean      infoEnabled  = true;
    private boolean      debugEnabled = true;

    /**
     * Constructs a new <code>WriterLogger</code> with the specified
     * <code>Writer</code> and the default name.
     * <p>
     * The default logger name is "<code>net.htmlparser.jericho</code>".
     *
     * @param writer
     *            the <code>Writer</code> to which all output is sent.
     */
    // public WriterLogger(final Writer writer) {
    // this(writer,Source.PACKAGE_NAME);
    // }
    /**
     * Constructs a new <code>WriterLogger</code> with the specified
     * <code>Writer</code> and name.
     * <p>
     * The value of the <code>name</code> argument is only relevant if the
     * {@link BasicLogFormatter#OutputName} static property is set to
     * <code>true</code>, otherwise the name is not included in the output at
     * all.
     *
     * @param writer
     *            the <code>Writer</code> to which all output is sent.
     * @param name
     *            the logger name, may be <code>null</code>.
     */
    public WriterLogger(final Writer writer, final String name) {
        this.writer = writer;
        this.name = name;
    }

    /**
     * Returns the <code>Writer</code> to which all output is sent.
     *
     * @return the <code>Writer</code> to which all output is sent.
     */
    public Writer getWriter() {
        return writer;
    }

    /**
     * Returns the name of this logger.
     *
     * @return the name of this logger, may be <code>null</code>.
     */
    public String getName() {
        return name;
    }

    // Documentation inherited from Logger
    private void error(final String message) {
        if (isErrorEnabled()) {
            log("ERROR", message);
        }
    }

    // Documentation inherited from Logger
    private void warn(final String message) {
        if (isWarnEnabled()) {
            log("WARN", message);
        }
    }

    // Documentation inherited from Logger
    private void info(final String message) {
        if (isInfoEnabled()) {
            log("INFO", message);
        }
    }

    // Documentation inherited from Logger
    private void debug(final String message) {
        if (isDebugEnabled()) {
            log("DEBUG", message);
        }
    }

    // Documentation inherited from Logger
    private void trace(final String message) {
        if (isDebugEnabled()) {
            log("TRACE", message);
        }
    }

    // Documentation inherited from Logger
    private void fatal(final String message) {
        if (isDebugEnabled()) {
            log("FATAL", message);
        }
    }

    // Documentation inherited from Logger
    public boolean isErrorEnabled() {
        return errorEnabled;
    }

    /**
     * Sets whether logging is enabled at the ERROR level.
     *
     * @param errorEnabled
     *            determines whether logging is enabled at the ERROR level.
     */
    public void setErrorEnabled(final boolean errorEnabled) {
        this.errorEnabled = errorEnabled;
    }

    // Documentation inherited from Logger
    public boolean isWarnEnabled() {
        return warnEnabled;
    }

    /**
     * Sets whether logging is enabled at the WARN level.
     *
     * @param warnEnabled
     *            determines whether logging is enabled at the WARN level.
     */
    public void setWarnEnabled(final boolean warnEnabled) {
        this.warnEnabled = warnEnabled;
    }

    // Documentation inherited from Logger
    public boolean isInfoEnabled() {
        return infoEnabled;
    }

    /**
     * Sets whether logging is enabled at the INFO level.
     *
     * @param infoEnabled
     *            determines whether logging is enabled at the INFO level.
     */
    public void setInfoEnabled(final boolean infoEnabled) {
        this.infoEnabled = infoEnabled;
    }

    // Documentation inherited from Logger
    public boolean isDebugEnabled() {
        return debugEnabled;
    }

    /**
     * Sets whether logging is enabled at the DEBUG level.
     *
     * @param debugEnabled
     *            determines whether logging is enabled at the DEBUG level.
     */
    public void setDebugEnabled(final boolean debugEnabled) {
        this.debugEnabled = debugEnabled;
    }

    private void log(final String level, final String message) {
        try {
            writer.write(BasicLogFormatter.format(level, message, name));
            writer.flush();
        } catch (final IOException ex) {
            throw new RuntimeException(ex);
        }
    }

	public void debug(Object message) {
		debug(BasicLogFormatter.toTraceMessage(message));
	}

	public void debug(Object message, Throwable throwable) {
		debug(BasicLogFormatter.toTraceMessage(message, throwable));
	}

	public void error(Object message) {
		error(BasicLogFormatter.toTraceMessage(message));
	}

	public void error(Object message, Throwable throwable) {
		error(BasicLogFormatter.toTraceMessage(message, throwable));
	}

	public void fatal(Object message) {
		fatal(BasicLogFormatter.toTraceMessage(message));
	}

	public void fatal(Object message, Throwable throwable) {
		fatal(BasicLogFormatter.toTraceMessage(message, throwable));
	}

	public void info(Object message) {
		info(BasicLogFormatter.toMessage(message));
	}

	public void info(Object message, Throwable throwable) {
		info(BasicLogFormatter.toMessage(message, throwable));
	}

	public boolean isFatalEnabled() {
		return true;
	}

	public boolean isTraceEnabled() {
		return true;
	}

	public void trace(Object message) {
		trace(BasicLogFormatter.toTraceMessage(message));
	}

	public void trace(Object message, Throwable throwable) {
		trace(BasicLogFormatter.toTraceMessage(message, throwable));
	}

	public void warn(Object message) {
		warn(BasicLogFormatter.toMessage(message));
	}

	public void warn(Object message, Throwable throwable) {
		warn(BasicLogFormatter.toMessage(message, throwable));
	}
}
