package org.yy.studymybatis.util;

import org.apache.ibatis.session.SqlSession;

public  interface SessionAction<Tr>{
	public Tr execute(SqlSession session);
}
