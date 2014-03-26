package org.yy.studyspring3.bookstore.service;

import org.yy.studyspring3.bookstore.domain.Account;


public interface AccountService {

    Account login(String username, String password) throws AuthenticationException;

}
