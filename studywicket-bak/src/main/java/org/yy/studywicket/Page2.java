package org.yy.studywicket;

import org.apache.wicket.request.mapper.parameter.PageParameters;
import org.apache.wicket.markup.html.basic.Label;
import org.apache.wicket.markup.html.form.Button;
import org.apache.wicket.markup.html.form.Form;
import org.apache.wicket.markup.html.form.TextField;
import org.apache.wicket.markup.html.WebPage;
import org.apache.wicket.model.PropertyModel;

public class Page2 extends BasePage {
	private static final long serialVersionUID = 1L;
	
    public Page2(final PageParameters parameters) {
		
        add(new NavomaticBorder("navomaticBorder"));
        
    }
}
