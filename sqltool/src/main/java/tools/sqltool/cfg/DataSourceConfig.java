/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package tools.sqltool.cfg;

/**
 *
 * @author yy
 */
public class DataSourceConfig {
//     jdbc.driver=oracle.jdbc.pool.OracleDataSource
//                jdbc.url=jdbc:oracle:thin:@10.100.53.97:1521:orcl11g2
//                jdbc.user.src=app
//                jdbc.password.src=appabc123
//                jdbc.minPoolSize=0
//                jdbc.maxPoolSize=8
//                jdbc.initialPoolSize=4
//                jdbc.connectionWaitTimeout=300
//                jdbc.maxIdleTime=3600
    private String driver;
    private String url;
    private String user;
    private String password;

    public String getDriver() {
        return driver;
    }

    public void setDriver(String driver) {
        this.driver = driver;
    }

    public String getUrl() {
        return url;
    }

    public void setUrl(String url) {
        this.url = url;
    }

    public String getUser() {
        return user;
    }

    public void setUser(String user) {
        this.user = user;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    @Override
    public String toString() {
        return "DataSourceConfig{" + "driver=" + driver + ", url=" + url + ", user=" + user + ", password=" + password + '}';
    }
    
    
}
