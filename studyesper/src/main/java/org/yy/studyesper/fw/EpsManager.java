package org.yy.studyesper.fw;

import java.util.List;


public interface EpsManager {

	public abstract String getProviderUri();

	public abstract List<EpsStatement> getStatements();

	public abstract void init();

	public abstract void destroy();

	public abstract void destroyAllStatements();

	public void createStatement(EpsStatement epsStatement);
	
	public abstract EpsStatement addStatement(String epl,
			EpsListener... epsListeners);

	public abstract EpsStatement addStatement(String epl, boolean isPattern,
			EpsListener... epsListeners);

	public abstract void sendEvent(Object event);

	public abstract void route(final Object event);

	public abstract long getCurrentTime();

	public abstract EpsQueryResult executeQuery(String epl);

}