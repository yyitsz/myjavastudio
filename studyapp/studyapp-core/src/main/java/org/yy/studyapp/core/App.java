package org.yy.studyapp.core;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

/**
 * Hello world!
 *
 */
public class App 
{
    private static Logger log = LoggerFactory.getLogger(App.class);
    
    public static void main( String[] args )
    {
        System.out.println( "Starting Application!" );
        try {
            org.apache.camel.spring.Main.main(args);
        } catch (Exception ex) {
           log.error("Error when starting camel.", ex);
        }
        System.out.println("Exit Application.");
    }
}
