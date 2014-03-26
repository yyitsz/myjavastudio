package org.yy.studyesper;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;

import org.yy.studyesper.eventbean.DeleteStockTick;
import org.yy.studyesper.eventbean.LimitAlert;
import org.yy.studyesper.eventbean.PriceLimit;
import org.yy.studyesper.eventbean.StockTick;

import com.espertech.esper.client.Configuration;
import com.espertech.esper.client.EPRuntime;
import com.espertech.esper.client.EPServiceProvider;
import com.espertech.esper.client.EPServiceProviderManager;
import com.espertech.esper.client.EventBean;
import com.espertech.esper.client.UpdateListener;
import com.espertech.esper.event.map.MapEventType;

public class EsperTestBase {
	private static final Log log = LogFactory.getLog(EsperTestBase.class);
	protected EPServiceProvider CreateEpServiceProvider() {
		Configuration config = new Configuration();
		config.addEventType("StockTick", StockTick.class);
		config.addEventType("PriceLimit", PriceLimit.class);
		config.addEventType("LimitAlert", LimitAlert.class);
		config.addEventType("DeleteStockTick", DeleteStockTick.class);
		config.addEventType("A", A.class);
		config.addEventType("B", B.class);
		config.addEventType("C", C.class);
		config.addEventType("E", E.class);
		config.addEventType("D", D.class);
		
		EPServiceProvider ep = EPServiceProviderManager.getProvider("testProvider", config);
		return ep;
	}
	
	protected void sendEvents(EPRuntime runtime, Object... events){
		if(events != null) {
			for(Object o : events) {
				log.info("Send event: " + o.toString()); 
				runtime.sendEvent(o);
			}
		}
	}
	protected static class PrintUpdateListener implements UpdateListener {

		private static final Log log = LogFactory.getLog(PrintUpdateListener.class);
		@Override
		public void update(EventBean[] newEvents, EventBean[] oldEvents) {
			
			log.info("Old Events:######################################################################");
			if(oldEvents != null && oldEvents.length > 0){
				for(EventBean event : oldEvents){
					print(event);
				}
			}
			log.info("New Events:######################################################################");
			if(newEvents != null && newEvents.length > 0){
				for(EventBean event : newEvents){
					print(event);
				}
			}
			log.info("End:######################################################################");
			
		}
		private void print(EventBean event) {
			StringBuilder sb = new StringBuilder();
			sb.append("Event Type:").append(event.getEventType().toString()).append("\r\n");
			sb.append("Underlying:").append(event.getUnderlying());
//			if(event.getUnderlying() instanceof MapEventType){
//				MapEventType map = (MapEventType)event.getUnderlying();
//				//map.
//				sb.append("Underlying:").append(event.getUnderlying());
//			} else {
//				sb.append("Underlying:").append(event.getUnderlying());
//			}
		
			log.info(sb.toString());
			
		}
		
	}
	
	protected static class EventBase{
		protected String id;

		
		public String getId() {
			return id;
		}


		public void setId(String id) {
			this.id = id;
		}


		public EventBase(String id) {
			this.id = id;
		}
		
	}
	protected static class A extends EventBase{
		
		public A(String id) {
			super(id);
			
		}


		@Override
		public String toString() {
			return "A [id=" + id + "]";
		}
		
	}
	
	protected static class B extends EventBase{

		public B(String id) {
			
			super(id);
		}


		@Override
		public String toString() {
			return "B [id=" + id + "]";
		}
		
	}
	protected static class C extends EventBase{

		public C(String id) {
			
			super(id);
		}


		@Override
		public String toString() {
			return "B [id=" + id + "]";
		}
		
	}
	protected static class D extends EventBase{

		public D(String id) {
			
			super(id);
		}


		@Override
		public String toString() {
			return "B [id=" + id + "]";
		}
		
	}
	protected static class E extends EventBase{

		public E(String id) {
			
			super(id);
		}


		@Override
		public String toString() {
			return "B [id=" + id + "]";
		}
		
	}
	
}
