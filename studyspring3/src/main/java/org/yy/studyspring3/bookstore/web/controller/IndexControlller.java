package org.yy.studyspring3.bookstore.web.controller;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;

@Controller
public class IndexControlller {
    @RequestMapping("/")
    public String index(){
        return "index";
    }
}
