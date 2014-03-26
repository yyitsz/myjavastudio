/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package org.yy.base.util;

/**
 * 
 * @author yyi
 */
public class Tuple4<T1, T2, T3, T4> extends Tuple3<T1, T2, T3> {
	private T4 value4;

	public Tuple4(T1 value1, T2 value2, T3 value3, T4 value4) {
		super(value1, value2, value3);
		this.value4 = value4;
	}

	public T4 getValue4() {
		return value4;
	}

}
