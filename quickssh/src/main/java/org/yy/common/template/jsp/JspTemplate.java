package org.yy.common.template.jsp;

import java.io.IOException;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

public class JspTemplate {

	private final HttpServletRequest request;
	private final String jsppath;

	public JspTemplate(final HttpServletRequest request, final String jsppath) {
		this.request = request;
		this.jsppath = jsppath;
	}

	public String getResult() throws ServletException, IOException {
		return getResult(null);
	}

	public String getResult(final HttpServletResponse response)
			throws ServletException, IOException {
		final RequestDispatcher requestDispatcher = request
				.getRequestDispatcher(jsppath);
		final WrapperResponse wr = new WrapperResponse(response);
		requestDispatcher.include(request, wr);
		return wr.getContent();
	}

}
