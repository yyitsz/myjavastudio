package org.yy.studydrools.bank.service;

import org.drools.runtime.KnowledgeRuntime;
import org.drools.runtime.rule.RuleContext;

public class ValidationHelper {
	public static void error(RuleContext kcontext, Object... context){
		addMessage(Message.Type.ERROR,kcontext, context);
		
	}
	
	public static void warning(RuleContext kcontext, Object... context){
		addMessage(Message.Type.WARNING,kcontext, context);
		
	}
	
	public static void addMessage(Message.Type type, RuleContext kcontext, Object... context){
		
		KnowledgeRuntime runtime = kcontext.getKnowledgeRuntime();
		ValidationReport report = (ValidationReport) runtime.getGlobal("validationReport");
		ReportFactory factory = (ReportFactory) runtime.getGlobal("reportFactory");
		
		String ruleName = kcontext.getRule().getName();
		
		report.addMessage(factory.createMessage(type, ruleName, context));
	}
}
