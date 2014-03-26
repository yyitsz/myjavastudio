package org.yy.studyspring3.bookstore.service.impl;

import org.springframework.stereotype.Service;
import org.yy.studyspring3.bookstore.domain.Account;
import org.yy.studyspring3.bookstore.service.AccountService;
import org.yy.studyspring3.bookstore.service.AuthenticationException;

@Service
public class AccountServiceImpl implements AccountService {

    @Override
    public Account login(String username, String password) throws AuthenticationException {
        if("admin".equals(username) && "password".equals(password)){
            Account a = new Account();
            a.setUserName(username);
            return a;
        }
        else{
            throw new AuthenticationException("Username or password is invalid.");
        }

    }

}
