package org.yy.studyesper;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.junit.Before;
import org.junit.Test;
import org.yy.studyesper.eventbean.DeleteStockTick;
import org.yy.studyesper.eventbean.LimitAlert;
import org.yy.studyesper.eventbean.PriceLimit;
import org.yy.studyesper.eventbean.StockTick;

import com.espertech.esper.client.Configuration;
import com.espertech.esper.client.EPServiceProvider;
import com.espertech.esper.client.EPServiceProviderManager;
import com.espertech.esper.client.EPStatement;
import com.espertech.esper.client.EventBean;
import com.espertech.esper.client.UpdateListener;
import com.espertech.esper.client.time.TimerControlEvent;

public class TestStockTickerSimple extends EsperTestBase{
	EPServiceProvider epService;

	//@Before
	public void setUp() throws Exception {

		Configuration configuration = new Configuration();
		// configuration.addEventTypeAutoName("org.yy.studyesper.eventbean");
		configuration.addEventType("PriceLimit", PriceLimit.class.getName());
		configuration.addEventType("StockTick", StockTick.class.getName());

		epService = EPServiceProviderManager.getProvider(
				"TestStockTickerSimple", configuration);
		// epService.getEPRuntime().addEmittedListener(listener, null);

		// statement.addListener(listener);
		// To reduce logging noise and get max performance
		epService.getEPRuntime().sendEvent(
				new TimerControlEvent(
						TimerControlEvent.ClockType.CLOCK_EXTERNAL));
	}

	//@Test
	public void testStockTicker() throws Exception {
		log.info(".testStockTicker");
		String eplStatement = "every tick=StockTick()";
		EPStatement statement = epService.getEPAdministrator().createPattern(
				eplStatement);
		statement.addListener(new UpdateListener(){

			public void update(EventBean[] newEvents, EventBean[] oldEvents) {
				Object tick = newEvents[0].get("tick");
				log.debug(tick);
				
			}});
		
		epService.getEPRuntime().sendEvent(new StockTick("ABC",20d));
		
		epService.getEPRuntime().sendEvent(new StockTick("ABC",20.1d));
		epService.getEPRuntime().sendEvent(new StockTick("ABC",20.2d));
	}
	
	@Test
	public void test1(){
		EPServiceProvider ep = CreateEpServiceProvider();
		EPStatement statement = ep.getEPAdministrator().createEPL("select * from StockTick(price<23)");
		statement.addListener(new UpdateListener(){

			@Override
			public void update(EventBean[] arg0, EventBean[] arg1) {
				log.info("Message Type:" + arg0[0].getEventType().toString());
				
				log.info("Recevied Message" + arg0[0].getUnderlying().toString());
				
				log.info("Recevied Message's Symbol:" + arg0[0].get("stockSymbol"));
				
			}});
		log.info("send first message.");
		ep.getEPRuntime().sendEvent(new StockTick("IBM",23.23));
		log.info("send second mesage.");
		ep.getEPRuntime().sendEvent(new StockTick("IBM",22.99));
		ep.destroy();
	}

	@Test
	public void testPatternBase(){
		EPServiceProvider ep = CreateEpServiceProvider();
		//EPStatement statement = ep.getEPAdministrator().createPattern("every(s=StockTick(price<23))");
		EPStatement statement = ep.getEPAdministrator().createEPL("select s.* from pattern [every(s=StockTick(price<23))]");
		statement.addListener(new PrintUpdateListener());
		log.info("send first message.");
		ep.getEPRuntime().sendEvent(new StockTick("IBM",23.23));
		log.info("send second mesage.");
		ep.getEPRuntime().sendEvent(new StockTick("IBM",20.99));
		ep.destroy();
	}
	
	@Test
	public void testPattern1(){
		EPServiceProvider ep = CreateEpServiceProvider();
		EPStatement statement = ep.getEPAdministrator().createEPL("select s, pl  from pattern [every s=StockTick(price<100) -> pl=PriceLimit]");
		statement.addListener(new PrintUpdateListener());
		ep.getEPRuntime().sendEvent(new StockTick("IBM",23.23));
		ep.getEPRuntime().sendEvent(new StockTick("INTEL",20.99));
		ep.getEPRuntime().sendEvent(new PriceLimit("YY", "IBM", 20));
		ep.destroy();
	}
	
	@Test
	public void testPattern2(){
		EPServiceProvider ep = CreateEpServiceProvider();
		EPStatement statement = ep.getEPAdministrator().createEPL("select s, pl  from pattern [every s=StockTick(price<100) -> pl=PriceLimit and not DeleteStockTick(stockSymbol = s.stockSymbol)]");
		statement.addListener(new PrintUpdateListener());
		ep.getEPRuntime().sendEvent(new StockTick("IBM",23.23));
		ep.getEPRuntime().sendEvent(new StockTick("INTEL",20.99));
		ep.getEPRuntime().sendEvent(new DeleteStockTick("IBM"));
		ep.getEPRuntime().sendEvent(new PriceLimit("YY", "IBM", 20));
		ep.destroy();
	}
	
	@Test
	public void testPattern3(){
		EPServiceProvider ep = CreateEpServiceProvider();

		EPStatement statement = ep.getEPAdministrator().createEPL("select s1, s2  from pattern [every s1=StockTick(stockSymbol='IBM') and s2=StockTick(price > 9)]");
		statement.addListener(new PrintUpdateListener());
		ep.getEPRuntime().sendEvent(new StockTick("IBM",23.23));
		ep.getEPRuntime().sendEvent(new StockTick("IBM",10));
		ep.getEPRuntime().sendEvent(new StockTick("IBM",100));
		ep.getEPRuntime().sendEvent(new StockTick("INTEL",20.99));

		ep.destroy();
	}
	
	@Test
	public void testPatternConsume(){
		EPServiceProvider ep = CreateEpServiceProvider();

		EPStatement statement = ep.getEPAdministrator().createEPL("select s1, s2  from pattern [every s1=StockTick(stockSymbol='IBM')@consume and s2=StockTick(price > 9)]");
		statement.addListener(new PrintUpdateListener());
		ep.getEPRuntime().sendEvent(new StockTick("INTEL",20.99));
		ep.getEPRuntime().sendEvent(new StockTick("IBM",23.23));
		ep.getEPRuntime().sendEvent(new StockTick("IBM",10));
		ep.getEPRuntime().sendEvent(new StockTick("IBM",100));
		

		ep.destroy();
	}
	
	
	private static final Log log = LogFactory
			.getLog(TestStockTickerSimple.class);
	
	
}