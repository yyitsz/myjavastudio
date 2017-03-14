package org.yy.web.rest;

import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;

import javax.servlet.http.HttpServletRequest;

/**
 * Created by yyi on 2017/3/14.
 */
@Controller//("/admin")
@RequestMapping(path = "/admin")
public class AdminController {
    @RequestMapping(path = "/test/{name}")
    @ResponseBody
    public String test(@PathVariable("name") String name,HttpServletRequest request) {
        return "hello " + name + ", counter: " + request.getSession().getAttribute("counter");
    }
}
