package org.yy.core.risk.service;

import org.yy.core.model.Person;

import java.util.List;

/**
 * Created by yyi on 2017/3/15.
 */
public interface PersonService {
    Person addPerson(Person p);

    List<Person> getAllPerson();

}
