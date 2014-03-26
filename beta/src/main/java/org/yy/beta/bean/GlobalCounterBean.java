/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package org.yy.beta.bean;

import java.io.Serializable;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import org.primefaces.push.PushContext;
import org.primefaces.push.PushContextFactory;

/**
 *
 * @author yy
 */
@ManagedBean
@SessionScoped
public class GlobalCounterBean implements Serializable{
    private int counter;

    public int getCounter() {
        return counter;
    }

    public void setCounter(int counter) {
        this.counter = counter;
    }
    
    public synchronized void increment(){
        counter++;
        PushContext pushContext = PushContextFactory.getDefault().getPushContext();
        pushContext.push("/counter", Integer.valueOf(counter));
    }
}
