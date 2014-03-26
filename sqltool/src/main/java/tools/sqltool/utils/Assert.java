/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package tools.sqltool.utils;

/**
 *
 * @author yy
 */
public class Assert {

    public static void notNull(Object obj) {
        if(obj == null) {
            throw new NullPointerException();
        }
    }

    public static void inRange(int index, int low, int high) {
        if(index < low || index > high) {
            throw new IndexOutOfBoundsException("The value " + index + " is not between " + low + " and " + high);
        }
    }
    
}
