package org.yy;

import org.antlr.stringtemplate.StringTemplate;
import org.junit.Test;

public class StringTemplateTest {
	@Test
	public void test1() {
		StringTemplate query = new StringTemplate("SELECT $column; separator=\",\"$ FROM $table$");
		query.setAttribute("column", "name");
		query.setAttribute("table","User");
		query.setAttribute("column", "email");

		System.out.println(query.toString());
	}
}
