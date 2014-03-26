/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package org.yy.studyjee.ejb;

import javax.ejb.Remote;

/**
 *
 * @author yyi
 */
@Remote
public interface HelloWorldBeanRemote {
      String sayHello(String name);
}
