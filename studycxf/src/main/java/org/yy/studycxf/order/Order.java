package org.yy.studycxf.order;
import javax.xml.bind.annotation.XmlRootElement;
@XmlRootElement(name="Order")
public class Order{
	private String customerId;
	private String itemId;
	private int qty;
	private double price;
	
	public Order(){
	}
	
	public String getCustomerId() {
      return customerId;
   }
   public void setCustomerId(String customerId) {
      this.customerId = customerId;
   }
	
	public String getItemId() {
      return itemId;
   }
   public void setItemId(String itemId) {
      this.itemId = itemId;
   }
   public int getQty() {
      return qty;
   }
   public void setQty(int qty) {
      this.qty = qty;
   }
   public double getPrice() {
      return price;
   }
   public void setPrice(double price) {
      this.price = price;
   }
}