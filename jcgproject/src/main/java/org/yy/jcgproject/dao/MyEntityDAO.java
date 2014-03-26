package org.yy.jcgproject.dao;


import org.springframework.stereotype.Repository;

import org.yy.jcgproject.domain.MyEntity;

@Repository("myEntityDAO")
public class MyEntityDAO extends GenericDAO<MyEntity,Long> {
	

}
