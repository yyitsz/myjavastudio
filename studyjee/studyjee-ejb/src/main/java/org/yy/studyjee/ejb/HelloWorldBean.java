/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package org.yy.studyjee.ejb;

import javax.ejb.Local;
import javax.ejb.Remote;
import javax.ejb.Stateless;

/**
 *
 * @author yyi
 */
@Stateless
@Remote(HelloWorldBeanRemote.class)
@Local(HelloWorldBeanLocal.class)
public class HelloWorldBean implements HelloWorldBeanRemote, HelloWorldBeanLocal {

    @Override
    public String sayHello(String name) {
        return "Hello, " + name;
    }

//     @Override
//    public String sayHelloRemote(String name) {
//        return "Hello, " + name;
//    }
    // Add business logic below. (Right-click in editor and choose
    // "Insert Code > Add Business Method")
    
}
