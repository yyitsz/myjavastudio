package org.yy.studyspring2.web.controller;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.stereotype.Controller;
import org.springframework.ui.ModelMap;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;

@Controller
@RequestMapping("/auth")
public class AuthenticationController {
	protected static Logger logger = LoggerFactory
			.getLogger(AuthenticationController.class);

	@RequestMapping(value = "/login", method = RequestMethod.GET)
	public String getLoginPage(
			@RequestParam(value = "error", required = false) boolean error,
			ModelMap model) {
		logger.debug("received request to show login page.");
		if (error == true) {
			model.put("error",
					"you have entered an invalid username or password!");
		} else {
			model.put("error", "");
		}
		return "loginpage";
	}
	
	@RequestMapping(value="/denied",method=RequestMethod.GET)
	public String getDeniedPage(){
		logger.debug("Received request to show denied page");
		
		return "deniedpage";
	}
}
