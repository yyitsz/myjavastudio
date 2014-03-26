package org.yy.common.web.auth;

import org.yy.common.util.LightCommonsException;

/**
 * @author <a href="mailto:gl@kindsoft.cn">桂健雄</a>
 * @since 2007-4-30
 */
public class AccessDeniedException extends LightCommonsException {

	/**
	 * 
	 */
	private static final long serialVersionUID = 7540228858372501656L;

	public AccessDeniedException(String message, Throwable cause) {
		super(message, cause);
	}

	public AccessDeniedException(String message) {
		super(message);
	}

	boolean noUser;
	boolean errorPassword;

	public boolean isErrorPassword() {
		return errorPassword;
	}

	public boolean isNoUser() {
		return noUser;
	}

	public void setErrorPassword(boolean errorPassword) {
		this.errorPassword = errorPassword;
	}

	public void setNoUser(boolean noUser) {
		this.noUser = noUser;
	}


	
}
