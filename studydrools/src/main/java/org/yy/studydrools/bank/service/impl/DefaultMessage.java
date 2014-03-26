package org.yy.studydrools.bank.service.impl;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

import org.yy.studydrools.bank.service.Message;

public class DefaultMessage implements Message {

	private Message.Type type;
	private String messageKey;
	private List<Object> contextOrdered = new ArrayList<Object>();
	
	
	public DefaultMessage(Type type, String messageKey, Object... context) {
		super();
		this.type = type;
		this.messageKey = messageKey;
		if(context != null){
			
			for(int i=0; i < context.length; i++){
				
				this.contextOrdered.add(context[i]);
			}
		}
		//this.contextOrdered =context.;
	}

	@Override
	public Type getMessageType() {
		// TODO Auto-generated method stub
		return type;
	}

	@Override
	public String getMessageKey() {
		// TODO Auto-generated method stub
		return messageKey;
	}

	@Override
	public List<Object> getContextOrdered() {
		// TODO Auto-generated method stub
		return contextOrdered;
	}

	@Override
	public int hashCode() {
		final int prime = 31;
		int result = 1;
		result = prime * result
				+ ((contextOrdered == null) ? 0 : contextOrdered.hashCode());
		result = prime * result
				+ ((messageKey == null) ? 0 : messageKey.hashCode());
		result = prime * result + ((type == null) ? 0 : type.hashCode());
		return result;
	}

	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (getClass() != obj.getClass())
			return false;
		DefaultMessage other = (DefaultMessage) obj;
		if (contextOrdered == null) {
			if (other.contextOrdered != null)
				return false;
		} else if (!contextOrdered.equals(other.contextOrdered))
			return false;
		if (messageKey == null) {
			if (other.messageKey != null)
				return false;
		} else if (!messageKey.equals(other.messageKey))
			return false;
		if (type != other.type)
			return false;
		return true;
	}
	
	

}
