/**
 * To change this template, choose Tools | Templates and open the template in
 * the editor.
 */
package tools.sqltool.mapper;

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
public class MapperStore {

    public static final String MAPPER_FOLDER = "mappers";
    
    private static Logger logger = LoggerFactory.getLogger(MapperStore.class);
    private String mapperFolder;
    private JaxbUtils jaxbUtils = new JaxbUtils("tools.sqltool.mapper");
    private Map<String, TableMapper> mappers = new HashMap<String, TableMapper>();

    public String getMapperFolder() {
        return mapperFolder;
    }

    public Map<String, TableMapper> getMappers() {
        return mappers;
    }

    public MapperStore(String mapperFolder) {
        Assert.notNull(mapperFolder);
        this.mapperFolder = mapperFolder;
        this.mapperFolder = this.mapperFolder.replace('\\', '/');
        if (this.mapperFolder.endsWith("/") == false) {
            this.mapperFolder += "/";
        }
        File folder = new File(this.mapperFolder);
        if (folder.exists() == false) {
            folder.mkdirs();
        }

    }

    public void save() {
        for (TableMapper mapper : mappers.values()) {
            saveMapper(mapper);
        }
    }

    public void load() {
        mappers.clear();
        File folder = new File(mapperFolder);
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
            TableMapper mapper = loadMapper(file);
            if (mapper != null) {
                mappers.put(mapper.getMapperId(), mapper);
            }
        }

    }

    public void saveMapper(TableMapper mapper) {

        mappers.put(mapper.getMapperId(), mapper);

        String fullname = mapperFolder + mapper.getMapperId() + ".xml";
        OutputStreamWriter writer = null;
        try {
            writer = new OutputStreamWriter(new FileOutputStream(fullname, false), "UTF-8");
            jaxbUtils.marshal(mapper, writer);
        } catch (IOException ex) {
            throw new RuntimeException("Can not save mapper " + mapper.toString(), ex);
        } finally {
            try {
                writer.close();
            } catch (IOException ex) {
            }
        }

    }

    public TableMapper loadMapper(File file) {

        InputStreamReader reader = null;
        try {
            reader = new InputStreamReader(new FileInputStream(file), "UTF-8");
            TableMapper mapper = (TableMapper) jaxbUtils.unmarshal(reader);
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

    public TableMapper loadMapper(String mapperId) {
        String fullname = mapperFolder + mapperId + ".xml";
        if (new File(fullname).exists() == false) {
            return null;
        }
        InputStreamReader reader = null;
        try {
            reader = new FileReader(fullname);
            TableMapper mapper = (TableMapper) jaxbUtils.unmarshal(reader);
            return mapper;
        } catch (IOException ex) {
            throw new RuntimeException("Failed to load mapper " + mapperId, ex);
        } finally {
            try {
                reader.close();
            } catch (IOException ex) {
            }
        }
    }

    public TableMapper getMapper(String destTableName) {
        return this.mappers.get(destTableName);
    }
    
    
    public String genAllInsertSql() {
        StringBuilder sb = new StringBuilder();
        for (TableMapper table : mappers.values()) {
            sb.append(table.generateSql());
        }
        return sb.toString();
    }
}
