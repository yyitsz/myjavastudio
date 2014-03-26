package org.yy.studyspring2.web.controller;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import org.springframework.web.servlet.ModelAndView;
import org.springframework.web.servlet.mvc.AbstractController;
import org.yy.studyspring2.model.Member;

public class SpringMvcController extends AbstractController {

	@Override
	protected ModelAndView handleRequestInternal(HttpServletRequest request,
			HttpServletResponse response) throws Exception {
		ModelAndView mview = new ModelAndView("springmvc");
		mview.addObject("greeting", "Greetings from SpringMvc");
		mview.addObject("member1",new Member("Abc","Xu", "Shenzhen","132232"));
		return mview;
	}

}
