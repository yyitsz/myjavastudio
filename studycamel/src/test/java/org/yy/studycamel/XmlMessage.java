/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package org.yy.studycamel;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.LinkedHashMap;
import java.util.List;
import java.util.Map;
import java.util.Map.Entry;
import java.util.TreeMap;
import org.apache.commons.lang3.StringEscapeUtils;
import org.apache.commons.lang3.StringUtils;

/**
 *
 * @author yyi
 */
public class XmlMessage {

    private String elementName;
    private String textContent = "";
    private Map<String, Object> attributes = new java.util.LinkedHashMap<String, Object>();
    private Map<String, List<XmlMessage>> elements = new LinkedHashMap<String, List<XmlMessage>>();

    public String getTextContent() {
        return textContent;
    }

    public void setTextContent(String textContent) {

        this.textContent += textContent;
    }

    public String getElementName() {
        return elementName;
    }

    public void setElementName(String elementName) {
        this.elementName = elementName;
    }

    public void addAttribte(String key, Object value) {
        attributes.put(key, value);

    }

    public void addElement(String elementName, XmlMessage element) {
        if (elements.containsKey(elementName) == false) {
            elements.put(elementName, new ArrayList<XmlMessage>());
        }

        elements.get(elementName).add(element);

    }

    public String toXml() {
        return toXml(0);

    }

    private String toXml(int level) {
        StringBuilder sb = new StringBuilder();
        String lineSeparator = System.getProperty("line.separator");
        padSpace(sb, level * 2);
        sb.append("<").append(elementName);

        for (Entry<String, Object> entry : attributes.entrySet()) {
            sb.append(" ").append(entry.getKey()).append("=\"").append(StringEscapeUtils.escapeHtml4(String.valueOf(entry.getValue()))).append("\" ");
        }
        if (elements.isEmpty() && StringUtils.isEmpty(textContent)) {
            sb.append("/>");
            sb.append(lineSeparator);
        } else {
            sb.append(">");
            if (StringUtils.isEmpty(textContent) == false) {
                sb.append(StringEscapeUtils.escapeHtml4(textContent));
            }
            if (elements.isEmpty()) {
                sb.append("</").append(elementName).append(">");
                sb.append(lineSeparator);
            } else {
                sb.append(lineSeparator);
                for (Entry<String, List<XmlMessage>> entry : elements.entrySet()) {
                    for (XmlMessage msg : entry.getValue()) {
                        sb.append(msg.toXml(level + 1));
                    }
                }

                padSpace(sb, level * 2);
                sb.append("</").append(elementName).append(">");
                sb.append(lineSeparator);
            }
        }
        return sb.toString();
    }

    private void padSpace(StringBuilder sb, int number) {
        for (int i = 0; i < number; i++) {
            sb.append(" ");
        }

    }
}
