package org.yy.studycamel;

import java.util.logging.Level;
import java.util.logging.Logger;
import org.apache.camel.spring.Main;

/**
 * Hello world!
 *
 */
public class App 
{
    public static void main( String[] args )
    {
        try {
            Main.main(args);
        } catch (Exception ex) {
           ex.printStackTrace(System.out);
        }
    }
}
