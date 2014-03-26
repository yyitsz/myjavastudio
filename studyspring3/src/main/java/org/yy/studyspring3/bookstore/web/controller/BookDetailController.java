package org.yy.studyspring3.bookstore.web.controller;

import java.util.List;

import javax.servlet.http.HttpServletRequest;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.yy.studyspring3.bookstore.domain.Book;
import org.yy.studyspring3.bookstore.service.BookSearchCriteria;
import org.yy.studyspring3.bookstore.service.BookstoreService;

@Controller
public class BookDetailController {
    
    @Autowired
    private BookstoreService bookstoreService;
    
    
    @RequestMapping(value = "/book/detail/{bookid}")
    public String details(@PathVariable("bookid") long bookId, Model model){
        Book book = bookstoreService.findBook(bookId); 
        model.addAttribute(book);
        return "book/detail";
    }
}
