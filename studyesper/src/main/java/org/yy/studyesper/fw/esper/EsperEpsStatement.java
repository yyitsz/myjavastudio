package org.yy.studyesper.fw.esper;

import java.util.ArrayList;
import java.util.List;

import org.yy.studyesper.fw.EpsListener;
import org.yy.studyesper.fw.EpsManager;
import org.yy.studyesper.fw.EpsStatement;

import com.espertech.esper.client.EPStatement;
import com.espertech.esper.client.EventBean;
import com.espertech.esper.client.UpdateListener;

public class EsperEpsStatement implements EpsStatement {

	protected class EsperStatementListenerAdapter implements UpdateListener {

		private EpsListener listener;

		public EsperStatementListenerAdapter(EpsListener listener) {
			this.listener = listener;
		}

		@Override
		public void update(EventBean[] newEvents, EventBean[] oldEvents) {
			this.listener.update(EsperEpsStatement.this.manager, EsperHelper
					.wrap(newEvents), EsperHelper.wrap(oldEvents));

		}
	}

	private String name;
	private String statement;
	private List<EpsListener> listeners = new ArrayList<EpsListener>();
	private EPStatement esperStatement;
	private EpsManager manager;
	private boolean isPattern = false;
	
	
	public boolean isPattern() {
		return isPattern;
	}

	public void setPattern(boolean isPattern) {
		this.isPattern = isPattern;
	}

	public EpsManager getManager() {
		return manager;
	}

	public void setManager(EpsManager manager) {
		this.manager = manager;
	}

	public String getStatement() {
		return statement;
	}

	public void setStatement(String statement) {
		this.statement = statement;
	}

	public List<EpsListener> getListeners() {
		return listeners;
	}

	public void setListeners(List<EpsListener> listeners) {
		this.listeners.addAll(listeners);
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public EPStatement getEsperStatement() {
		return esperStatement;
	}

	public void setEsperStatement(EPStatement esperStatement) {
		if(this.esperStatement != null){
			this.esperStatement.destroy();
		}
		this.esperStatement = esperStatement;
		for (EpsListener listener : listeners) {
			esperStatement.addListener(new EsperStatementListenerAdapter(listener));
		}
	}
	
	public void destroy(){
		if(this.esperStatement != null){
			this.esperStatement.destroy();
		}
	}

}
