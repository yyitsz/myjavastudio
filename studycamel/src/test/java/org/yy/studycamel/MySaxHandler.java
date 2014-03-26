/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package org.yy.studycamel;

import java.util.Stack;
import org.apache.commons.lang3.StringUtils;
import org.xml.sax.Attributes;
import org.xml.sax.SAXException;
import org.xml.sax.helpers.AttributesImpl;
import org.xml.sax.helpers.DefaultHandler;

/**
 *
 * @author yyi
 */
public class MySaxHandler extends DefaultHandler {

    private XmlMessage rootMessage;
    private XmlMessage currentMessage;
    private Stack<XmlMessage> stack = new Stack<XmlMessage>();
    
    public XmlMessage getXmlMessage() {
        return rootMessage;
    }

    @Override
    public void endDocument() throws SAXException {
        System.out.println("end parse.");

    }

    @Override
    public void endElement(String uri, String localName, String qName) throws SAXException {
       // System.out.println("end parse." + uri + ", " + localName + ", " + qName);

        if (rootMessage != currentMessage) {
            currentMessage = stack.pop();
        }
    }

    @Override
    public void startDocument() throws SAXException {
        //System.out.println("starting parse.");

    }

    @Override
    public void startElement(String uri, String localName, String qName, Attributes attributes) throws SAXException {
       // System.out.println("starting parse." + uri + ", " + localName + ", " + qName);
        XmlMessage parentMessage = currentMessage;

        currentMessage = new XmlMessage();
        if (rootMessage == null) {
            rootMessage = currentMessage;
        }
        if (parentMessage != null) {
            stack.push(parentMessage);
            parentMessage.addElement(localName, currentMessage);
        }
        currentMessage.setElementName(localName);
        if (attributes != null) {
            for (int i = 0; i < attributes.getLength(); i++) {
                currentMessage.addAttribte(attributes.getLocalName(i), attributes.getValue(i));

            }
        }

    }

    @Override
    public void characters(char[] ch, int start, int length) throws SAXException {
       // System.out.println("Current element is: " + currentMessage.getElementName());
        String text = String.valueOf(ch, start, length);
       // System.out.println(text);

        if (StringUtils.isBlank(text) == false) {
            currentMessage.setTextContent(text);
        }

    }
}
