package org.yy.studymybatis.util;

import org.apache.ibatis.session.SqlSession;

public  interface SessionActionNoResult{
	public void execute(SqlSession session);
}
