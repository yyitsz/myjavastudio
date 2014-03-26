package org.yy.studywicket;

import org.apache.wicket.markup.html.WebPage;
import org.apache.wicket.markup.html.basic.Label;
import org.apache.wicket.markup.html.link.BookmarkablePageLink;

public class BasePage extends WebPage{

	public BasePage() {
		super();
		add(new BookmarkablePageLink("page1", HomePage.class));
		add(new BookmarkablePageLink("page2", Page2.class));
		add(new BookmarkablePageLink("page3", Page3.class));
		add(new Label("footer", "This is in the footer"));
	}

}
