package org.yy.studycxf.order;
import javax.jws.WebService;
import javax.jws.WebMethod;
import org.yy.studycxf.*;

@WebService
public interface OrderProcess{
	@WebMethod
	String processOrder(Order order);
}