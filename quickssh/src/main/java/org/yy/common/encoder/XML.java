package org.yy.common.encoder;

/**
 * <a href="http://www.commontemplate.org">commontemplate</a>
 */
public class XML {

	 public static final String encode(String src) {
		 return src.replaceAll("&", "&amp;")
			.replaceAll(">", "&gt;")
			.replaceAll("<", "&lt;")
			.replaceAll("\"", "&quot;")
			.replaceAll("\'", "&apos;");
	 }

}
