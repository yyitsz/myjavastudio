/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package org.yy.studycamel;

import java.io.IOException;
import junit.framework.Assert;
import org.junit.Test;
import org.xml.sax.InputSource;
import org.xml.sax.SAXException;
import org.xml.sax.XMLReader;
import org.xml.sax.helpers.XMLReaderFactory;

/**
 *
 * @author yyi
 */
public class Sax2Test {

   // @Test
    public void test1() throws Exception {
        XMLReader reader = XMLReaderFactory.createXMLReader();
        MySaxHandler handler = new MySaxHandler();
        reader.setContentHandler(handler);
        reader.setErrorHandler(handler);
        reader.parse(new InputSource(this.getClass().getClassLoader().getResourceAsStream("test.xml")));

        XmlMessage msg = handler.getXmlMessage();
        System.out.println(msg.toXml());
    }

    @Test
    public void testWithWrongXmlDoc() throws Exception {
        XMLReader reader = XMLReaderFactory.createXMLReader();
        MySaxHandler handler = new MySaxHandler();
        reader.setContentHandler(handler);
        reader.setErrorHandler(handler);
        reader.parse(new InputSource(this.getClass().getClassLoader().getResourceAsStream("test_error.xml")));

        XmlMessage msg = handler.getXmlMessage();
      
        System.out.println(msg.toXml());
    }
}
