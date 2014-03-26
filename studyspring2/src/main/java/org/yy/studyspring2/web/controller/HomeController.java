package org.yy.studyspring2.web.controller;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;

@Controller
public class HomeController {
	@RequestMapping(value="/index")
	public String index(){
		
		return "homeindex";
	}
}
