package org.yy;

import org.yy.service.TestService;

import javax.inject.Inject;
import javax.inject.Named;
import java.io.Serializable;

@Named
@org.springframework.context.annotation.Scope("request")
public class HelloBean implements Serializable {

    @Inject
    private TestService testService;

    private static final long serialVersionUID = 1L;

    private String name;

    public String getName() {
        return name;
    }
    public void setName(String name) {
        this.name = name;
    }

    public void welcome(){

    }

    public String getWelcomeWord(){
        return testService.genHello(this.name);
    }
}