/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package org.yy.studycamel.processor;

import org.apache.camel.Exchange;
import org.apache.camel.Processor;

/**
 *
 * @author yyi
 */
public class MyServiceProcessor implements Processor {

    @Override
    public void process(Exchange exchange) throws Exception {
       exchange.getOut().setBody("Hello, boy!"); 
    }
    
}
