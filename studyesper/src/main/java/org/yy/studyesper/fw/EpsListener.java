package org.yy.studyesper.fw;

public interface EpsListener {
	void update (EpsManager manager, EpsEventBean[] newEvents, EpsEventBean[] oldEvents);
}
