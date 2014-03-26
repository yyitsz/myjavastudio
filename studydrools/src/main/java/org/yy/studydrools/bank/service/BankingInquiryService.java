package org.yy.studydrools.bank.service;

import org.yy.studydrools.bank.model.Account;

public interface BankingInquiryService {
    boolean isAccountUnique(Account account);
}
