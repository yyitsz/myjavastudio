package org.yy.studyesper.fw;

import java.util.Iterator;

public interface EpsQueryResult {
	public EpsEventBean[] getArray();
    public Iterator<EpsEventBean> iterator();
}
