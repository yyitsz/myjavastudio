package org.yy.studycxf.order;
import javax.jws.*;
import org.yy.studycxf.order.*;

@WebService
public class OrderProcessImpl implements OrderProcess {
	public String processOrder(Order order){
		return validate(order);
	}
	
	private String validate(Order order) {
		String custId = order.getCustomerId();
		String itemId = order.getItemId();
		int qty = order.getQty();
		double price = order.getPrice();
		if (custId != null && itemId != null && custId.equals("") == false 
		&& itemId.equals("") == false && qty > 0 && price > 0.0) {
			return "ORD1234";
		}
		
		return null;
	}
}