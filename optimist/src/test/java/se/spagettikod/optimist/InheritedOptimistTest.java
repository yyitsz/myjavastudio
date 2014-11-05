package se.spagettikod.optimist;

import java.sql.Connection;
import java.sql.SQLException;
import java.sql.Statement;

import junit.framework.Assert;

import org.apache.ibatis.exceptions.PersistenceException;
import org.apache.ibatis.session.SqlSession;
import org.junit.Before;
import org.junit.Test;

import se.spagettikod.optimist.ModifiedByAnotherUserException;
import se.spagettikod.optimist.RemovedByAnotherUserException;
import se.spagettikod.optimist.testutil.MyBatisTestUtil;
import se.spagettikod.optimist.testutil.mockups.InheritedEntity;
import se.spagettikod.optimist.testutil.mockups.InheritedEntityMapper;


public class InheritedOptimistTest {

	@Before
	public void init() {
		SqlSession session = MyBatisTestUtil.getSession();
		Connection c = session.getConnection();
		Statement s = null;
		try {
			s = c.createStatement();
			s.execute("TRUNCATE TABLE inherited_entity");
		} catch (SQLException e) {
			e.printStackTrace();
		} finally {
			try {
				if (s != null && !s.isClosed()) {
					s.close();
				}
				if (c != null && c.isClosed()) {
					c.close();
				}
			} catch (SQLException e) {
				e.printStackTrace();
			}
			if (session != null) {
				session.close();
			}
		}
	}

	@Test
	public void insertNewEntity() {
		InheritedEntity entity = new InheritedEntity();
		entity.setValue("testing");
		entity.setAdditionalValue("value2");
		SqlSession session = MyBatisTestUtil.getSession();
		InheritedEntityMapper mapper = session
				.getMapper(InheritedEntityMapper.class);
		try {
			mapper.insertEntity(entity);
			session.commit();
		} catch (Exception e) {
			e.printStackTrace();
		} finally {
			if (session != null) {
				session.close();
			}
		}
		Assert.assertEquals("testing", entity.getValue());
		Assert.assertEquals("value2", entity.getAdditionalValue());
		Assert.assertEquals(new Integer(0), entity.getVersion());
		Assert.assertEquals(new Long(1), entity.getId());
	}

	@Test
	public void updateEntity() {
		InheritedEntity entity = new InheritedEntity();
		entity.setValue("testing");
		entity.setAdditionalValue("value2");
		SqlSession session = MyBatisTestUtil.getSession();
		InheritedEntityMapper mapper = session
				.getMapper(InheritedEntityMapper.class);
		try {
			mapper.insertEntity(entity);
			session.commit();
		} catch (Exception e) {
			e.printStackTrace();
		} finally {
			if (session != null) {
				session.close();
			}
		}
		Assert.assertEquals(new Integer(0), entity.getVersion());

		Long identity = entity.getId();
		session = MyBatisTestUtil.getSession();
		mapper = session.getMapper(InheritedEntityMapper.class);
		entity = mapper.getById(identity);
		entity.setValue("tjoho");
		entity.setAdditionalValue("value2");
		try {
			mapper.updateEntity(entity);
			session.commit();
		} catch (Exception e) {
			e.printStackTrace();
		} finally {
			if (session != null) {
				session.close();
			}
		}
		Assert.assertEquals("tjoho", entity.getValue());
		Assert.assertEquals("value2", entity.getAdditionalValue());
		Assert.assertEquals(new Integer(1), entity.getVersion());
	}

	@Test(expected = se.spagettikod.optimist.ModifiedByAnotherUserException.class)
	public void modifiedByAnotherUser() {
		SqlSession firstSession = MyBatisTestUtil.getSession();
		InheritedEntity entity = new InheritedEntity();
		entity.setValue("firstEdit");
		entity.setAdditionalValue("value2");
		InheritedEntityMapper firstMapper = firstSession
				.getMapper(InheritedEntityMapper.class);
		firstMapper.insertEntity(entity);
		firstSession.commit();
		Assert.assertEquals(new Integer(0), entity.getVersion());

		// Load same entity in second session
		SqlSession secondSession = MyBatisTestUtil.getSession();
		InheritedEntity secondEntity = new InheritedEntity();
		Long identity = entity.getId();
		InheritedEntityMapper secondMapper = secondSession
				.getMapper(InheritedEntityMapper.class);
		secondEntity = secondMapper.getById(identity);
		Assert.assertEquals(new Integer(0), secondEntity.getVersion());

		// Modify entity in first session
		entity = firstMapper.getById(entity.getId());
		entity.setValue("secondEdit");
		entity.setAdditionalValue("value2");
		firstMapper.updateEntity(entity);
		firstSession.commit();
		firstSession.close();
		Assert.assertEquals(new Integer(1), entity.getVersion());

		secondEntity.setValue("thirdEdit");
		try {
			secondMapper.updateEntity(secondEntity);
		} catch (PersistenceException e) {
			if (e.getCause() instanceof ModifiedByAnotherUserException) {
				throw (ModifiedByAnotherUserException) e.getCause();
			} else {
				throw e;
			}
		} finally {
			if (secondSession != null) {
				secondSession.close();
			}
		}
	}

