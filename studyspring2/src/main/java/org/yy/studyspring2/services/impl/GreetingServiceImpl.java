package org.yy.studyspring2.services.impl;

import javax.annotation.Resource;

import org.springframework.beans.factory.InitializingBean;
import org.springframework.stereotype.Service;
import org.springframework.transaction.PlatformTransactionManager;
import org.springframework.transaction.annotation.Transactional;
import org.yy.studyspring2.services.GreetingService;


//@Service("greetingService")
public class GreetingServiceImpl implements GreetingService, InitializingBean{
	
	PlatformTransactionManager txManager;
	
	
	@Resource
	public void setTxManager(PlatformTransactionManager txManager) {
		this.txManager = txManager;
	}

	@Transactional
	public String sayHello() {

		return "Hello from Greeting Service.";

	}

	public void afterPropertiesSet() throws Exception {
		System.out.println("Called back.");
		
	}
}
