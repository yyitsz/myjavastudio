package org.yy.studydrools.bank.service;

import java.util.List;

public interface Message {
	public enum Type{ERROR,WARNING}
	
	Type getMessageType();
    String getMessageKey();
    List<Object> getContextOrdered();

}
