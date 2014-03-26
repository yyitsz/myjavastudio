/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package tools.sqltool.utils;

import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.sql.DataSource;
import oracle.jdbc.pool.OracleDataSource;
import tools.sqltool.cfg.DataSourceConfig;

/**
 *
 * @author yy
 */
public class DataSourceUtils {

    public static DataSource createDataSource(DataSourceConfig dsCfg) {
        try {

            OracleDataSource tmp = new OracleDataSource();
            tmp.setURL(dsCfg.getUrl());
            tmp.setUser(dsCfg.getUser());
            tmp.setPassword(dsCfg.getPassword());
            return tmp;
        } catch (SQLException ex) {
            throw new RuntimeException("Error when create datasource + " + dsCfg, ex);
        }
    }

    public static void close(DataSource ds) {
        try {
            OracleDataSource tmp = (OracleDataSource) ds;
            tmp.close();
        } catch (SQLException ex) {
            
        }
    }
}
