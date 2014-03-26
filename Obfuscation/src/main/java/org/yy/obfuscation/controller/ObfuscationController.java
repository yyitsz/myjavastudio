package org.yy.obfuscation.controller;

import java.util.ArrayList;
import java.util.List;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.servlet.ModelAndView;
import org.yy.obfuscation.model.Profile;

@Controller
public class ObfuscationController {
	@RequestMapping("/index")
	public ModelAndView index(){
		ModelAndView mv = new ModelAndView("index");
		mv.addObject("profile", new Profile());
		List<String> assemblies = new ArrayList<String>();
		
		assemblies.add("Basic");
		assemblies.add("Common");
		
		mv.addObject("assemblies", assemblies);
		
		return mv;
	}
	
	@RequestMapping("/executeObfuscation")
	public ModelAndView executeObfuscation(@ModelAttribute("profile") Profile profile){
		ModelAndView mv = new ModelAndView("index");
		String message = profile.toString();
		mv.addObject("profile", profile);
		List<String> assemblies = new ArrayList<String>();
		
		assemblies.add("Basic");
		assemblies.add("Common");
		
		mv.addObject("assemblies", assemblies);
		mv.addObject("message", message);
		return mv;
	}
}
