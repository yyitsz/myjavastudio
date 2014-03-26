package org.yy.common.encoder;

/**
 * Utility class for JavaScript escaping. Escapes based on the JavaScript 1.5
 * recommendation.
 *
 * <p>
 * Reference: <a href="http://developer.mozilla.org/en/docs/Core_JavaScript_1.5_Guide:Literals#String_Literals"
 * > Core JavaScript 1.5 Guide </a>
 *
 * @author Juergen Hoeller
 * @author Rob Harrop
 * @since 1.1.1
 */
public class JavaScript {

    /**
     * Turn special characters into escaped characters conforming to JavaScript.
     * Handles complete character set defined in HTML 4.01 recommendation.
     *
     * @param input
     *            the input string
     * @return the escaped string
     */
    public static String encode(String input) {
        if (input == null) {
            return input;
        }

        StringBuffer filtered = new StringBuffer(input.length());
        char prevChar = '\u0000';
        char c;
        for (int i = 0; i < input.length(); i++) {
            c = input.charAt(i);
            if (c == '"') {
                filtered.append("\\\"");
            } else if (c == '\'') {
                filtered.append("\\'");
            } else if (c == '\\') {
                filtered.append("\\\\");
            } else if (c == '/') {
                filtered.append("\\/");
            } else if (c == '\t') {
                filtered.append("\\t");
            } else if (c == '\n') {
                if (prevChar != '\r') {
                    filtered.append("\\n");
                }
            } else if (c == '\r') {
                filtered.append("\\n");
            } else if (c == '\f') {
                filtered.append("\\f");
            } else {
                filtered.append(c);
            }
            prevChar = c;

        }
        return filtered.toString();
    }

}
