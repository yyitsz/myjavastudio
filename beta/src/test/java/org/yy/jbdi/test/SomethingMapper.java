/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package org.yy.jbdi.test;

import java.sql.ResultSet;
import java.sql.SQLException;
import org.skife.jdbi.v2.StatementContext;
import org.skife.jdbi.v2.tweak.ResultSetMapper;

/**
 *
 * @author yy
 */
public class SomethingMapper implements ResultSetMapper<Something>{

    @Override
    public Something map(int index, ResultSet r, StatementContext ctx) throws SQLException {
        Something s = new Something();
        s.setId(r.getInt(1));
        s.setName(r.getString(2));
        return s;
    }
    
}
