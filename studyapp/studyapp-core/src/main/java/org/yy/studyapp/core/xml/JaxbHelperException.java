/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package org.yy.studyapp.core.xml;

import org.yy.studyapp.core.AppBaseException;

/**
 *
 * @author yyi
 */
public class JaxbHelperException extends AppBaseException{

    public JaxbHelperException() {
    }

    public JaxbHelperException(String message) {
        super(message);
    }

    public JaxbHelperException(String message, Throwable cause) {
        super(message, cause);
    }

    public JaxbHelperException(Throwable cause) {
        super(cause);
    }
    
}
