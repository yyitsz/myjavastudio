package org.yy.web.rest;

import jdk.nashorn.internal.ir.annotations.Ignore;
import org.apache.ignite.IgniteSpringBean;
import org.apache.ignite.lang.IgniteRunnable;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;
import org.yy.core.model.Person;
import org.yy.core.risk.service.PersonService;
import org.yy.core.risk.service.RiskServer;
import org.yy.core.risk.service.SystemParameterService;
import org.yy.core.risk.task.CalcTask;
import org.yy.core.risk.task.IgniteCallableWrapper;
import org.yy.core.risk.task.Tuple;

import javax.annotation.Resource;
import javax.servlet.http.HttpServletRequest;
import java.time.LocalDate;
import java.time.LocalDateTime;
import java.util.List;

/**
 * Created by yyi on 2017/3/14.
 */
@Controller//("/admin")
@RequestMapping(path = "/admin")
public class AdminController {

    @Resource
    private IgniteSpringBean ignite;
    @Resource
    private PersonService personService;

    @Resource
    private SystemParameterService systemParameterService;

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

    @RequestMapping(path = "/calc2/{v1}/{v2}")
    @ResponseBody
    public long calc2(@PathVariable("v1") final Long v1, @PathVariable("v2") final Long v2) {
        Tuple<Long, Long> tuple = new Tuple<>(v1, v2);
        Long call = ignite.compute().call(new IgniteCallableWrapper<Tuple<Long, Long>, Long>(tuple) {

            @Override
            public Long call() throws Exception {
                Tuple<Long, Long> param = getParam();
                return getRiskServer().calc(param.getFirst(), param.getSecond());
            }
        });
        return call;
    }

    @RequestMapping(path = "/getparam/{param}")
    @ResponseBody
    public String getParam(@PathVariable("param") final String param) {

        return systemParameterService.getIp(param);
    }

    @RequestMapping(path = "/updateparam/{param}")
    @ResponseBody
    public void updateParam(@PathVariable("param") final String param) {

        systemParameterService.setIp(param, "any");
    }

    @RequestMapping(path = "/person/add")
    @ResponseBody
    public String addPerson(@RequestParam("firstName") final String firstName, @RequestParam("lastName") final String lastName) {

        Person p = new Person();
        p.setFirstName(firstName);
        p.setLastName(lastName);
        p.setCreateTime(LocalDateTime.now());
        p.setRegisterDate(LocalDate.now());
        personService.addPerson(p);
        return p.toString();
    }

    @RequestMapping(path = "/person/getall")
    @ResponseBody
    public  List<Person> getAllPersons() {

        List<Person> persons = personService.getAllPerson();
        return persons;
    }
}
