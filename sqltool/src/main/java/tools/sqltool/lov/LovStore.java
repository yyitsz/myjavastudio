/**
 * To change this template, choose Tools | Templates and open the template in
 * the editor.
 */
package tools.sqltool.lov;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.FilenameFilter;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.util.HashMap;
import java.util.Map;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import tools.sqltool.utils.Assert;
import tools.sqltool.utils.JaxbUtils;

/**
 *
 * @author yyi
 */
public class LovStore {

    public static final String LOV_FOLDER = "lov";
    private static Logger logger = LoggerFactory.getLogger(LovStore.class);
    private String storeFolder;
    private JaxbUtils jaxbUtils = new JaxbUtils("tools.sqltool.lov");
    private Map<String, LovTable> lovTables = new HashMap<String, LovTable>();

    public String getMapperFolder() {
        return storeFolder;
    }

    public Map<String, LovTable> getMappers() {
        return lovTables;
    }

    public LovStore(String storeFolder) {
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

    public void save() {
        for (LovTable lovTable : lovTables.values()) {
            saveLovTable(lovTable);
        }
    }

    public void load() {
        lovTables.clear();
        File folder = new File(storeFolder);
        File[] listFiles = folder.listFiles(new FilenameFilter() {
            @Override
            public boolean accept(File dir, String name) {
                if (name.endsWith(".xml")) {
                    return true;
                }
                return false;
            }
        });
        for (File file : listFiles) {
            LovTable mapper = loadLovTable(file);
            if (mapper != null) {
                lovTables.put(mapper.getTableName(), mapper);
            }
        }

    }

    public void saveLovTable(LovTable lovTable) {

        lovTables.put(lovTable.getTableName(), lovTable);

        String fullname = getFullFileName(lovTable.getTableName());
        OutputStreamWriter writer = null;
        try {
            writer = new OutputStreamWriter(new FileOutputStream(fullname, false), "UTF-8");
            jaxbUtils.marshal(lovTable, writer);
        } catch (IOException ex) {
            throw new RuntimeException("Can not save mapper " + lovTable.toString(), ex);
        } finally {
            try {
                writer.close();
            } catch (IOException ex) {
            }
        }

    }

    private String getFullFileName(String tableName) {
        return storeFolder + tableName + ".xml";
    }

    public LovTable loadLovTable(File file) {

        InputStreamReader reader = null;
        try {
            reader = new InputStreamReader(new FileInputStream(file), "UTF-8");
            LovTable mapper = (LovTable) jaxbUtils.unmarshal(reader);
            return mapper;
        } catch (IOException ex) {
            logger.warn("Failed to load mapper " + file.getName(), ex);
            return null;
        } finally {
            try {
                reader.close();
            } catch (IOException ex) {
            }
        }

    }

    public LovTable loadLovTable(String tablename) {
        String fullname = storeFolder + tablename + ".xml";
        if (new File(fullname).exists() == false) {
            return null;
        }
        InputStreamReader reader = null;
        try {
            reader = new FileReader(fullname);
            LovTable mapper = (LovTable) jaxbUtils.unmarshal(reader);
            return mapper;
        } catch (IOException ex) {
            throw new RuntimeException("Failed to load mapper " + tablename, ex);
        } finally {
            try {
                reader.close();
            } catch (IOException ex) {
            }
        }
    }

    public LovTable getLovTable(String lovTableName) {
        return this.lovTables.get(lovTableName);
    }

    public boolean deleteLovTable(String lovTableName) {
        LovTable lovTable = this.lovTables.remove(lovTableName);
        if (lovTable != null) {

            String fullname = getFullFileName(lovTable.getTableName());
            File file = new File(fullname);
            if (file.exists()) {
                return file.delete();
            }
        }
        return true;
    }

    public String genAllMergeIntoSql() {
        StringBuilder sb = new StringBuilder();
        for (LovTable table : lovTables.values()) {
            sb.append(table.genMergeIntoSql());
        }
        return sb.toString();
    }

    public String genAllInsertSql() {
        StringBuilder sb = new StringBuilder();
        for (LovTable table : lovTables.values()) {
            sb.append(table.genInsertSql());
        }
        return sb.toString();
    }

    public void genJavaClass(String folder) {
        File file = new File(folder);
        if (file.exists() == false) {
            if (file.mkdirs() == false) {
                throw new RuntimeException("The folder " + folder + " can not be created.");
            }
        }

        for (LovTable table : lovTables.values()) {
            if (table.isGenEnumClass()) {
                JavaClass javaClass = table.genJavaClass();
                OutputStreamWriter writer = null;
                try {

                    File javaFile = new File(file, javaClass.getClassName() + ".java");
                    writer = new OutputStreamWriter(new FileOutputStream(javaFile, false), "UTF-8");
                    writer.write(javaClass.getCode());
                } catch (IOException ex) {
                    throw new RuntimeException(javaClass.getClassName() + " can not be generated in folder " + folder, ex);
                } finally {
                    try {
                        writer.close();
                    } catch (IOException ex) {
                    }
                }
            }
        }

    }
}