	@Test(expected = se.spagettikod.optimist.ModifiedByAnotherUserException.class)
	public void modifiedByAnotherUserDuringDelete() {
		SqlSession firstSession = MyBatisTestUtil.getSession();
		InheritedEntity entity = new InheritedEntity();
		entity.setValue("firstEdit");
		entity.setAdditionalValue("value2");
		InheritedEntityMapper firstMapper = firstSession
				.getMapper(InheritedEntityMapper.class);
		firstMapper.insertEntity(entity);
		firstSession.commit();
		Assert.assertEquals(new Integer(0), entity.getVersion());

		// Load same entity in second session
		SqlSession secondSession = MyBatisTestUtil.getSession();
		InheritedEntity secondEntity = new InheritedEntity();
		Long identity = entity.getId();
		InheritedEntityMapper secondMapper = secondSession
				.getMapper(InheritedEntityMapper.class);
		secondEntity = secondMapper.getById(identity);
		Assert.assertEquals(new Integer(0), secondEntity.getVersion());

		// Modify entity in first session
		entity = firstMapper.getById(entity.getId());
		entity.setValue("secondEdit");
		entity.setAdditionalValue("value2");
		firstMapper.updateEntity(entity);
		firstSession.commit();
		firstSession.close();
		Assert.assertEquals(new Integer(1), entity.getVersion());

		// Delete the entity after first session has modified
		try {
			secondMapper.deleteEntity(secondEntity);
		} catch (PersistenceException e) {
			if (e.getCause() instanceof ModifiedByAnotherUserException) {
				throw (ModifiedByAnotherUserException) e.getCause();
			} else {
				throw e;
			}
		} finally {
			if (secondSession != null) {
				secondSession.close();
			}
		}
	}

	@Test(expected = se.spagettikod.optimist.RemovedByAnotherUserException.class)
	public void removedByAnotherUser() {
		SqlSession firstSession = MyBatisTestUtil.getSession();
		InheritedEntity entity = new InheritedEntity();
		entity.setValue("firstEdit");
		InheritedEntityMapper firstMapper = firstSession
				.getMapper(InheritedEntityMapper.class);
		firstMapper.insertEntity(entity);
		firstSession.commit();
		Assert.assertEquals(new Integer(0), entity.getVersion());

		// Load same entity in second session
		SqlSession secondSession = MyBatisTestUtil.getSession();
		InheritedEntity secondEntity = new InheritedEntity();
		Long identity = entity.getId();
		InheritedEntityMapper secondMapper = secondSession
				.getMapper(InheritedEntityMapper.class);
		secondEntity = secondMapper.getById(identity);
		Assert.assertEquals(new Integer(0), secondEntity.getVersion());

		// Delete entity in first session
		entity = firstMapper.getById(entity.getId());
		firstMapper.deleteEntity(entity);
		firstSession.commit();
		firstSession.close();

		secondEntity.setValue("thirdEdit");
		try {
			secondMapper.updateEntity(secondEntity);
		} catch (PersistenceException e) {
			if (e.getCause() instanceof RemovedByAnotherUserException) {
				throw (RemovedByAnotherUserException) e.getCause();
			} else {
				throw e;
			}
		} finally {
			if (secondSession != null) {
				secondSession.close();
			}
		}
	}

	@Test(expected = se.spagettikod.optimist.RemovedByAnotherUserException.class)
	public void removedByAnotherUserDuringDelete() {
		SqlSession firstSession = MyBatisTestUtil.getSession();
		InheritedEntity entity = new InheritedEntity();
		entity.setValue("firstEdit");
		InheritedEntityMapper firstMapper = firstSession
				.getMapper(InheritedEntityMapper.class);
		firstMapper.insertEntity(entity);
		firstSession.commit();
		Assert.assertEquals(new Integer(0), entity.getVersion());

		// Load same entity in second session
		SqlSession secondSession = MyBatisTestUtil.getSession();
		InheritedEntity secondEntity = new InheritedEntity();
		Long identity = entity.getId();
		InheritedEntityMapper secondMapper = secondSession
				.getMapper(InheritedEntityMapper.class);
		secondEntity = secondMapper.getById(identity);
		Assert.assertEquals(new Integer(0), secondEntity.getVersion());

		// Delete entity in first session
		entity = firstMapper.getById(entity.getId());
		firstMapper.deleteEntity(entity);
		firstSession.commit();
		firstSession.close();

		try {
			secondMapper.deleteEntity(secondEntity);
		} catch (PersistenceException e) {
			if (e.getCause() instanceof RemovedByAnotherUserException) {
				throw (RemovedByAnotherUserException) e.getCause();
			} else {
				throw e;
			}
		} finally {
			if (secondSession != null) {
				secondSession.close();
			}
		}
	}
}
