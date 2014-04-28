package org.yy.service.impl;

/**
 * Created by chinanet on 2014/4/27.
 */
public class TestServiceImpl implements org.yy.service.TestService {
    @Override
    public String genHello(String name) {
        return "Hello, " + name;
    }
}
