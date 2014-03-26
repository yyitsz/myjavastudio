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

import java.io.OutputStreamWriter;

final class LogProviderSTDERR extends AbstractLogProvider {
    public static final LogProvider INSTANCE = new LogProviderSTDERR();

    private LogProviderSTDERR() {
    }

    public Log getLog(final String name) {
        return new WriterLogger(new OutputStreamWriter(System.err), name);
    }
}
