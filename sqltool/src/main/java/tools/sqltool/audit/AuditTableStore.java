/**
 * To change this template, choose Tools | Templates and open the template in
 * the editor.
 */
package tools.sqltool.audit;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.util.ArrayList;
import java.util.List;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import tools.sqltool.utils.Assert;

/**
 *
 * @author yyi
 */
public class AuditTableStore {

    public static final String AUDIT_FOLDER = "audit";
    private static Logger logger = LoggerFactory.getLogger(AuditTableStore.class);
    private String storeFolder;

    public AuditTableStore(String storeFolder) {
        Assert.notNull(storeFolder);
        this.storeFolder = storeFolder;
        this.storeFolder = this.storeFolder.replace('\\', '/');
        if (this.storeFolder.endsWith("/") == false) {
            this.storeFolder += "/";
        }
        File folder = new File(this.storeFolder);
        if (folder.exists() == false) {
            folder.mkdirs();
        }

    }

    public void save(List<String> tableList) {
        String fullname = getFullFileName();
        BufferedWriter writer = null;

        try {
            writer = new BufferedWriter(new OutputStreamWriter(new FileOutputStream(fullname, false), "UTF-8"));
            for (String s : tableList) {
                writer.write(s);
                writer.newLine();
            }
        } catch (IOException ex) {
            throw new RuntimeException("Can not save audit tables ", ex);
        } finally {
            try {
                writer.close();
            } catch (IOException ex) {
            }
        }
    }

    public List<String> load() {
        String fullname = getFullFileName();
        BufferedReader reader = null;
        List<String> result = new ArrayList<String>();
        File file = new File(fullname);
        if (file.exists()) {
            try {
                reader = new BufferedReader(new InputStreamReader(new FileInputStream(file), "UTF-8"));
                while (reader.ready()) {
                    String line = reader.readLine();
                    if (line != null && line.trim().length() > 0) {
                        result.add(line);
                    }
                }
            } catch (IOException ex) {
                throw new RuntimeException("Can not save audit tables ", ex);
            } finally {
                try {
                    reader.close();
                } catch (IOException ex) {
                }
            }
        }
        return result;
    }

    private String getFullFileName() {
        return storeFolder + "audit-tables.txt";
    }

}
