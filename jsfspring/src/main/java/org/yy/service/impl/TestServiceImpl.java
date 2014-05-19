package org.yy.service.impl;

import org.springframework.stereotype.Service;
import org.yy.service.TestService;

/**
 * Created by chinanet on 2014/4/27.
 */
@Service
public class TestServiceImpl implements TestService {
    @Override
    public String genHello(String name) {
        return "Hello, " + name;
    }
}
