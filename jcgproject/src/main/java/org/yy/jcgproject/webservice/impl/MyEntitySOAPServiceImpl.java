package org.yy.jcgproject.webservice.impl;


import javax.jws.WebParam;
import javax.jws.WebService;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Autowired;

import org.yy.jcgproject.domain.MyEntity;
import org.yy.jcgproject.service.MyEntityService;
import org.yy.jcgproject.webservice.MyEntitySOAPService;

@WebService(endpointInterface = "org.yy.jcgproject.webservice.MyEntitySOAPService")
public class MyEntitySOAPServiceImpl implements MyEntitySOAPService {

	private Logger log = LoggerFactory.getLogger(MyEntitySOAPService.class);
	
	@Autowired
	private MyEntityService myEntityService;
	
	public String insert(@WebParam(name = "myentity")MyEntity entity) {
		log.info("insert method invoked");
		myEntityService.persist(entity);
		return "entity with id =[{"+entity.getId()+"}] persisted";
	}
	
	public MyEntity findById(@WebParam(name = "id")Long id) {
		return myEntityService.find(id);
	}

}
