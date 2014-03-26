package org.yy.studycommons;

import java.lang.reflect.InvocationTargetException;
import java.util.ArrayList;
import java.util.List;

import junit.framework.Assert;

import org.apache.commons.beanutils.BeanUtils;
import org.junit.Test;

public class BeanUtilTest {
	public static class Person {

		private String name;
		private List<Address> addresses;
		private Address address;

		public String getName() {
			return name;
		}

		public void setName(String name) {
			this.name = name;
		}

		public List<Address> getAddresses() {
			return addresses;
		}

		public void setAddresses(List<Address> addresses) {
			this.addresses = addresses;
		}

		public Address getAddress() {
			return address;
		}

		public void setAddress(Address address) {
			this.address = address;
		}

	}

	public static class Address {

		private String street;

		public String getStreet() {
			return street;
		}

		public void setStreet(String street) {
			this.street = street;
		}

	}

	@Test
	public void test1() throws IllegalAccessException, InstantiationException,
			InvocationTargetException, NoSuchMethodException {
		Person p = new Person();
		Address a = new Address();
		a.setStreet("ABC");
		Address a1 = new Address();
		a1.setStreet("SZ");
		Address a2 = new Address();
		a2.setStreet("GZ");

		p.setAddress(a);
		List<Address> addes = new ArrayList<Address>();
		addes.add(a1);
		addes.add(a2);

		p.setAddresses(addes);

		p.setName("Anything");

		Person p2 = (Person) BeanUtils.cloneBean(p);

		Assert.assertNotSame(p, p2);
		p2.getAddress().setStreet("CDE");

//		Assert.assertFalse(p.getAddress().getStreet().equals(
//				p2.getAddress().getStreet()));
//		Assert.assertNotSame(p.getAddresses(), p2.getAddresses());
//		Assert.assertNotSame(p.getAddresses().get(0), p2.getAddresses().get(0));

	}
}
