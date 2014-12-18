package org.yy;

import org.yy.service.TestService;

import javax.enterprise.context.RequestScoped;
import javax.faces.bean.ManagedBean;
import javax.faces.bean.SessionScoped;
import javax.inject.Inject;
import javax.inject.Named;
import javax.inject.Scope;
import java.io.Serializable;

@Named
@RequestScoped
//@ManagedBean
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