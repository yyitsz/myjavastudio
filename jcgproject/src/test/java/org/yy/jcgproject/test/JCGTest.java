package org.yy.jcgproject.test;

import junit.framework.TestCase;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import org.yy.jcgproject.domain.MyEntity;
import org.yy.jcgproject.drools.MyDomain;
import org.yy.jcgproject.jms.MyQueueSender;
import org.yy.jcgproject.service.ActivitiService;
import org.yy.jcgproject.service.DroolsService;
import org.yy.jcgproject.service.MyEntityService;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(locations={"classpath*:META-INF/spring/applicationContext*.xml"})
public class JCGTest extends TestCase {
	@Autowired
	private MyEntityService myEntityService;
	
	@Autowired
	private ActivitiService activitiService;
	
	@Autowired
	private DroolsService droolsService;
	
	@Autowired
	private MyQueueSender myQueueSender;
	
	@Test
	public void testMyEntity() {
		MyEntity entity = new MyEntity();
		entity.setName("test");
		myEntityService.persist(entity);

	}
	
	@Test
	public void testActiviti() {
		activitiService.startProcess();
	}
	
	@Test
	public void testDrools() {
		MyDomain domain = new MyDomain();
		domain.setName("test");
		domain.setLastName("test");
		droolsService.executeRules(domain);
		assertEquals("description ",domain.getDescription(),"set name=[jcg] and lastName =[jcg] to become a geek!!!");
	}

	@Test
	public void testJMS() {
		myQueueSender.sendMessage("test");
	}
}
