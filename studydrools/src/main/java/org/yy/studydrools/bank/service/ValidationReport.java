package org.yy.studydrools.bank.service;

import java.util.Set;

public interface ValidationReport {
	
	Set<Message> getMessages();
	Set<Message> getMessagesByType(Message.Type type);
	boolean contains(String messageKey);
	boolean addMessage(Message message);
	Message getMessage(String messageKey);

}
