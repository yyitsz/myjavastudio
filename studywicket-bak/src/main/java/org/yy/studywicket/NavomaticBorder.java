package org.yy.studywicket;

import org.apache.wicket.markup.html.WebPage;
import org.apache.wicket.markup.html.border.Border;
import org.apache.wicket.markup.html.border.BoxBorder;

public class NavomaticBorder extends Border {

	public NavomaticBorder(String componentName) {
		super(componentName);
		this.addToBorder(new BoxBorder("navigationBorder"));
		this.addToBorder(new BoxBorder("bodyBorder"));
	}

	/**
	 * 
	 */
	private static final long serialVersionUID = 3476942739289259462L;

	

}
