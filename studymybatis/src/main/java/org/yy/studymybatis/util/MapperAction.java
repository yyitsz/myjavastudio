package org.yy.studymybatis.util;

public  interface MapperAction<Tm,Tr>{
	public Tr execute(Tm mapper);
}
