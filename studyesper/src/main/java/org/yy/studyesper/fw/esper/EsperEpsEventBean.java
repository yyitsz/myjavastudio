package org.yy.studyesper.fw.esper;

import org.yy.studyesper.fw.EpsEventBean;

import com.espertech.esper.client.EventBean;

public class EsperEpsEventBean implements EpsEventBean {

	EventBean rawBean;

	public EventBean getRawBean() {
		return rawBean;
	}

	public EsperEpsEventBean(EventBean rawBean) {
		this.rawBean = rawBean;
	}

	@Override
	public Object get(String propertyExpression) {
		return rawBean.get(propertyExpression);
	}

	@Override
	public Object getUnderlying() {
		
		return rawBean.getUnderlying();
	}

}
