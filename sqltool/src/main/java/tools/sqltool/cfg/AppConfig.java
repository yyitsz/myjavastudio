/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package tools.sqltool.cfg;

import java.util.logging.Level;
import java.util.logging.Logger;
import java.util.prefs.BackingStoreException;
import java.util.prefs.Preferences;

/**
 *
 * @author yy
 */
public class AppConfig {

    public static final String ROOT_PATH = "com/sqltool";
    public static final String COMMON_PATH = ROOT_PATH + "/common";
    public static final String DS_PATH = ROOT_PATH + "/datasource";
    public static final String WK_KEY = "workspace";
    
    public static final String DEST_DS = "destds";
    public static final String SRC_DS = "srcds";

    public static String getWorkspace() {
        Preferences commNode = Preferences.userRoot().node(COMMON_PATH);
        String result = commNode.get("workspace", System.getProperty("user.home") + "/sqltool/");
        result = result.replace('\\', '/');
        if(result.endsWith("/") == false) {
            result += "/";
        }
        return result;
    }

    public static void setWorkspace(String workspace) {
        Preferences commNode = Preferences.userRoot().node(COMMON_PATH);
        commNode.put(WK_KEY, workspace);
        try {
            commNode.flush();
        } catch (BackingStoreException ex) {
            throw new RuntimeException(ex.getMessage(), ex);
        }
    }

    public static String getParameter(String key, String defaultValue) {
        Preferences commNode = Preferences.userRoot().node(COMMON_PATH);
        String result = commNode.get(key.toLowerCase(), defaultValue);
        return result;
    }

    public static void setParameter(String key, String value) {
        Preferences commNode = Preferences.userRoot().node(COMMON_PATH);
        commNode.put(key.toLowerCase(), value);
        try {
            commNode.flush();
        } catch (BackingStoreException ex) {
            throw new RuntimeException(ex.getMessage(), ex);
        }
    }
    
    

    public static DataSourceConfig getDSConfig(String dsName) {
        try {
            Preferences dsNode = Preferences.userRoot().node(DS_PATH);
            if (dsNode.nodeExists(dsName)) {
                dsNode = dsNode.node(dsName);
                DataSourceConfig config = new DataSourceConfig();
                //config.setDriver(dsNode.get("driver", null));
                config.setUrl(dsNode.get("url", null));
                config.setUser(dsNode.get("user", null));
                config.setPassword(dsNode.get("password", null));

                return config;
            }
        } catch (BackingStoreException ex) {
            throw new RuntimeException(ex.getMessage(), ex);
        }
        return null;
    }

    public static void setDSConfig(String dsName, DataSourceConfig config) {
        try {
            Preferences dsNode = Preferences.userRoot().node(DS_PATH + "/" +  dsName);

          
            //dsNode.put("driver", config.getDriver());
            dsNode.put("url", config.getUrl());
            dsNode.put("user", config.getUser());
            dsNode.put("password", config.getPassword());
            dsNode.flush();

        } catch (BackingStoreException ex) {
            throw new RuntimeException(ex.getMessage(), ex);
        }
    }
}
