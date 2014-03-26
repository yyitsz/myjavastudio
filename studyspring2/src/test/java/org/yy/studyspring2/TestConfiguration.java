package org.yy.studyspring2;

import org.junit.Test;
import org.springframework.context.annotation.AnnotationConfigApplicationContext;
import org.springframework.util.Assert;
import org.yy.studyspring2.config.AppConfig;
import org.yy.studyspring2.config.TestObject;
import org.yy.studyspring2.config.TestObject2;


public class TestConfiguration {
	@Test
	public void test2()
	{
		AnnotationConfigApplicationContext ctx = new org.springframework.context.annotation.AnnotationConfigApplicationContext();
		ctx.register(AppConfig.class);
		ctx.refresh();
		TestObject obj = ctx.getBean("testObject", TestObject.class);
		TestObject2 obj2 = ctx.getBean("testObject2", TestObject2.class);
		Assert.notNull(obj);
		Assert.notNull(obj2);
		Assert.isTrue(obj.getObj2() == obj2);
	}
}
