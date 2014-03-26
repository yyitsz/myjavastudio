/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package org.yy.studyapp.core;

/**
 *
 * @author yyi
 */
public class AppBaseException extends RuntimeException {

    public AppBaseException(Throwable cause) {
        super(cause);
    }

    public AppBaseException(String message, Throwable cause) {
        super(message, cause);
    }

    public AppBaseException(String message) {
        super(message);
    }

    public AppBaseException() {
    }
    
}
