package org.yy.studyesper;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.junit.Test;
import org.yy.studyesper.EsperTestBase.PrintUpdateListener;

import com.espertech.esper.client.EPServiceProvider;
import com.espertech.esper.client.EPStatement;

public class EsperPatternTest extends EsperTestBase {
	private static final Log log = LogFactory.getLog(EsperPatternTest.class);
	
	@Test
	public void AFollowByBTest(){
		//every (A -> B)
		EPServiceProvider epServiceProvider = CreateEpServiceProvider();
		EPStatement statement = epServiceProvider.getEPAdministrator().createEPL("select a, b from pattern [every (a=A -> b=B)]");
		statement.addListener(new PrintUpdateListener());
		
		sendSerialEvents(epServiceProvider);
		epServiceProvider.destroy();
	}

	@Test
	public void AFollowByBTest2(){
		//every (A -> B)
		EPServiceProvider epServiceProvider = CreateEpServiceProvider();
		EPStatement statement = epServiceProvider.getEPAdministrator().createEPL("select a, b from pattern [every a=A -> b=B]");
		statement.addListener(new PrintUpdateListener());
		
		sendSerialEvents(epServiceProvider);
		epServiceProvider.destroy();
	}
	
	@Test
	public void AFollowByBTest3(){
		log.info("--------- Test select a, b from pattern [a=A -> every b=B]");
		EPServiceProvider epServiceProvider = CreateEpServiceProvider();
		EPStatement statement = epServiceProvider.getEPAdministrator().createEPL("select a, b from pattern [a=A -> every b=B]");
		statement.addListener(new PrintUpdateListener());
		
		sendSerialEvents(epServiceProvider);
		epServiceProvider.destroy();
	}
	
	@Test
	public void AFollowByBTest4(){
		log.info("--------- Test select a, b from pattern [every a=A -> every b=B]");
		EPServiceProvider epServiceProvider = CreateEpServiceProvider();
		EPStatement statement = epServiceProvider.getEPAdministrator().createEPL("select a, b from pattern [every a=A -> every b=B]");
		statement.addListener(new PrintUpdateListener());
		
		sendSerialEvents(epServiceProvider);
		epServiceProvider.destroy();
	}
	
	@Test
	public void AFollowByBTest5(){
		log.info("--------- Test select a, b from pattern [every a=A -> b=B and not A]");
		EPServiceProvider epServiceProvider = CreateEpServiceProvider();
		EPStatement statement = epServiceProvider.getEPAdministrator().createEPL("select a, b from pattern [every a=A -> b=B and not A]");
		statement.addListener(new PrintUpdateListener());
		
		sendEvents(epServiceProvider.getEPRuntime(), new A("A1"),new B("B1"), new C("C1"), new A("A2-0"),  new A("A2"),  new D("D1"),
				new A("A3"), new B("B3"), new E("E1"), new A("A4"), new B("B4"));
		epServiceProvider.destroy();
		//when A2 arrived, A2-0 subexpression will be ended. But A2 will activate a new subexpression, and A3 also end A2 subexpression, then 
		//create a new subexpression.s
	}
	
	@Test
	public void every_timer_followby_test() throws Exception{
		log.info("--------- Test select b from pattern [every timer:interval(1 sec) -> b=B]");
		EPServiceProvider epServiceProvider = CreateEpServiceProvider();
		EPStatement statement = epServiceProvider.getEPAdministrator().createEPL("select b from pattern [every timer:interval(1 sec) -> b=B]");
		statement.addListener(new PrintUpdateListener());
		
		Thread.sleep(5000);
		epServiceProvider.getEPRuntime().sendEvent(new B("B1"));
		
		epServiceProvider.destroy();
		//after 5s, output five events.
	}
	
