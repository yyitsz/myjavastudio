package org.yy.studyspring2;

import org.junit.Assert;
import org.junit.Ignore;
import org.junit.experimental.theories.DataPoint;
import org.junit.experimental.theories.DataPoints;
import org.junit.experimental.theories.Theories;
import org.junit.experimental.theories.Theory;
import org.junit.runner.RunWith;

@Ignore
@RunWith(Theories.class)
public class TheoryTest {
	
//	@DataPoint
//	public static Counter ZERO = new Counter(0);
//	@DataPoint
//	public static Counter FIVE = new Counter(5);
	
//	@DataPoints
//	public static Counter[] COUNTERS = {
//	    new Counter(0),
//	    new Counter(5),
//	};
	
	@DataPoint
	public static Counter zero() {
	    return new Counter(0);
	}
	@DataPoint
	public static Counter five() {
	    return new Counter(5);
	}
	
	@Theory
	public void incrementTheory(Counter toIncrement){
		System.out.println("incrementTheory(" + toIncrement + ")");
		int oldValue = toIncrement.getValue();
		toIncrement.increment();
		int newValue = toIncrement.getValue();
		Assert.assertEquals(oldValue + 1, newValue);
	}
	
	@Theory
	public void equalIncrementTheory(Counter c1, Counter c2) {
	    System.out.println("equalIncrementTheory(" + c1 + ", " + c2 + ")");
	    boolean wereEqual = c1.equals(c2);
	    c1.increment();		
	    c2.increment();
	    Assert.assertEquals(wereEqual, c1.equals(c2));
	}
}
