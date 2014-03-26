package org.yy.studywicket;

import org.apache.wicket.request.mapper.parameter.PageParameters;
import org.apache.wicket.markup.html.basic.Label;
import org.apache.wicket.markup.html.form.Button;
import org.apache.wicket.markup.html.form.Form;
import org.apache.wicket.markup.html.form.TextField;
import org.apache.wicket.markup.html.WebPage;
import org.apache.wicket.model.PropertyModel;

public class HomePage extends BasePage {
	private static final long serialVersionUID = 1L;
	
    public HomePage(final PageParameters parameters) {
		add(new Label("version", getApplication().getFrameworkSettings().getVersion()));
        add(new Label("message","Hello world!"));
        add(new NavomaticBorder("navomaticBorder"));
        
        Person person = new Person();
        person.setName("win");
        @SuppressWarnings("serial")
		Form<Person> form = new Form<Person>("form"){

			@Override
			protected void onSubmit() {
				System.out.println("clicked submit button, model is " + this.getModel());
			}
        	
        	
        };
        
        add(form);
        form.add(new Button("submit"));

        form.add(new TextField<Person>("name",new PropertyModel<Person>(person,"name")));
    }
}