	@Test
	public void repeat_test() throws Exception{
		log.info("--------- Test select a from pattern [[2]a=A]");
		EPServiceProvider epServiceProvider = CreateEpServiceProvider();
		EPStatement statement = epServiceProvider.getEPAdministrator().createEPL("select a from pattern [[2]a=A]");
		statement.addListener(new PrintUpdateListener());
		
		
		epServiceProvider.getEPRuntime().sendEvent(new A("A1"));
		epServiceProvider.getEPRuntime().sendEvent(new A("A2"));
		//epServiceProvider.getEPRuntime().sendEvent(new B("B1"));
		epServiceProvider.getEPRuntime().sendEvent(new A("A3"));
		epServiceProvider.getEPRuntime().sendEvent(new A("A4"));
		
		epServiceProvider.destroy();
		//after 5s, output five events.
	}
	
	@Test
	public void repeat_util_test() throws Exception{
		log.info("--------- Test select a from pattern [ a=A until B]");
		EPServiceProvider epServiceProvider = CreateEpServiceProvider();
		EPStatement statement = epServiceProvider.getEPAdministrator().createEPL("select a,b from pattern [ [2:3]a=A until b=B]");
		statement.addListener(new PrintUpdateListener());
		
		
		epServiceProvider.getEPRuntime().sendEvent(new A("A1"));
		epServiceProvider.getEPRuntime().sendEvent(new A("A2"));
		//epServiceProvider.getEPRuntime().sendEvent(new B("B1"));
		epServiceProvider.getEPRuntime().sendEvent(new A("A3"));
		epServiceProvider.getEPRuntime().sendEvent(new A("A4"));
		epServiceProvider.getEPRuntime().sendEvent(new B("B2"));
		
		epServiceProvider.destroy();
		//after 5s, output five events.
	}
	
	@Test
	public void not_test() throws Exception{
		log.info("--------- Test select a from pattern [ (ervery a=A ->b= B) and not C]");
		EPServiceProvider epServiceProvider = CreateEpServiceProvider();
		EPStatement statement = epServiceProvider.getEPAdministrator().createEPL("select a,b from pattern [ (every a=A -> b=B) and not C]");
		statement.addListener(new PrintUpdateListener());
		
		epServiceProvider.getEPRuntime().sendEvent(new C("C1"));
		epServiceProvider.getEPRuntime().sendEvent(new A("A1"));
		epServiceProvider.getEPRuntime().sendEvent(new A("A2"));
		epServiceProvider.getEPRuntime().sendEvent(new B("B1"));
		epServiceProvider.getEPRuntime().sendEvent(new A("A3"));
		epServiceProvider.getEPRuntime().sendEvent(new A("A4"));
		epServiceProvider.getEPRuntime().sendEvent(new B("B2"));
		
		epServiceProvider.destroy();
		//after 5s, output five events.
	}
	
	@Test
	public void not_test3() throws Exception{
		log.info("--------- Test select a from pattern [ every a=A -> (b= B or not C)]");
		EPServiceProvider epServiceProvider = CreateEpServiceProvider();
		EPStatement statement = epServiceProvider.getEPAdministrator().createEPL("select a,b from pattern [ every a=A -> (b= B or not C)]");
		statement.addListener(new PrintUpdateListener());
		
		epServiceProvider.getEPRuntime().sendEvent(new C("C1"));
		epServiceProvider.getEPRuntime().sendEvent(new A("A1"));
		epServiceProvider.getEPRuntime().sendEvent(new A("A2"));
		epServiceProvider.getEPRuntime().sendEvent(new D("D1"));
		epServiceProvider.getEPRuntime().sendEvent(new B("B1"));
		epServiceProvider.getEPRuntime().sendEvent(new A("A3"));
		epServiceProvider.getEPRuntime().sendEvent(new A("A4"));
		epServiceProvider.getEPRuntime().sendEvent(new B("B2"));
		
		epServiceProvider.destroy();
		//after 5s, output five events.
	}
	
