/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package org.yy.studyapp.core.xml;

import java.io.StringReader;
import java.io.StringWriter;
import java.io.UnsupportedEncodingException;
import java.nio.charset.Charset;
import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBException;

/**
 *
 * @author yyi
 */
public class JaxbHelper {

    private JAXBContext context;
    // private String contextPath;

    public JaxbHelper(String contextPath) {
        try {
            // this.contextPath = contextPath;
            context = JAXBContext.newInstance(contextPath,Thread.currentThread().getContextClassLoader());
        } catch (JAXBException ex) {
            throw new JaxbHelperException("Error when create JaxbHelper with " + contextPath + " ,because of " + ex.getMessage(), ex);
        }
    }

    public JaxbHelper(Class... classes) {
        try {
            context = JAXBContext.newInstance(classes);
        } catch (JAXBException ex) {
            throw new JaxbHelperException("Error when create JaxbHelper ,because of " + ex.getMessage(), ex);
        }
    }

    public String toXmlString(Object obj) {
        return toXmlString(context, obj);
    }

    public byte[] toXmlBytes(Object obj) {
        return toXmlBytes(context, obj);
    }

    public String toXmlString(JAXBContext ctx, Object obj) {
        if (obj == null) {
            return null;
        }
        try {
            java.io.StringWriter sw = new StringWriter();
            ctx.createMarshaller().marshal(obj, sw);
            return sw.toString();
        } catch (JAXBException ex) {
            throw new JaxbHelperException("Error when marshalling" + obj.toString() + " ,because of " + ex.getMessage(), ex);

        }
    }

    public byte[] toXmlBytes(JAXBContext ctx, Object obj) {
        String xml = toXmlString(ctx, obj);
        if (xml == null) {
            return new byte[0];
        } else {
            return xml.getBytes(Charset.forName("UTF-8"));
        }
    }

    public Object fromXmlBytes(JAXBContext ctx, byte[] bytes) {
        if (bytes == null || bytes.length == 0) {
            return null;
        }
        try {
            String str = new String(bytes, "UTF-8");

            return fromXmlString(ctx, str);

        } catch (UnsupportedEncodingException ex) {
            throw new JaxbHelperException("Error when unmarshalling.because of " + ex.getMessage(), ex);
        }
    }

    public Object fromXmlString(JAXBContext ctx, String str) {
        if (str == null || str.length() == 0) {
            return null;
        }
        try {
            StringReader sr = new StringReader(str);
            return ctx.createUnmarshaller().unmarshal(sr);

        } catch (JAXBException ex) {
            throw new JaxbHelperException("Error when unmarshalling" + str + " ,because of " + ex.getMessage(), ex);

        }
    }

    public Object fromXmlString(String str) {
        return fromXmlString(context, str);
    }

    public Object fromXmlString(byte[] bytes) {
        return fromXmlBytes(context, bytes);
    }
}
