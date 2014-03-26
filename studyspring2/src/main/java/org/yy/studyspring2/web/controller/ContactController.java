package org.yy.studyspring2.web.controller;

import java.util.Map;

import javax.annotation.Resource;

import org.springframework.stereotype.Controller;
import org.springframework.validation.BindingResult;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.servlet.ModelAndView;
import org.yy.studyspring2.model.Contact;
import org.yy.studyspring2.services.ContactService;

@Controller
//@SessionAttributes
public class ContactController {
	
	@Resource
	private ContactService contactService;
	@RequestMapping("/contact/index")
	public String listContacts(Map<String,Object> map){
		map.put("contact", new Contact());
		map.put("contactList", contactService.listContact());
		
		return "contact";
	}
	@RequestMapping(value="/contact/add",method=RequestMethod.POST)
	public String addContact(@ModelAttribute("contact") Contact contact, BindingResult result){
		contactService.addContact(contact);
		return "redirect:/contact/index.html";
	}
	@RequestMapping(value="/contact/delete/{contactId}")
	public String deleteContact(@PathVariable("contactId")Integer contactId){
		contactService.removeContact(contactId);
		return "redirect:/contact/index.html";
	}
	@RequestMapping(value="/contacts")
	public ModelAndView showContacts(){
		
		return new ModelAndView("contact", "contact", new Contact());
	}
}
