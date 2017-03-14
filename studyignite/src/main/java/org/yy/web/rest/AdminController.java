package org.yy.web.rest;

import jdk.nashorn.internal.ir.annotations.Ignore;
import org.apache.ignite.IgniteSpringBean;
import org.apache.ignite.lang.IgniteRunnable;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;
import org.yy.core.risk.service.RiskServer;
import org.yy.core.risk.task.CalcTask;

import javax.annotation.Resource;
import javax.servlet.http.HttpServletRequest;

/**
 * Created by yyi on 2017/3/14.
 */
@Controller//("/admin")
@RequestMapping(path = "/admin")
public class AdminController {

    @Resource
    private IgniteSpringBean ignite;

    @RequestMapping(path = "/test/{name}")
    @ResponseBody
    public String test(@PathVariable("name") String name, HttpServletRequest request) {
        return "hello " + name + ", counter: " + request.getSession().getAttribute("counter");
    }

    @RequestMapping(path = "/calc/{v1}/{v2}")
    @ResponseBody
    public long calc(@PathVariable("v1") Long v1, @PathVariable("v2") Long v2) {
        Long call = ignite.compute().call(new CalcTask(v1, v2));
        return call;
    }
}
