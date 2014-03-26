package org.yy.studydrools.bank.service.impl;

import java.util.ArrayList;
import java.util.Collection;

import org.drools.KnowledgeBase;
import org.drools.runtime.StatelessKnowledgeSession;
import org.yy.studydrools.bank.model.Customer;
import org.yy.studydrools.bank.service.BankingInquiryService;
import org.yy.studydrools.bank.service.BankingValidationService;
import org.yy.studydrools.bank.service.ReportFactory;
import org.yy.studydrools.bank.service.ValidationReport;

public class BankingValidationServiceImpl implements BankingValidationService {
	private KnowledgeBase kbase;
	private ReportFactory reportFactory;
	private BankingInquiryService inquiryService;
	
	@Override
	public ValidationReport validate(Customer customer) {
		StatelessKnowledgeSession session = kbase.newStatelessKnowledgeSession();
		ValidationReport report = reportFactory.createValidationReport();
		session.setGlobal("validationReport", report);
		session.setGlobal("reportFactory", reportFactory);
		session.setGlobal("inquiryService", inquiryService);
		session.execute(getFacts(customer));
		return report;
	}

	private Collection<Object> getFacts(Customer customer) {
		ArrayList<Object> facts = new ArrayList<Object>();
		facts.add(customer);
		facts.add(customer.getAddress());
		facts.addAll(customer.getAccounts());
		return facts;
	}
}
