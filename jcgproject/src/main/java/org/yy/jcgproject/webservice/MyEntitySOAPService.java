package org.yy.jcgproject.webservice;


import javax.jws.WebService;

import org.yy.jcgproject.domain.MyEntity;

@WebService
public interface MyEntitySOAPService {
	public String insert(MyEntity entity);
	public MyEntity findById(Long id);

}
