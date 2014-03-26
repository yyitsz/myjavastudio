package org.yy.studyesper.fw.esper;

import org.yy.studyesper.fw.EpsEventBean;

import com.espertech.esper.client.EventBean;

public final class EsperHelper {
	
	public static EpsEventBean[] wrap(EventBean[] esperEvents) {
		if (esperEvents == null || esperEvents.length == 0) {
			return new EsperEpsEventBean[0];
		}
		EpsEventBean[] results = new EsperEpsEventBean[esperEvents.length];
		for (int i = 0; i < esperEvents.length; i++) {
			results[i] = wrap(esperEvents[i]);
		}
		return results;
	}

	public static EpsEventBean wrap(EventBean esperEvent) {
		if (esperEvent == null) {
			throw new NullPointerException("esperEvent must not be null.");
		}

		return new EsperEpsEventBean(esperEvent);
	}

}
