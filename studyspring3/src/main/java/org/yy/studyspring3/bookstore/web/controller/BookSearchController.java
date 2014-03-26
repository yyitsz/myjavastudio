package org.yy.studyspring3.bookstore.web.controller;

import java.util.List;

import javax.servlet.http.HttpServletRequest;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.yy.studyspring3.bookstore.domain.Book;
import org.yy.studyspring3.bookstore.service.BookSearchCriteria;
import org.yy.studyspring3.bookstore.service.BookstoreService;

@Controller
public class BookSearchController {
    
    @Autowired
    private BookstoreService bookstoreService;
    
    @RequestMapping(value = "/book/search", method=RequestMethod.GET)
    public String init(){
       
        return "book/search";
    }
    
    //@RequestMapping(value = "/book/search", method=RequestMethod.POST)
    public String search(Model model, HttpServletRequest request){
        String title = request.getParameter("title");
        BookSearchCriteria criteria = new BookSearchCriteria();
        criteria.setTitle(title);
        List<Book> bookList = bookstoreService.search(criteria); 
        model.addAttribute(bookList);
        return "book/search";
    }
    
    @RequestMapping(value = "/book/search", method=RequestMethod.POST)
    public String list(Model model, BookSearchCriteria criteria){
        List<Book> bookList = bookstoreService.search(criteria); 
        model.addAttribute(bookList);
        return "book/search";
    }
}
