package org.yy.studydrools.bank.service;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Calendar;
import java.util.Collection;
import java.util.Date;
import java.util.List;

import org.drools.KnowledgeBase;
import org.drools.KnowledgeBaseConfiguration;
import org.drools.KnowledgeBaseFactory;
import org.drools.builder.KnowledgeBuilder;
import org.drools.builder.KnowledgeBuilderFactory;
import org.drools.builder.ResourceType;
import org.drools.command.Command;
import org.drools.command.CommandFactory;
import org.drools.conf.SequentialOption;
import org.drools.io.ResourceFactory;
import org.drools.runtime.StatelessKnowledgeSession;
import org.joda.time.DateMidnight;
import org.joda.time.JodaTimePermission;
import org.junit.Assert;
import org.junit.BeforeClass;
import org.junit.Test;
import org.yy.studydrools.bank.model.Account;
import org.yy.studydrools.bank.model.Address;
import org.yy.studydrools.bank.model.Customer;
import org.yy.studydrools.bank.service.Message.Type;
import org.yy.studydrools.bank.service.impl.BankingInquiryServiceImpl;
import org.yy.studydrools.bank.service.impl.DefaultReportFactory;


public class ValidationTest {
	private static StatelessKnowledgeSession session;
	private static ReportFactory reportFactory;
	
	@BeforeClass
	public static void setupClass() throws Exception {
		KnowledgeBuilder builder = KnowledgeBuilderFactory.newKnowledgeBuilder();
		builder.add(ResourceFactory.newClassPathResource("validation.drl", ValidationHelper.class), ResourceType.DRL);
		if(builder.hasErrors()){
			
			throw new RuntimeException(builder.getErrors().toString());
		}
		KnowledgeBaseConfiguration config = KnowledgeBaseFactory.newKnowledgeBaseConfiguration();
		config.setOption(SequentialOption.YES);
		KnowledgeBase kbase = KnowledgeBaseFactory.newKnowledgeBase(config);
		kbase.addKnowledgePackages(builder.getKnowledgePackages());
		session = kbase.newStatelessKnowledgeSession();
		
		reportFactory = new DefaultReportFactory();
		session.setGlobal("reportFactory", reportFactory);
		
		session.setGlobal("inquiryService", new BankingInquiryServiceImpl());
		
	}
	
	@Test
	public void addressRequiredTest(){
		
		Customer customer = createBasicCustomer();
		Assert.assertNull(customer.getAddress());
		assertReportContains(Message.Type.WARNING, "addressRequired", customer);
		customer.setAddress(new Address());
		assertNotReportContains(Message.Type.WARNING, "addressRequired", customer);
	}
	
	@Test
	public void accountBalanceAtLeast() throws Exception {
		Customer customer = createBasicCustomer();
		Account account = customer.getAccounts().iterator().next();
		Assert.assertEquals(BigDecimal.ZERO, account.getBalance());
		assertReportContains(Message.Type.WARNING, "accountBalanceAtLeast", customer, account);
		account.setBalance(new BigDecimal("54.00"));
		assertReportContains(Message.Type.WARNING, "accountBalanceAtLeast", customer, account);
		account.setBalance(new BigDecimal("154.00"));
		assertNotReportContains(Message.Type.WARNING, "accountBalanceAtLeast", customer, account);

	}
	
	@Test
	public void studentAccountCustomerAgeLessThan() throws Exception {
		DateMidnight NOW = new DateMidnight();
		Customer customer = createBasicCustomer();
		Account account = customer.getAccounts().iterator().next();
		customer.setDateOfBirth(NOW.minusYears(40).toDate());
		Assert.assertEquals(Account.Type.TRANSACTIONAL, account.getType());
		assertNotReportContains(Message.Type.ERROR, "studentAccountCustomerAgeLessThan", customer);
		account.setType(Account.Type.STUDENT);
		assertReportContains(Message.Type.ERROR, "studentAccountCustomerAgeLessThan", customer, account);
		customer.setDateOfBirth(NOW.minusYears(26).toDate());
		assertNotReportContains(Message.Type.ERROR, "studentAccountCustomerAgeLessThan", customer);

	}
	
	@Test
	public void accountNumberUnique() throws Exception {
		
		Customer customer = createBasicCustomer();
		Account account = customer.getAccounts().iterator().next();
		session.setGlobal("inquiryService", new BankingInquiryService(){

			@Override
			public boolean isAccountUnique(Account account) {
				// TODO Auto-generated method stub
				return false;
			}});

		assertReportContains(Message.Type.ERROR, "accountNumberUnique", customer, account);
	

	}

	private void assertNotReportContains(Type messageType, String messageKey,
			Customer customer, Object... context) {
		ValidationReport report = reportFactory.createValidationReport();
//		session.setGlobal("report", report);
//		session.execute(customer);
		List<Command> commands = new ArrayList<Command>();
		commands.add(CommandFactory.newSetGlobal("validationReport", report));
		commands.add(CommandFactory.newInsertElements(getFacts(customer)));
		session.execute(CommandFactory.newBatchExecution(commands));
		Assert.assertFalse("Report contain message [" + messageKey + "]",
				report.contains(messageKey));
		
	}

	private void assertReportContains(Type messageType, String messageKey,
			Customer customer, Object... context) {
		
		ValidationReport report = reportFactory.createValidationReport();
//		session.setGlobal("report", report);
//		session.execute(customer);
		List<Command> commands = new ArrayList<Command>();
		commands.add(CommandFactory.newSetGlobal("validationReport", report));
		commands.add(CommandFactory.newInsertElements(getFacts(customer)));
		session.execute(CommandFactory.newBatchExecution(commands));
		Assert.assertTrue("Report doesn't contain message [" + messageKey + "]",
				report.contains(messageKey));
		Message message = getMessage(report, messageKey);
		Assert.assertEquals(Arrays.asList(context), message.getContextOrdered());
	}

	private Message getMessage(ValidationReport report, String messageKey) {
		
		return report.getMessage(messageKey);
	}

	private Collection<Object> getFacts(Customer customer) {
		ArrayList<Object> facts = new ArrayList<Object>();
		facts.add(customer);
		facts.add(customer.getAddress());
		facts.addAll(customer.getAccounts());
		return facts;
	}

	private Customer createBasicCustomer() {
		Customer c = new Customer();
		c.setFirstName("Zhen");
		c.setLastName("John");
		c.setEmail("john.zhen@gmail.com");
		c.setDateOfBirth(Calendar.getInstance().getTime());
		Account ac = new Account();
		ac.setBalance(BigDecimal.ZERO);
		ac.setType(Account.Type.TRANSACTIONAL);
		ac.setOwner(c);
		c.getAccounts().add(ac);
		return c;
	}
}
