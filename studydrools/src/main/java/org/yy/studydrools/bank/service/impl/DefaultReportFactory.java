package org.yy.studydrools.bank.service.impl;

import org.yy.studydrools.bank.service.Message;
import org.yy.studydrools.bank.service.ReportFactory;
import org.yy.studydrools.bank.service.ValidationReport;
import org.yy.studydrools.bank.service.Message.Type;

public class DefaultReportFactory implements ReportFactory {

	@Override
	public ValidationReport createValidationReport() {
		
		return new DefaultValidationReport();
	}

	@Override
	public Message createMessage(Type type, String messageKey,
			Object... context) {
		
		return new DefaultMessage(type,messageKey,context);
	}

}
