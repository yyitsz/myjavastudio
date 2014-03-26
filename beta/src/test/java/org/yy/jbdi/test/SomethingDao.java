/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package org.yy.jbdi.test;

import org.skife.jdbi.v2.sqlobject.Bind;
import org.skife.jdbi.v2.sqlobject.SqlQuery;
import org.skife.jdbi.v2.sqlobject.SqlUpdate;
import org.skife.jdbi.v2.sqlobject.customizers.Mapper;

/**
 *
 * @author yy
 */
public interface SomethingDao {
    @SqlUpdate("create table something (id int primary key, name varchar(100))")
    void createTestTable();
    @SqlUpdate("insert into something (id, name) values (:id, :name)")
    void insert(@Bind("id") int id, @Bind("name") String name);
    @SqlQuery("select name from something where id = :id")
    String findNameById(@Bind("id") int id);
    
    @Mapper(SomethingMapper.class)
    @SqlQuery("select id, name from something where id = :id")
    Something findById(@Bind("id") int id);
    
    void close();
}
