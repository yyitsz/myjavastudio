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

public final class LogFactory {
    private static LogProvider defaultLoggerProvider = null;

    public static Log getLog(final String name) {
        return getLogProvider().getLog(name);
    }

    public static Log getLog(final Class loggedClass) {
        return getLog(loggedClass.getName());
    }

    public static LogProvider getLogProvider() {
        return getDefaultLoggerProvider();
    }

    private static LogProvider getDefaultLoggerProvider() {
        if (defaultLoggerProvider == null) {
            defaultLoggerProvider = determineDefaultLoggerProvider();
        }
        return defaultLoggerProvider;
    }

    private static LogProvider determineDefaultLoggerProvider() {
        //TODO: 寻找一个判断Log是否已经正确配置的方法，否则仅通过jar包无法准确选择合适的工具
    	//this should be the last choice ,but..
    	if (isClassAvailable("org.slf4j.impl.StaticLoggerBinder")) {
            if (isClassAvailable("org.slf4j.impl.JDK14LoggerFactory")) {
                return LogProvider.JAVA;
            }
            if (isClassAvailable("org.slf4j.impl.Log4jLoggerFactory")) {
                return LogProvider.LOG4J;
            }
            if (!isClassAvailable("org.slf4j.impl.JCLLoggerFactory")) {
                return LogProvider.SLF4J;
                // fall through to next check if SLF4J is configured to use JCL
            }
        }
    	if (isClassAvailable("org.apache.commons.logging.Log")) {
            final String logClassName = org.apache.commons.logging.LogFactory
                    .getLog("test").getClass().getName();
            if (logClassName
                    .equals("org.apache.commons.logging.impl.Jdk14Logger")) {
                return LogProvider.JAVA;
            }
            if (logClassName
                    .equals("org.apache.commons.logging.impl.Log4JLogger")) {
                return LogProvider.LOG4J;
            }
            return LogProvider.JCL;
        }
    	if (isClassAvailable("org.apache.log4j.Logger")) {
            return LogProvider.LOG4J;
        }
        
        return LogProvider.STDERR;
    }

    private static boolean isClassAvailable(final String className) {
        try {
            Class.forName(className);
            return true;
        } catch (final Throwable t) {
            return false;
        }
    }
}
