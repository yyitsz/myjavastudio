package org.yy.core.risk.service.impl;

import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.yy.core.model.Person;
import org.yy.core.repository.PersonRepo;

import javax.annotation.Resource;
import java.util.List;

/**
 * Created by yyi on 2017/3/15.
 */
@Service
@Transactional
public class PersonServiceImpl implements org.yy.core.risk.service.PersonService {
    @Resource
    private PersonRepo personRepo;

    @Override
    public Person addPerson(Person p) {
        personRepo.save(p);
        return p;
    }

    @Override
    public List<Person> getAllPerson() {
        return personRepo.findAll();
    }
}
