/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package tools.sqltool.utils;

import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.InputStream;
import java.io.OutputStream;
import java.io.Reader;
import java.io.StringReader;
import java.io.StringWriter;
import java.io.Writer;
import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBException;
import tools.sqltool.mapper.TableMapper;

/**
 *
 * @author yyi
 */
public final class JaxbUtils {

    private String contextPath;
    private JAXBContext ctx;

    public JaxbUtils(String contextPath) {
        if (contextPath == null || contextPath.isEmpty()) {
            throw new IllegalArgumentException("contextPath is required.");
        }
        this.contextPath = contextPath;
        try {
            ctx = JAXBContext.newInstance(contextPath);
        } catch (JAXBException ex) {
            throw new RuntimeException("Can not craete JAXBContext using " + contextPath, ex);
        }
    }

    public Object unmarshal(String xml) {
        if (xml == null || xml.isEmpty()) {
            return null;
        }
        try {
            Object obj = ctx.createUnmarshaller().unmarshal(new StringReader(xml));
            return obj;
        } catch (JAXBException ex) {
            throw new RuntimeException("Can not craete JAXBContext using " + contextPath, ex);
        }
    }

    public Object unmarshal(File file) {
        try {
            Object obj = ctx.createUnmarshaller().unmarshal(file);
            return obj;
        } catch (JAXBException ex) {
            throw new RuntimeException("Can not craete JAXBContext using " + contextPath, ex);
        }
    }

    public Object unmarshal(InputStream is) {
        try {
            Object obj = ctx.createUnmarshaller().unmarshal(is);
            return obj;
        } catch (JAXBException ex) {
            throw new RuntimeException("Can not craete JAXBContext using " + contextPath, ex);
        }
    }

    public Object unmarshal(Reader reader) {
        try {
            Object obj = ctx.createUnmarshaller().unmarshal(reader);
            return obj;
        } catch (JAXBException ex) {
            throw new RuntimeException("Can not craete JAXBContext using " + contextPath, ex);
        }
    }

    public Object unmarshal(byte[] bytes) {
        if (bytes == null || bytes.length == 0) {
            return null;
        }
        try {
            Object obj = ctx.createUnmarshaller().unmarshal(new ByteArrayInputStream(bytes));
            return obj;
        } catch (JAXBException ex) {
            throw new RuntimeException("Can not craete JAXBContext using " + contextPath, ex);
        }
    }

    public <T> T unmarshal(String xml, Class<T> clazz) {
        Object obj = unmarshal(xml);
        if (obj == null) {
            return null;
        }
        if (clazz.isAssignableFrom(obj.getClass())) {
            return (T) obj;
        } else {
            throw new IllegalArgumentException(obj.getClass().getName() + " can not be converted to " + clazz.getName());
        }
    }

    public <T> T unmarshal(byte[] bytes, Class<T> clazz) {
        Object obj = unmarshal(bytes);
        if (obj == null) {
            return null;
        }
        if (clazz.isAssignableFrom(obj.getClass())) {
            return (T) obj;
        } else {
            throw new IllegalArgumentException(obj.getClass().getName() + " can not be converted to " + clazz.getName());
        }
    }

    public String marshal(Object target) {
        if (target == null) {
            return "";
        }
        try {
            StringWriter sw = new StringWriter();
            ctx.createMarshaller().marshal(target, sw);
            return sw.toString();
        } catch (JAXBException ex) {
            throw new RuntimeException("Can not craete JAXBContext using " + contextPath, ex);
        }
    }

    public byte[] marshal2Byte(Object target) {
        if (target == null) {
            return new byte[0];
        }
        try {
            ByteArrayOutputStream bos = new ByteArrayOutputStream();
            ctx.createMarshaller().marshal(target, bos);
            return bos.toByteArray();
        } catch (JAXBException ex) {
            throw new RuntimeException("Can not craete JAXBContext using " + contextPath, ex);
        }
    }

    public void marshal2Byte(Object target, OutputStream out) {
        if (target == null) {
            return;
        }
        try {
            ctx.createMarshaller().marshal(target, out);

        } catch (JAXBException ex) {
            throw new RuntimeException("Can not craete JAXBContext using " + contextPath, ex);
        }
    }

    public void marshal(Object target, Writer writer) {
        if (target == null) {
            return;
        }
        try {
            ctx.createMarshaller().marshal(target, writer);
        } catch (JAXBException ex) {
            throw new RuntimeException("Can not craete JAXBContext using " + contextPath, ex);
        }
    }
}
