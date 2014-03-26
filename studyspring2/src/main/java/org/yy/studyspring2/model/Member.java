package org.yy.studyspring2.model;

public class Member {
	private String firstName;
	private String lastName;
	private String city;
	private String zipCode;
	
	public Member() {
		
	}
	public Member(String firstName, String lastName, String city, String zipCode) {
		super();
		this.firstName = firstName;
		this.lastName = lastName;
		this.city = city;
		this.zipCode = zipCode;
	}
	public String getFirstName() {
		return firstName;
	}
	public void setFirstName(String firstName) {
		this.firstName = firstName;
	}
	public String getLastName() {
		return lastName;
	}
	public void setLastName(String lastName) {
		this.lastName = lastName;
	}
	public String getCity() {
		return city;
	}
	public void setCity(String city) {
		this.city = city;
	}
	public String getZipCode() {
		return zipCode;
	}
	public void setZipCode(String zipCode) {
		this.zipCode = zipCode;
	}
	
	@Override
	public String toString() {
		return "Member [city=" + city + ", firstName=" + firstName
				+ ", lastName=" + lastName + ", zipCode=" + zipCode + "]";
	}
	
	
}
