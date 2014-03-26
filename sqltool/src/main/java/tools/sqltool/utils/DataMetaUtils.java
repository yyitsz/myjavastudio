/**
 * To change this template, choose Tools | Templates and open the template in
 * the editor.
 */
package tools.sqltool.utils;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.ResultSetMetaData;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import java.util.List;
import javax.sql.DataSource;
import tools.sqltool.cfg.DataSourceConfig;
import tools.sqltool.mapper.ColumnMapper;

/**
 *
 * @author yyi
 */
public class DataMetaUtils {

    private final static String COMMENT_SQL = "select column_name,comments  from USER_COL_COMMENTS where table_name= ? ";
    private final static String ALL_TABLE_SQL = "SELECT table_name FROM user_tables ORDER BY table_name";
    private DataSource ds;
    private DataSourceConfig dsConfig;

    public DataMetaUtils(DataSourceConfig dsCfg) {
        Assert.notNull(dsCfg);
        this.dsConfig = dsCfg;
        this.ds = DataSourceUtils.createDataSource(dsConfig);
    }

    public DataMetaUtils(DataSource ds) {
        this.ds = ds;
    }

    public List<ColumnMapper> getColumnMapperListByTable(String tableName) {
        String sql = createSelectSql(tableName);
        List<ColumnMapper> mappers = getColumnMapperListBySql(sql);
        fillComments(mappers, tableName);
        return mappers;
    }

    public List<ColumnMapper> getColumnMapperListBySql(String sql) {
        return executeQuerySql(sql, new QueryAction< List<ColumnMapper>>() {
            @Override
            public List<ColumnMapper> callback(ResultSet rs) throws SQLException {
                ResultSetMetaData metaData = rs.getMetaData();
                return convertToMapper(metaData);
            }
        });
    }

    public <T> T executeQuerySql(String sql, QueryAction<T> action, Object... args) {
        Connection connection = null;
        ResultSet rs = null;
        PreparedStatement statement = null;
        try {
            connection = ds.getConnection();
            statement = connection.prepareStatement(sql);
            if (args != null) {
                for (int i = 0; i < args.length; i++) {
                    statement.setObject(i + 1, args[i]);
                }
            }
            rs = statement.executeQuery();
            return action.callback(rs);
        } catch (SQLException ex) {
            throw new RuntimeException("Failed to execute sql : " + sql, ex);
        } finally {
            closeStatement(statement);
            closeResultSet(rs);
            closeConnection(connection);
        }
    }

    private String createSelectSql(String tableName) {
        return "SELECT * FROM " + tableName + " WHERE 1 = 2";
    }

    public String desc(ResultSetMetaData metaData) {
        try {
            Assert.notNull(metaData);
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i <= metaData.getColumnCount(); i++) {
                sb.append(metaData.getColumnName(i))
                        .append(":")
                        .append(metaData.getColumnLabel(i))
                        .append(":")
                        .append(metaData.getColumnType(i));
                sb.append("\n");
            }

            return sb.toString();
        } catch (SQLException ex) {
            throw new RuntimeException(ex.getMessage(), ex);
        }
    }

    public List<ColumnMapper> convertToMapper(ResultSetMetaData metaData) {
        Assert.notNull(metaData);
        List<ColumnMapper> mappers = new ArrayList<ColumnMapper>();
        try {
            for (int i = 1; i <= metaData.getColumnCount(); i++) {
                ColumnMapper mapper = new ColumnMapper();
                mappers.add(mapper);
                mapper.setDestName(metaData.getColumnName(i));
                mapper.setDestType(metaData.getColumnTypeName(i));
            }

            return mappers;
        } catch (SQLException ex) {
            throw new RuntimeException(ex.getMessage(), ex);
        }
    }

    public void fillComments(final List<ColumnMapper> mappers, String tableName) {
        executeQuerySql(COMMENT_SQL, new QueryAction<Object>() {
            @Override
            public Object callback(ResultSet rs) throws SQLException {
                for (; rs.next();) {
                    String colName = rs.getString(1);
                    for (ColumnMapper mapper : mappers) {
                        if (colName.equalsIgnoreCase(mapper.getDestName())) {
                            String comment = rs.getString(2);
                            if (comment != null) {
                                comment = comment.trim();
                            }
                            mapper.setDestComment(comment);
                            break;
                        }
                    }
                }
                return null;
            }
        }, tableName);
    }

    public List<String> getTableNameList() {
        return executeQuerySql(ALL_TABLE_SQL, new QueryAction<List<String>>() {
            @Override
            public List<String> callback(ResultSet rs) throws SQLException {
                List<String> result = new ArrayList<String>();
                for (; rs.next();) {
                    String tabName = rs.getString(1);
                    result.add(tabName);
                }
                return result;
            }
        });
    }

    public List<String> getLovTableNameList() {
        List<String> tableNameList = getTableNameList();
        List<String> result = new ArrayList<String>();
        for (String table : tableNameList) {
            if (table.startsWith("L_")) {
                result.add(table);
            }
        }
        return result;
    }
    
    public void close() {
        if(ds != null) {
            DataSourceUtils.close(ds);
        }
    }

    public static void closeConnection(Connection connection) {
        if (connection != null) {
            try {
                connection.close();
            } catch (SQLException ex) {
            }
        }
    }

    public static void closeResultSet(ResultSet rs) {
        if (rs != null) {
            try {
                rs.close();
            } catch (SQLException ex) {
            }
        }
    }

    public static void closeStatement(Statement statement) {
        if (statement != null) {
            try {
                statement.close();
            } catch (SQLException ex) {
            }
        }
    }

    public static interface QueryAction<T> {

        T callback(ResultSet rs) throws SQLException;
    }
}
