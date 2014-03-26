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

/**
 * Defines the interface for handling log messages.
 * <p>
 * It is not usually necessary for users to create implementations of this
 * interface, as the {@link LogProvider} interface contains several
 * predefined instances which provide the most commonly required
 * <code>Logger</code> implementations.
 * <p>
 * By default, logging is configured automatically according to the algorithm
 * described in the static {@link Config#LoggerProvider} property.
 * <p>
 * An instance of a class that implements this interface is used by calling the
 * {@link Source#setLogger(Logger)} method on the relevant {@link Source}
 * object.
 * <p>
 * Four <i><a name="LoggingLevel">logging levels</a></i> are defined in this
 * interface. The logging level is specified only by the use of different method
 * names, there is no class or type defining the levels. This makes the code
 * required to wrap other logging frameworks much simpler and more efficient.
 * <p>
 * The four logging levels are:
 * <ul class="SmallVerticalMargin">
 * <li>{@link #error(String) ERROR}
 * <li>{@link #warn(String) WARN}
 * <li>{@link #info(String) INFO}
 * <li>{@link #debug(String) DEBUG}
 * </ul>
 * <p>
 * IMPLEMENTATION NOTE: Ideally the <code>java.util.logging.Logger</code>
 * class could have been used as a basis for logging, even if used to define a
 * wrapper around other logging frameworks. This would have avoided the need to
 * define yet another logging interface, but because
 * <code>java.util.logging.Logger</code> is implemented very poorly, it is
 * quite tricky to extend it as a wrapper. Other logging wrapper frameworks such
 * as <a target="_blank" href="http://www.slf4j.org/">SLF4J</a> or <a
 * target="_blank" href="http://jakarta.apache.org/commons/logging/">Jakarta
 * Commons Logging</a> provide good logging interfaces, but to avoid
 * introducing dependencies it was decided to create this new interface.
 *
 * @see Config#LoggerProvider
 * @author GL
 *
 */
public interface Log {

    /**
     * Indicates whether logging is enabled at the ERROR level.
     *
     * @return <code>true</code> if logging is enabled at the ERROR level,
     *         otherwise <code>false</code>.
     */
    boolean isErrorEnabled();

    /**
     * Indicates whether logging is enabled at the WARN level.
     *
     * @return <code>true</code> if logging is enabled at the WARN level,
     *         otherwise <code>false</code>.
     */
    boolean isWarnEnabled();

    /**
     * Indicates whether logging is enabled at the INFO level.
     *
     * @return <code>true</code> if logging is enabled at the INFO level,
     *         otherwise <code>false</code>.
     */
    boolean isInfoEnabled();

    /**
     * Indicates whether logging is enabled at the DEBUG level.
     *
     * @return <code>true</code> if logging is enabled at the DEBUG level,
     *         otherwise <code>false</code>.
     */
    boolean isDebugEnabled();

    boolean isFatalEnabled();

    boolean isTraceEnabled();

    void trace(Object message);

    void trace(Object message, Throwable throwable);

    void debug(Object message);

    void debug(Object message, Throwable throwable);

    void info(Object message);

    void info(Object message, Throwable throwable);

    void warn(Object message);

    void warn(Object message, Throwable throwable);

    void error(Object message);

    void error(Object message, Throwable throwable);

    void fatal(Object message);

    void fatal(Object message, Throwable throwable);
}