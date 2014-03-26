package org.yy.studyesper;

import java.util.Iterator;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.junit.After;
import org.junit.Before;
import org.junit.Ignore;
import org.junit.Test;
import org.yy.studyesper.eventbean.PriceLimit;
import org.yy.studyesper.eventbean.StockTick;
import org.yy.studyesper.fw.EpsEventBean;
import org.yy.studyesper.fw.EpsListener;
import org.yy.studyesper.fw.EpsManager;
import org.yy.studyesper.fw.EpsStatement;
import org.yy.studyesper.fw.esper.EsperEpsManager;

import com.espertech.esper.client.Configuration;
import com.espertech.esper.client.EPServiceProvider;
import com.espertech.esper.client.EPServiceProviderManager;
import com.espertech.esper.client.EPStatement;
import com.espertech.esper.client.EventBean;
import com.espertech.esper.client.UpdateListener;
import com.espertech.esper.client.time.TimerControlEvent;

public class TestStockTickerSimple2 {
	private EpsManager epService;
	
	private static final Log log = LogFactory
			.getLog(TestStockTickerSimple2.class);
	
	@Before
	public void setUp() throws Exception {

		EsperEpsManager esperService = new EsperEpsManager();
		esperService.setProviderUri("test");
		epService = esperService;
		epService.init();

	}

	@After
	public void teardown(){
		epService.destroy();
	}
	
	@Test
	@Ignore
	public void testStockTicker() throws Exception {
		log.info(".testStockTicker");
		String eplStatement = "every tick=StockTick()";
		EpsStatement statement = epService.addStatement(eplStatement, true,
				new EpsListener() {

					@Override
					public void update(EpsManager manager,
							EpsEventBean[] newEvents, EpsEventBean[] oldEvents) {
						Object tick = newEvents[0].get("tick");
						log.debug(tick);

					}
				});

		epService.sendEvent(new StockTick("ABC", 20d));

		epService.sendEvent(new StockTick("ABC", 20.1d));
		epService.sendEvent(new StockTick("ABC", 20.2d));
	}

	@Test
	@Ignore
	public void test1() {
		EpsStatement statement = epService.addStatement(
				"select * from StockTick", new EpsListener() {

					@Override
					public void update(EpsManager manager,
							EpsEventBean[] newEvents, EpsEventBean[] oldEvents) {
						log.info("Recevied Message"
								+ newEvents[0].getUnderlying().toString());

					}
				});

		epService.sendEvent(new StockTick("IBM", 23.23));
		
	}

	@Test
	public void testIteratorData() throws Exception {
		log.info(".testStockTicker");
		epService.addStatement("create window StockTickWin.win:keepall() as select * from StockTick");
		epService.addStatement("insert into StockTickWin select * from StockTick");
		
		String eplStatement = "every tick=StockTick()";
		EpsStatement statement = epService.addStatement(eplStatement, true,
				new EpsListener() {

					@Override
					public void update(EpsManager manager,
							EpsEventBean[] newEvents, EpsEventBean[] oldEvents) {
						Object tick = newEvents[0].get("tick");
						log.debug(tick);

					}
				});

		epService.sendEvent(new StockTick("ABC", 20d));

		epService.sendEvent(new StockTick("ABC", 20.1d));
		epService.sendEvent(new StockTick("ABC", 20.2d));
		
		log.info("Print all ticks:");
		
		Iterator<EpsEventBean> it = epService.executeQuery("select * from StockTickWin").iterator();
		
		for(;it.hasNext();){
			EpsEventBean tick = it.next();
			log.debug(tick.getUnderlying());
			
		}
	}

}