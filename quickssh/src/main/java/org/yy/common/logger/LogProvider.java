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
 * Defines the interface for a factory class to provide {@link Log} instances
 * <p>
 * It is not usually necessary for users to create implementations of this
 * interface, as several predefined instances are defined which provide the most
 * commonly required {@link Log} implementations.
 * <p>
 */
public interface LogProvider {
    /**
     * A {@link LogProvider} implementation that disables all log messages.
     */
    public static final LogProvider DISABLED = LogProviderDisabled.INSTANCE;

    /**
     * A {@link LogProvider} implementation that sends all log messages to
     * the standard error output stream (<code>System.err</code>).
     * <p>
     * The implementation uses the following code to create each logger:<br />
     * <code>new </code>{@link WriterLogger}<code>(new OutputStreamWriter(System.err),name)</code>
     */
    public static final LogProvider STDERR   = LogProviderSTDERR.INSTANCE;

    /**
     * A {@link LogProvider} implementation that wraps the standard
     * <code>java.util.logging</code> system included in the Java SDK version
     * 1.4 and above.
     * <p>
     * This is the default used if no other logging framework is detected. See
     * the description of the static {@link Config#LoggerProvider} property for
     * more details.
     * <p>
     * The following mapping of <a href="Logger.html#LoggingLevel">logging
     * levels</a> is used: <table class="bordered" style="margin: 15px"
     * cellspacing="0">
     * <tr>
     * <th>{@link Log} level
     * <th><code>java.util.logging.Level</code>
     * <tr>
     * <td>{@link Log#error(String) ERROR}
     * <td><code>SEVERE</code>
     * <tr>
     * <td>{@link Log#warn(String) WARN}
     * <td><code>WARNING</code>
     * <tr>
     * <td>{@link Log#info(String) INFO}
     * <td><code>INFO</code>
     * <tr>
     * <td>{@link Log#debug(String) DEBUG}
     * <td><code>FINE</code> </table>
     */
    public static final LogProvider JAVA     = LogProviderJava.INSTANCE;

    /**
     * A {@link LogProvider} implementation that wraps the <a target="_blank"
     * href="http://jakarta.apache.org/commons/logging/">Jakarta Commons Logging</a>
     * (JCL) framework.
     * <p>
     * See the description of the static {@link Config#LoggerProvider} property
     * for details on when this implementation is used as the default.
     * <p>
     * The following mapping of <a href="Logger.html#LoggingLevel">logging
     * levels</a> is used: <table class="bordered" style="margin: 15px"
     * cellspacing="0">
     * <tr>
     * <th>{@link Log} level
     * <th><code>org.apache.commons.logging</code> level
     * <tr>
     * <td>{@link Log#error(String) ERROR}
     * <td><code>error</code>
     * <tr>
     * <td>{@link Log#warn(String) WARN}
     * <td><code>warn</code>
     * <tr>
     * <td>{@link Log#info(String) INFO}
     * <td><code>info</code>
     * <tr>
     * <td>{@link Log#debug(String) DEBUG}
     * <td><code>debug</code> </table>
     */
    public static final LogProvider JCL      = LogProviderJCL.INSTANCE;

    /**
     * A {@link LogProvider} implementation that wraps the <a target="_blank"
     * href="http://logging.apache.org/log4j/">Apache Log4J</a> framework.
     * <p>
     * See the description of the static {@link Config#LoggerProvider} property
     * for details on when this implementation is used as the default.
     * <p>
     * The following mapping of <a href="Logger.html#LoggingLevel">logging
     * levels</a> is used: <table class="bordered" style="margin: 15px"
     * cellspacing="0">
     * <tr>
     * <th>{@link Log} level
     * <th><code>org.apache.log4j.Level</code>
     * <tr>
     * <td>{@link Log#error(String) ERROR}
     * <td><code>ERROR</code>
     * <tr>
     * <td>{@link Log#warn(String) WARN}
     * <td><code>WARN</code>
     * <tr>
     * <td>{@link Log#info(String) INFO}
     * <td><code>INFO</code>
     * <tr>
     * <td>{@link Log#debug(String) DEBUG}
     * <td><code>DEBUG</code> </table>
     */
    public static final LogProvider LOG4J    = LogProviderLog4J.INSTANCE;

    /**
     * A {@link LogProvider} implementation that wraps the <a target="_blank"
     * href="http://www.slf4j.org/">SLF4J</a> framework.
     * <p>
     * See the description of the static {@link Config#LoggerProvider} property
     * for details on when this implementation is used as the default.
     * <p>
     * The following mapping of <a href="Logger.html#LoggingLevel">logging
     * levels</a> is used: <table class="bordered" style="margin: 15px"
     * cellspacing="0">
     * <tr>
     * <th>{@link Log} level
     * <th><code>org.slf4j.Logger</code> level
     * <tr>
     * <td>{@link Log#error(String) ERROR}
     * <td><code>error</code>
     * <tr>
     * <td>{@link Log#warn(String) WARN}
     * <td><code>warn</code>
     * <tr>
     * <td>{@link Log#info(String) INFO}
     * <td><code>info</code>
     * <tr>
     * <td>{@link Log#debug(String) DEBUG}
     * <td><code>debug</code> </table>
     */
    public static final LogProvider SLF4J    = LogProviderSLF4J.INSTANCE;

    /**
     * Creates a new {@link Log} instance with the specified name.
     * <p>
     * The <code>name</code> argument is used by the underlying logging
     * implementation, and is normally a dot-separated name based on the package
     * name or class name of the subsystem.
     * <p>
     * The name used for all automatically created {@link Log} instances is "<code>net.htmlparser.jericho</code>".
     * 
     * @param name
     *            the name of the logger, the use of which is determined by the
     *            underlying logging implementation, may be <code>null</code>.
     * @return a new {@link Log} instance with the specified name.
     */
    Log getLog(String name);
    Log getLog(Class clazz);
}
