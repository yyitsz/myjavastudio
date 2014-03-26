package org.yy.studymybatis.extend;

import java.util.Date;
import java.util.Properties;

import org.apache.ibatis.executor.Executor;
import org.apache.ibatis.mapping.MappedStatement;
import org.apache.ibatis.mapping.SqlCommandType;
import org.apache.ibatis.plugin.Interceptor;
import org.apache.ibatis.plugin.Intercepts;
import org.apache.ibatis.plugin.Invocation;
import org.apache.ibatis.plugin.Plugin;
import org.apache.ibatis.plugin.Signature;
import org.yy.studymybatis.model.BaseModel;

@Intercepts(@Signature(type = Executor.class, method = "update", args = {
		MappedStatement.class, Object.class }))
public class AuditInterceptor implements Interceptor {

	@Override
	public Object intercept(Invocation invocation) throws Throwable {
		Object[] args = invocation.getArgs();
		//boolean isVersion = false;
		if (args[1] != null && args[1] instanceof BaseModel) {
			MappedStatement statement = (MappedStatement) args[0];
			BaseModel bm = (BaseModel) args[1];
			Date currentTime = new Date(System.currentTimeMillis());
			String currentUser = "admin";
			if (statement.getSqlCommandType() == SqlCommandType.INSERT) {
				bm.setCreatedAt(currentTime);
				bm.setUpdatedAt(currentTime);
				bm.setCreatedBy(currentUser);
				bm.setUpdatedBy(currentUser);
			} else if (statement.getSqlCommandType() == SqlCommandType.UPDATE) {
				bm.setUpdatedAt(currentTime);
				bm.setUpdatedBy(currentUser);
			}
		}
		return invocation.proceed();
	}

	@Override
	public Object plugin(Object target) {
		return Plugin.wrap(target, this);
	}

	@Override
	public void setProperties(Properties properties) {
		// TODO Auto-generated method stub

	}

}
