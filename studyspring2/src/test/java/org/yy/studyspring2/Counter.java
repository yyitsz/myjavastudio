package org.yy.studyspring2;

import org.junit.Ignore;


public class Counter {
	private int value;
	public Counter(int init){
		this.value = init;
	}
	
	public void increment(){
		value = value + 1;
	}
	
	public int getValue(){
		return value;
	}

	@Override
	public String toString() {
		
		return "Counter(" + this.value + ")";
	}
	
	
}
