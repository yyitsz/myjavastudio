package org.yy.studymybatis.util;

import java.io.IOException;
import java.io.Reader;

import org.apache.ibatis.io.Resources;
import org.apache.ibatis.session.SqlSessionFactory;
import org.apache.ibatis.session.SqlSessionFactoryBuilder;
import org.yy.studymybatis.mapper.ContactMapper;

public class MyBatisConnectionFactory {
	private static class Holder
	{
		private static SqlSessionFactory factory;
		static {
			String resource = "SqlMapConfig.xml";
			try {
				Reader reader = Resources.getResourceAsReader(resource);
				if (factory == null) {
					factory = new SqlSessionFactoryBuilder().build(reader);
					//factory.getConfiguration().addMapper(ContactMapper.class);
				}
			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}

		}
	}
	
	public static SqlSessionFactory getFactory() {
		return Holder.factory;
	}
	
	
}
