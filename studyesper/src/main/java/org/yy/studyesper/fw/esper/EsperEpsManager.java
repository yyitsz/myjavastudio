package org.yy.studyesper.fw.esper;

import java.util.ArrayList;
import java.util.List;

import org.yy.studyesper.fw.EpsListener;
import org.yy.studyesper.fw.EpsManager;
import org.yy.studyesper.fw.EpsQueryResult;
import org.yy.studyesper.fw.EpsStatement;

import com.espertech.esper.client.Configuration;
import com.espertech.esper.client.EPServiceProvider;
import com.espertech.esper.client.EPServiceProviderManager;
import com.espertech.esper.client.EPStatement;

public class EsperEpsManager implements EpsManager {

	private EPServiceProvider serviceProvider;
	private String providerUri;
	private List<EpsStatement> statements = new ArrayList<EpsStatement>();

	/*
	 * (non-Javadoc)
	 * 
	 * @see org.yy.studyesper.fw.esper.EpsManager#getProviderUri()
	 */
	public String getProviderUri() {
		return providerUri;
	}

	public void setProviderUri(String providerUri) {
		this.providerUri = providerUri;
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see org.yy.studyesper.fw.esper.EpsManager#getStatements()
	 */
	public List<EpsStatement> getStatements() {
		return statements;
	}

	public void setStatements(List<EpsStatement> statements) {
		this.statements.addAll(statements);
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see org.yy.studyesper.fw.esper.EpsManager#init()
	 */
	public void init() {
		Configuration config = new Configuration();
		config.configure("esper.cfg.xml");
		serviceProvider = EPServiceProviderManager.getProvider(providerUri,
				config);

		destroyAllStatements();

		createStatement();

	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see org.yy.studyesper.fw.esper.EpsManager#destroy()
	 */
	public void destroy() {
		serviceProvider.destroy();
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see org.yy.studyesper.fw.esper.EpsManager#destroyAllStatements()
	 */
	public void destroyAllStatements() {
		if (serviceProvider != null) {
			serviceProvider.getEPAdministrator().destroyAllStatements();
		}
	}

	private void createStatement() {
		for (EpsStatement epsState : this.statements) {
			createStatement(epsState);
		}
	}

	public void createStatement(EpsStatement epsStatement) {
		EsperEpsStatement esperStatementWrapper = (EsperEpsStatement) epsStatement;
		String name = esperStatementWrapper.getName();
		if (name == null || name.equals("")) {
			name = esperStatementWrapper.getStatement();
		}
		EPStatement statement = null;
		if (esperStatementWrapper.isPattern()) {
			statement = serviceProvider.getEPAdministrator().createPattern(
					esperStatementWrapper.getStatement(), name);
		} else {
			statement = serviceProvider.getEPAdministrator().createEPL(
					esperStatementWrapper.getStatement(), name);
		}

		esperStatementWrapper.setManager(this);
		esperStatementWrapper.setEsperStatement(statement);

	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see org.yy.studyesper.fw.esper.EpsManager#addStatement(java.lang.String,
	 * org.yy.studyesper.fw.EpsListener)
	 */
	public EpsStatement addStatement(String epl, EpsListener... epsListeners) {
		return addStatement(epl, false, epsListeners);
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see org.yy.studyesper.fw.esper.EpsManager#addStatement(java.lang.String,
	 * boolean, org.yy.studyesper.fw.EpsListener)
	 */
	public EpsStatement addStatement(String epl, boolean isPattern,
			EpsListener... epsListeners) {
		EsperEpsStatement esperStatementWrapper = new EsperEpsStatement();
		esperStatementWrapper.setStatement(epl);
		esperStatementWrapper.setPattern(isPattern);
		List<EpsListener> list = new ArrayList<EpsListener>();
		java.util.Collections.addAll(list, epsListeners);
		esperStatementWrapper.setListeners(list);

		createStatement(esperStatementWrapper);
		this.statements.add(esperStatementWrapper);

		return esperStatementWrapper;
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see org.yy.studyesper.fw.esper.EpsManager#sendEvent(java.lang.Object)
	 */
	public void sendEvent(Object event) {
		this.serviceProvider.getEPRuntime().sendEvent(event);
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see org.yy.studyesper.fw.esper.EpsManager#route(java.lang.Object)
	 */
	public void route(final Object event) {
		this.serviceProvider.getEPRuntime().route(event);
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see org.yy.studyesper.fw.esper.EpsManager#getCurrentTime()
	 */
	public long getCurrentTime() {
		return this.serviceProvider.getEPRuntime().getCurrentTime();
	}

	/*
	 * (non-Javadoc)
	 * 
	 * @see org.yy.studyesper.fw.esper.EpsManager#executeQuery(java.lang.String)
	 */
	public EpsQueryResult executeQuery(String epl) {
		return new EsperEpsQueryResult(this.serviceProvider.getEPRuntime()
				.executeQuery(epl));
	}
}
