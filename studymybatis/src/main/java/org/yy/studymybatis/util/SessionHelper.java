package org.yy.studymybatis.util;

import org.apache.ibatis.session.SqlSession;
import org.apache.ibatis.session.SqlSessionFactory;

public class SessionHelper {

	public static <Tm, Tr> Tr execute(Class<Tm> mapperType,
			MapperAction<Tm, Tr> action) {
		SqlSessionFactory sqlSessionFactory = MyBatisConnectionFactory
				.getFactory();

		SqlSession session = sqlSessionFactory.openSession();

		try {
			Tm mapper = session.getMapper(mapperType);
			Tr result = action.execute(mapper);
			session.commit();
			return result;
		} finally {
			session.close();
		}
	}

	public static <Tm> void execute(Class<Tm> mapperType,
			MapperActionNoResult<Tm> action) {
		SqlSessionFactory sqlSessionFactory = MyBatisConnectionFactory
				.getFactory();

		SqlSession session = sqlSessionFactory.openSession();

		try {
			Tm mapper = session.getMapper(mapperType);
			action.execute(mapper);
			session.commit();

		} finally {
			session.close();
		}
	}

	public static <Tr> Tr execute(SessionAction<Tr> action) {
		SqlSessionFactory sqlSessionFactory = MyBatisConnectionFactory
				.getFactory();

		SqlSession session = sqlSessionFactory.openSession();

		try {

			Tr result = action.execute(session);
			session.commit();
			return result;
		} finally {
			session.close();
		}
	}

	public static <Tm> void execute(SessionActionNoResult action) {
		SqlSessionFactory sqlSessionFactory = MyBatisConnectionFactory
				.getFactory();

		SqlSession session = sqlSessionFactory.openSession();

		try {
			action.execute(session);
			session.commit();

		} finally {
			session.close();
		}
	}
}