	@Test
	public void not_test2() throws Exception{
		log.info("--------- Test select a from pattern [ ervery a=A -> b= B and not C]");
		EPServiceProvider epServiceProvider = CreateEpServiceProvider();
		EPStatement statement = epServiceProvider.getEPAdministrator().createEPL("select a,b from pattern [ every a=A -> b=B and not C]");
		statement.addListener(new PrintUpdateListener());
		
		epServiceProvider.getEPRuntime().sendEvent(new C("C1"));
		epServiceProvider.getEPRuntime().sendEvent(new A("A1"));
		epServiceProvider.getEPRuntime().sendEvent(new A("A2"));
		epServiceProvider.getEPRuntime().sendEvent(new B("B1"));
		epServiceProvider.getEPRuntime().sendEvent(new A("A3"));
		epServiceProvider.getEPRuntime().sendEvent(new C("C1"));
		epServiceProvider.getEPRuntime().sendEvent(new A("A4"));
		epServiceProvider.getEPRuntime().sendEvent(new B("B2"));
		
		epServiceProvider.destroy();
		//after 5s, output five events.
	}
	
	@Test
	public void guard_test() throws Exception{
		log.info("--------- Test select a from pattern [ every a=A where timer:within(2 sec)]");
		EPServiceProvider epServiceProvider = CreateEpServiceProvider();
		EPStatement statement = epServiceProvider.getEPAdministrator().createEPL("select a from pattern [ (every a=A) where timer:within(3 sec)]");
		statement.addListener(new PrintUpdateListener());
		
		sendEvents(epServiceProvider.getEPRuntime(),new C("C1"),
		new A("A1"));
		Thread.sleep(1000);
		sendEvents(epServiceProvider.getEPRuntime(),new A("A2"),new B("B1"));
		
		Thread.sleep(1000);
		sendEvents(epServiceProvider.getEPRuntime(),new A("A3"),new B("B2"));
		Thread.sleep(3000);
		sendEvents(epServiceProvider.getEPRuntime(),new B("B3"),new C("C1"));
		Thread.sleep(1000);
		sendEvents(epServiceProvider.getEPRuntime(),new A("A4"),new B("B3"));
		
		
		epServiceProvider.destroy();
		//after 5s, output five events.
	}
	@Test
	public void guard_test2() throws Exception{
		log.info("--------- Test select a,b from pattern [ every ((a=A and b=B) where timer:within(3 sec))]");
		EPServiceProvider epServiceProvider = CreateEpServiceProvider();
		EPStatement statement = epServiceProvider.getEPAdministrator().createEPL("select a,b from pattern [ every ((a=A and b=B) where timer:within(3 sec))]");
		statement.addListener(new PrintUpdateListener());
		
		sendEvents(epServiceProvider.getEPRuntime(),new C("C1"),
		new A("A1"));
		Thread.sleep(1000);
		sendEvents(epServiceProvider.getEPRuntime(),new A("A2"),new B("B1"));
		sendEvents(epServiceProvider.getEPRuntime(),new A("A2-0"),new B("B1-0"));
		Thread.sleep(1000);
		sendEvents(epServiceProvider.getEPRuntime(),new A("A2-1"),new B("B1-1"));
		sendEvents(epServiceProvider.getEPRuntime(),new A("A3"),new D("D1"));
		Thread.sleep(3000);
		sendEvents(epServiceProvider.getEPRuntime(),new B("B3"),new C("C1"));
		Thread.sleep(1000);
		sendEvents(epServiceProvider.getEPRuntime(),new A("A4"),new B("B3"));
		
		
		epServiceProvider.destroy();
		//after 5s, output five events.
	}
	private void sendSerialEvents(EPServiceProvider epServiceProvider) {
		sendEvents(epServiceProvider.getEPRuntime(), new A("A1"),new B("B1"), new C("C1"), new B("B2"), new A("A2"), new D("D1"),
				new A("A3"), new B("B3"), new E("E1"), new A("A4"), new B("B4"));
	}
}
