/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package org.yy.studyjee.ejb;

import javax.ejb.Local;

/**
 *
 * @author yyi
 */
@Local
public interface HelloWorldBeanLocal {
    
    String sayHello(String name);
    
}
