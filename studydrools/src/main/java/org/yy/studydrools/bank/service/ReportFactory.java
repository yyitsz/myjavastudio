package org.yy.studydrools.bank.service;

public interface ReportFactory {
	ValidationReport createValidationReport();
	Message createMessage(Message.Type type, String messageKey, Object... context);
}
