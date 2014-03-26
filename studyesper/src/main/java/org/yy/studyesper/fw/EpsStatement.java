package org.yy.studyesper.fw;

import java.util.List;

public interface EpsStatement {

	public String getName();

	public String getStatement();

	public List<EpsListener> getListeners();

	public boolean isPattern();

	public void destroy();
}
