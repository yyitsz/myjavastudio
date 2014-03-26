/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package tools.sqltool.utils;

import java.io.ByteArrayInputStream;
import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.text.SimpleDateFormat;

/**
 *
 * @author yy
 */
public class AppUtils {

//    private static ClassPathXmlApplicationContext ctx;
//
//    public static void init() {
//        ctx = new ClassPathXmlApplicationContext("classpath:appctx.xml");
//        ctx.refresh();
//        ctx.registerShutdownHook();
//    }
//
//    public static <T> T getBean(Class<T> clazz) {
//        return ctx.getBean(clazz);
//    }
//
//    public static <T> T getBean(String name, Class<T> clazz) {
//        return ctx.getBean(name, clazz);
//    }
//
    public static <T> T deepClone(T src) {
        return (T) deepCloneObj(src);
    }

    public static Object deepCloneObj(Object src) {
        Object o = null;
        try {
            if (src != null) {
                ByteArrayOutputStream baos = new ByteArrayOutputStream();
                ObjectOutputStream oos = new ObjectOutputStream(baos);
                oos.writeObject(src);
                oos.close();
                ByteArrayInputStream bais = new ByteArrayInputStream(baos
                        .toByteArray());
                ObjectInputStream ois = new ObjectInputStream(bais);
                o = ois.readObject();
                ois.close();
            }
        } catch (IOException e) {
            throw new RuntimeException(e.getMessage(), e);
        } catch (ClassNotFoundException e) {
            throw new RuntimeException(e.getMessage(), e);
        }
        return o;
    }
    
    public static String formatDate(Object date) {
        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:mm:ss");
        return sdf.format(date);
    }
}
