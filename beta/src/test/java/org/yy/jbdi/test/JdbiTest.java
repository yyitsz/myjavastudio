/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package org.yy.jbdi.test;

import javax.sql.DataSource;
import org.h2.jdbcx.JdbcConnectionPool;
import org.hamcrest.CoreMatchers;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;
import org.skife.jdbi.v2.DBI;
import org.skife.jdbi.v2.Handle;
import org.skife.jdbi.v2.util.StringMapper;

/**
 *
 * @author yy
 */
public class JdbiTest {

    public JdbiTest() {
    }

    @BeforeClass
    public static void setUpClass() {
    }

    @AfterClass
    public static void tearDownClass() {
    }

    @Before
    public void setUp() {
    }

    @After
    public void tearDown() {
    }
    // TODO add test methods here.
    // The methods must be annotated with annotation @Test. For example:
    //

    @Test
    public void test1() {

        DataSource ds = JdbcConnectionPool.create("jdbc:h2:mem:test", "username", "password");
        DBI dbi = new DBI(ds);
        Handle handle = dbi.open();
        handle.execute("create table something (id int primary key, name varchar(100))");

        handle.execute("insert into something (id, name) values (?, ?)", 1, "Brian");
        String name = handle.createQuery("select name from something where id = :id")
                .bind("id", 1)
                .map(new StringMapper())
                .first();
        assertThat(name, CoreMatchers.equalTo("Brian"));



        handle.close();




    }

    @Test
    public void test2() {

        DataSource ds = JdbcConnectionPool.create("jdbc:h2:mem:test", "username", "password");
        DBI dbi = new DBI(ds);
        SomethingDao dao = dbi.open(SomethingDao.class);
      //  dao.createTestTable();

        dao.insert(2, "Allan");
        String name = dao.findNameById(2);
        assertThat(name, CoreMatchers.equalTo("Allan"));

        Something s = dao.findById(2);
        assertThat(s.getName(), CoreMatchers.equalTo("Allan"));
        
         s = dao.findById(3);
        assertThat(s, CoreMatchers.nullValue());
        dao.close();




    }
}
