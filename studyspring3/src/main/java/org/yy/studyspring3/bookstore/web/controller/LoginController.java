package org.yy.studyspring3.bookstore.web.controller;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.servlet.mvc.support.RedirectAttributes;
import org.yy.studyspring3.bookstore.domain.Account;
import org.yy.studyspring3.bookstore.service.AccountService;
import org.yy.studyspring3.bookstore.service.AuthenticationException;

@Controller
@RequestMapping("/login")
public class LoginController {
    public static String ACCOUNT_ATTRIBUTE = "account";
    @Autowired
    private AccountService accountService;

    @RequestMapping(method = RequestMethod.GET)
    public String login() {
        return "login";
    }

    //@RequestMapping(method = RequestMethod.POST)
    public String handleLogin(HttpServletRequest request, HttpSession session) {
        try {
            String username = request.getParameter("username");
            String password = request.getParameter("password");
            Account account = accountService.login(username, password);
            session.setAttribute(ACCOUNT_ATTRIBUTE, account);
            return "redirect:/index.htm";
        } catch (AuthenticationException ex) {
            request.setAttribute("exception", ex);
            return "login";
        }
    }
    
    //@RequestMapping(method = RequestMethod.POST)
    public String handleLogin2(@RequestParam String username, @RequestParam String password
            , HttpServletRequest request, HttpSession session) {
        try {

            Account account = accountService.login(username, password);
            session.setAttribute(ACCOUNT_ATTRIBUTE, account);
            return "redirect:/index.htm";
        } catch (AuthenticationException ex) {
            request.setAttribute("exception", ex);
            return "login";
        }
    }
    
    @RequestMapping(method = RequestMethod.POST)
    public String handleLoginSupportBack(@RequestParam String username, @RequestParam String password
            , RedirectAttributes redirect, HttpSession session) {
        try {

            Account account = accountService.login(username, password);
            session.setAttribute(ACCOUNT_ATTRIBUTE, account);
            return "redirect:/index.htm";
        } catch (AuthenticationException ex) {
            redirect.addFlashAttribute("exception", ex);
            return "redirect:/login";
        }
    }
}
