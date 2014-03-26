/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package org.yy.base.util;

/**
 *
 * @author yyi
 */
public class Tuple2<T1,T2> implements Comparable<Tuple2<T1,T2>>{
    private T1 value1;
    private T2 value2;

    public Tuple2(T1 value1, T2 value2) {
        this.value1 = value1;
        this.value2 = value2;
    }

    public T1 getValue1() {
        return value1;
    }

    public T2 getValue2() {
        return value2;
    }

	public int compareTo(Tuple2<T1, T2> o) {
		
		return 0;
	}

	
    
}
