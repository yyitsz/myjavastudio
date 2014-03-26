/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package org.yy.base.util;

/**
 *
 * @author yyi
 */
public class Tuple3<T1,T2,T3> extends Tuple2<T1,T2> {
    private T3 value3;

    public Tuple3(T1 value1, T2 value2,T3 value3){
    	super(value1,value2);
        this.value3 = value3;
    }

    public T3 getValue3() {
        return value3;
    }

   
}
