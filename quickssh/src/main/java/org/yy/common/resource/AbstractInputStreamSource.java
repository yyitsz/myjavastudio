/**
 * Light-commons Project
 * http://light-commons.googlecode.com
 * Copyright (C) 2008 Jason Green
 * email: guileen@gmail.com
 *
 * License: Apache License 2.0 
 * (http://www.apache.org/licenses/LICENSE-2.0)
 *
 */
package org.yy.common.resource;

import java.io.IOException;
import java.nio.charset.UnsupportedCharsetException;

import org.yy.common.io.IOUtils;

/**
 * @author gl
 * @since Jun 30, 2008
 */
public abstract class AbstractInputStreamSource implements InputStreamSource{
	
	public byte[] getByteArray() throws IOException {
		return IOUtils.toByteArray(getInputStream());
	}

	public char[] getCharArray(String encoding) throws IOException,
			UnsupportedCharsetException {
		return IOUtils.toCharArray(getInputStream(), encoding);
	}

	public String getText(String encoding) throws IOException,
			UnsupportedCharsetException {
		return IOUtils.toString(getInputStream(), encoding);
	}
	
	
}
