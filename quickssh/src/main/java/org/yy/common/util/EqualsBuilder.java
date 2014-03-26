package org.yy.common.util;

import java.util.Arrays;

public class EqualsBuilder {
	private boolean equals;
	public EqualsBuilder() {
		equals = true;
	}
	
	public EqualsBuilder append(Object a,Object b){
		equals = equals && (a==b || (a!=null && a.equals(b)));
		return this;
	}
	
	public EqualsBuilder append(int a,int b){
		equals = equals && a==b;
		return this;
	}
	
	public EqualsBuilder append(long a,long b){
		equals = equals && a==b;
		return this;
	}
	
	public EqualsBuilder append(byte a,byte b){
		equals = equals && a==b;
		return this;
	}
	
	public EqualsBuilder append(boolean a,boolean b){
		equals = equals && a==b;
		return this;
	}
	
	public EqualsBuilder append(float a,float b){
		equals = equals && a==b;
		return this;
	}
	
	public EqualsBuilder append(double a,double b){
		equals = equals && a==b;
		return this;
	}
	
	public EqualsBuilder append(char a,char b){
		equals = equals && a==b;
		return this;
	}
	
	public EqualsBuilder append(short a,short b){
		equals = equals && a==b;
		return this;
	}
	
	public EqualsBuilder append(Object[] a,Object[] b){
		equals = equals && Arrays.deepEquals(a, b);
		return this;
	}
	
	public EqualsBuilder append(int[] a,int[] b){
		equals = equals && Arrays.equals(a, b);
		return this;
	}
	
	public EqualsBuilder append(long[] a,long[] b){
		equals = equals && Arrays.equals(a, b);
		return this;
	}
	
	public EqualsBuilder append(byte[] a,byte[] b){
		equals = equals && Arrays.equals(a, b);
		return this;
	}
	
	public EqualsBuilder append(boolean[] a,boolean[] b){
		equals = equals && Arrays.equals(a, b);
		return this;
	}
	
	public EqualsBuilder append(float[] a,float[] b){
		equals = equals && Arrays.equals(a, b);
		return this;
	}
	
	public EqualsBuilder append(double[] a,double[] b){
		equals = equals && Arrays.equals(a, b);
		return this;
	}
	
	public EqualsBuilder append(char[] a,char[] b){
		equals = equals && Arrays.equals(a, b);
		return this;
	}
	
	public EqualsBuilder append(short[] a,short[] b){
		equals = equals && Arrays.equals(a, b);
		return this;
	}
	
	public boolean equals(){
		return this.equals;
	}
}
