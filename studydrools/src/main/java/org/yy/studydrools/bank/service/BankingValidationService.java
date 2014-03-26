package org.yy.studydrools.bank.service;

import org.yy.studydrools.bank.model.Customer;

public interface BankingValidationService {
	ValidationReport validate(Customer customer);
}
