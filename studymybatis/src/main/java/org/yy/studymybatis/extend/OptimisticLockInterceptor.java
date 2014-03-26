package org.yy.studymybatis.extend;

import java.util.List;
import java.util.Properties;

import org.apache.ibatis.executor.Executor;
import org.apache.ibatis.mapping.MappedStatement;
import org.apache.ibatis.mapping.ParameterMapping;
import org.apache.ibatis.mapping.SqlCommandType;
import org.apache.ibatis.plugin.Interceptor;
import org.apache.ibatis.plugin.Intercepts;
import org.apache.ibatis.plugin.Invocation;
import org.apache.ibatis.plugin.Plugin;
import org.apache.ibatis.plugin.Signature;
import org.yy.studymybatis.model.VersionableBaseModel;

@Intercepts(@Signature(type = Executor.class, method = "update", args = {
		MappedStatement.class, Object.class }))
public class OptimisticLockInterceptor implements Interceptor {

	@Override
	public Object intercept(Invocation invocation) throws Throwable {
		Object[] args = invocation.getArgs();
		//boolean isVersion = false;
		if (args[1] != null && args[1] instanceof VersionableBaseModel) {
			MappedStatement statement = (MappedStatement) args[0];
			VersionableBaseModel bm = (VersionableBaseModel) args[1];		
			if (statement.getSqlCommandType() == SqlCommandType.INSERT) {
				bm.setVersion(0L);
			} else if (statement.getSqlCommandType() == SqlCommandType.UPDATE 
					|| statement.getSqlCommandType() == SqlCommandType.DELETE) {
				Long version = bm.getVersion();
				if(version != null)
				{
					return handleOptimisticLock(invocation,statement,bm);
				}
			}
		}
		
		return invocation.proceed();

	}

	private Object handleOptimisticLock(Invocation invocation,MappedStatement statement,
			VersionableBaseModel model) throws  Throwable {
		Long version = model.getVersion();
		model.setPreviousVersion(version);
		model.setVersion(version + 1L);
		List<ParameterMapping> paramMappings = statement.getParameterMap().getParameterMappings();
		Integer count = (Integer) invocation.proceed();
		if(count.intValue() == 0)
		{
			model.setVersion(version);//restore
			throw new OptimisticLockException(model.getClass().getName() + " may be modified by others.");
		}
		return count;
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
