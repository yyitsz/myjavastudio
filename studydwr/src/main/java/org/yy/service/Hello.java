package org.yy.service;

public class Hello {
	
	public String hello(String name){
		
		return "����" + name;
	}
	
	public Name getBean(String myname){
		
		Name name = new Name();
		name.setName(myname);
		name.setChineseName("��С��");
		name.setEnglishName("Xiaoming Lee");
		return name;
	}
}
