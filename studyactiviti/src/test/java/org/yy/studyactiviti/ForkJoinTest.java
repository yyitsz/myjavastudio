package org.yy.studyactiviti;

import java.util.List;

import javax.annotation.Resource;

import junit.framework.Assert;

import org.activiti.engine.RuntimeService;
import org.activiti.engine.runtime.Execution;
import org.activiti.engine.runtime.ProcessInstance;
import org.junit.Test;
import org.junit.runner.RunWith;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;
import org.hamcrest.core.*;
import org.hamcrest.*;
import static org.junit.Assert.assertThat;

@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(locations = "classpath:ActivitiTestCase-context.xml")
public class ForkJoinTest {

	Logger logger = LoggerFactory.getLogger(ForkJoinTest.class);

	@Resource
	private RuntimeService runtimeService;

	@Test
	public void shouldRunConcurrently() throws Exception {
		final ProcessInstance process = runtimeService
				.startProcessInstanceByKey("ForkJoin");
		final String pid = process.getId();
		// ...
		logger.debug("Waiting in Task 0");
		List<String> ids = runtimeService.getActiveActivityIds(pid);
		Assert.assertEquals(1, ids.size());
		Assert.assertTrue(ids.contains("Task_0"));

		List<Execution> executions = runtimeService.createExecutionQuery()
				.processInstanceId(pid).list();
		Assert.assertEquals(1, executions.size());

		logger.debug("Signaling advances to Task A and B concurrently");
		runtimeService.signal(pid);
		ids = runtimeService.getActiveActivityIds(pid);

		Assert.assertEquals(2, ids.size());
		Assert.assertTrue(ids.contains("Task_A"));
		Assert.assertTrue(ids.contains("Task_B"));

		executions = runtimeService.createExecutionQuery().processInstanceId(
				pid).list();
		Assert.assertEquals(3, executions.size());

		final Execution forkA = runtimeService.createExecutionQuery()
				.activityId("Task_A").processInstanceId(pid).singleResult();

		logger.debug(
				"Found forked execution {} in Task A activity for process {}",
				forkA, pid);
		runtimeService.signal(forkA.getId());
		logger.debug("Advanced for A, waiting in Join AB");
		ids = runtimeService.getActiveActivityIds(pid);

		Assert.assertEquals(1, ids.size());
		Assert.assertTrue(ids.contains("Task_B"));

		ids = runtimeService.getActiveActivityIds(forkA.getId());

		Assert.assertEquals(0, ids.size());

		final Execution forkB = runtimeService.createExecutionQuery()
				.activityId("Task_B").processInstanceId(pid).singleResult();

		logger.debug(
				"Found forked execution {} in Task B activity for process {}",
				forkB, pid);
		runtimeService.signal(forkB.getId());
		logger
				.debug("Advanced for B, waiting in concurrent activities B1 and B2");

		ids = runtimeService.getActiveActivityIds(pid);

		Assert.assertEquals(2, ids.size());
		Assert.assertTrue(ids.contains("Task_B1"));
		Assert.assertTrue(ids.contains("Task_B2"));

		// fork B1 and B2
		final Execution forkB1 = runtimeService.createExecutionQuery()
				.activityId("Task_B1").processInstanceId(pid).singleResult();

		Assert.assertNotNull(forkB1);
		ids = runtimeService.getActiveActivityIds(forkB1.getId());

		Assert.assertEquals(1, ids.size());
		Assert.assertTrue(ids.contains("Task_B1"));

		final Execution forkB2 = runtimeService.createExecutionQuery()
				.activityId("Task_B2").processInstanceId(pid).singleResult();

		Assert.assertNotNull(forkB2);
		ids = runtimeService.getActiveActivityIds(forkB2.getId());

		Assert.assertEquals(1, ids.size());
		Assert.assertTrue(ids.contains("Task_B2"));

		logger
				.debug(
						"Found forked executions {} and {} in B1/B2 activities accordingly ",
						forkB1, forkB2);

		runtimeService.signal(forkB1.getId());

		ids = runtimeService.getActiveActivityIds(forkB1.getId());

		Assert.assertEquals(0, ids.size());

		ids = runtimeService.getActiveActivityIds(forkB2.getId());

		Assert.assertEquals(1, ids.size());
		Assert.assertTrue(ids.contains("Task_B2"));

		ids = runtimeService.getActiveActivityIds(forkA.getId());

		Assert.assertEquals(0, ids.size());

		logger.debug("Signalling fork B2 will activate Join AB");

		runtimeService.signal(forkB2.getId());

		Execution exec = runtimeService.createExecutionQuery().executionId(
				forkB1.getId()).singleResult();
		Assert.assertNull(exec);

		exec = runtimeService.createExecutionQuery()
				.executionId(forkB2.getId()).singleResult();
		Assert.assertNull(exec);
		exec = runtimeService.createExecutionQuery().executionId(forkA.getId())
				.singleResult();
		Assert.assertNull(exec);

		ids = runtimeService.getActiveActivityIds(pid);

		Assert.assertEquals(1, ids.size());
		Assert.assertTrue(ids.contains("Task_C"));

		 executions = runtimeService.createExecutionQuery()
				.processInstanceId(pid).list();
		Assert.assertEquals(1, executions.size());
		
		logger.debug("Signalling Task C to finish the process");
		
		runtimeService.signal(pid);
		
		Object instance = runtimeService.createProcessInstanceQuery().processInstanceId(pid).singleResult();
		Assert.assertNull(instance);
	}
}
