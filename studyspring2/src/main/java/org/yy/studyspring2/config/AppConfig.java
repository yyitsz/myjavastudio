package org.yy.studyspring2.config;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.yy.studyspring2.services.GreetingService;
import org.yy.studyspring2.services.impl.GreetingServiceImpl;



@Configuration
public class AppConfig {
	

	
	@Bean
	public TestFactoryBean testObject()
	{
		return new TestFactoryBean();
	}
	
	@Bean public TestObject2 testObject2() throws Throwable
	{
		return testObject().getObject().getObj2();
	}
	/*@Bean	
	public GreetingService greetingService()
	{
		return new GreetingServiceImpl();
	}
*/
}
