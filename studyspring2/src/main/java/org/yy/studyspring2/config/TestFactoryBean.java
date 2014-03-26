package org.yy.studyspring2.config;

import org.springframework.beans.BeansException;
import org.springframework.beans.factory.FactoryBean;
import org.springframework.beans.factory.InitializingBean;
import org.springframework.context.ApplicationContext;
import org.springframework.context.ApplicationContextAware;

public class TestFactoryBean implements FactoryBean<TestObject> , ApplicationContextAware,
InitializingBean{

	ApplicationContext applicationContext;
	
	public TestObject getObject() throws Exception {
		System.out.println("Get Object.");
		return new TestObject();
	}

	public Class<?> getObjectType() {
		// TODO Auto-generated method stub
		return TestObject.class;
	}

	public boolean isSingleton() {
		// TODO Auto-generated method stub
		return true;
	}

	public void setApplicationContext(ApplicationContext applicationContext)
			throws BeansException {
		this.applicationContext = applicationContext;
		System.out.println("Set Application Context.");
		
	}

	public void afterPropertiesSet() throws Exception {
		System.out.println("Initializing TestFactoryBean.");
		
	}

}
