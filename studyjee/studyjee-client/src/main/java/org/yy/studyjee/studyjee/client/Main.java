package org.yy.studyjee.studyjee.client;

import java.util.Properties;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.naming.InitialContext;
import javax.naming.NamingException;
import org.yy.studyjee.ejb.HelloWorldBeanRemote;

/**
 * Enterprise Application Client main class.
 *
 */
public class Main {

    public static void main(String[] args) {
        try {
            System.out.println("Hello World Enterprise Application Client!");
            Properties props = new Properties();
            props.setProperty("java.naming.factory.initial",
                    "com.sun.enterprise.naming.SerialInitContextFactory");
//            props.setProperty("java.naming.factory.url.pkgs",
//                    "com.sun.enterprise.naming");
//            props.setProperty("java.naming.factory.state",
//                    "com.sun.corba.ee.impl.presentation.rmi.JNDIStateFactoryImpl");

            // optional.  Defaults to localhost.  Only needed if web server is running
            // on a different host than the appserver   
            props.setProperty("org.omg.CORBA.ORBInitialHost", "localhost");

            // optional.  Defaults to 3700.  Only needed if target orb port is not 3700.
            props.setProperty("org.omg.CORBA.ORBInitialPort", "3700");
            InitialContext ic = new InitialContext(props);

            HelloWorldBeanRemote hw = (HelloWorldBeanRemote) ic.lookup("java:global/studyjee-ear-1.0-SNAPSHOT/studyjee-ejb-1.0-SNAPSHOT/HelloWorldBean!org.yy.studyjee.ejb.HelloWorldBeanRemote");
            String response = hw.sayHello("yy");
            System.out.println(response);
        } catch (NamingException ex) {
            Logger.getLogger(Main.class.getName()).log(Level.SEVERE, null, ex);
        }

    }
}
