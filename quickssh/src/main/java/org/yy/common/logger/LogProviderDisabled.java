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

import org.yy.common.io.NullWriter;

final class LogProviderDisabled extends AbstractLogProvider {
    public static final LogProvider INSTANCE = new LogProviderDisabled();

    private LogProviderDisabled() {
    }

    public Log getLog(final String name) {
        return new WriterLogger(new NullWriter(),name);
    }
    
}
