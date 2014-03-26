package org.yy.studydrools.bank.service.impl;

import java.util.HashSet;
import java.util.Set;

import org.yy.studydrools.bank.service.Message;
import org.yy.studydrools.bank.service.ValidationReport;
import org.yy.studydrools.bank.service.Message.Type;

public class DefaultValidationReport implements ValidationReport {

	private Set<Message> messages = new HashSet<Message>();
	
	@Override
	public Set<Message> getMessages() {
		
		return messages;
	}

	@Override
	public Set<Message> getMessagesByType(Type type) {
		Set<Message> subMessages = new HashSet<Message>();
		for(Message msg : messages){
			if(msg.getMessageType() == type){
				subMessages.add(msg);
				
			}
			
		}
		return subMessages;
	}

	@Override
	public boolean contains(String messageKey) {
		for(Message msg : messages){
			if(msg.getMessageKey().equals(messageKey)){
				return true;				
			}			
		}
		return false;
	}

	@Override
	public boolean addMessage(Message message) {
		if(message == null){
			
			throw new java.lang.IllegalArgumentException("message");
		}
		return messages.add(message)  ;
	}

	@Override
	public Message getMessage(String messageKey) {
		
		for(Message msg : messages){
			if(msg.getMessageKey().equals(messageKey)){
				return msg;				
			}			
		}
		return null;
	}

}
