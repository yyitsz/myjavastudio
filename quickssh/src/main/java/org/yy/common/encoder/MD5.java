package org.yy.common.encoder;

import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;

/**
 * <a href="http://www.commontemplate.org">commontemplate</a>
 */
public class MD5 {

	private MD5() {}

	public static String encode(byte[] src) {
		if (src == null)
			return null;
		try {
			MessageDigest md = MessageDigest.getInstance("MD5");
			return new String(HEX.encode(md.digest(src)));
		} catch (NoSuchAlgorithmException e) {
			throw new RuntimeException(e);
		}
	}

	public static String encode(String src) {
		if (src == null)
			return null;
		return encode(src.getBytes());
	}
}
