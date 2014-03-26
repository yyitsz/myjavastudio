/**
 * To change this template, choose Tools | Templates and open the template in
 * the editor.
 */
package tools.sqltool.mapper;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;

/**
 *
 * @author yyi
 */
@XmlRootElement
@XmlType
@XmlAccessorType(XmlAccessType.FIELD)
public class TableMapper implements Serializable {
    //   private String mapperId;

    private String destTableName;
    private String destDbLink = "mfbms_dblink";
    private String srcTableName;
    private String srcSql;
    private String attachedSql;
    private boolean isGenerateDeleteSql;
    private boolean isGenerateCommitSql;
    private List<ColumnMapper> columnMappers = new ArrayList<ColumnMapper>();

    public boolean isIsGenerateDeleteSql() {
        return isGenerateDeleteSql;
    }

    public void setIsGenerateDeleteSql(boolean isGenerateDeleteSql) {
        this.isGenerateDeleteSql = isGenerateDeleteSql;
    }

    public boolean isIsGenerateCommitSql() {
        return isGenerateCommitSql;
    }

    public void setIsGenerateCommitSql(boolean isGenerateCommitSql) {
        this.isGenerateCommitSql = isGenerateCommitSql;
    }

    public String getMapperId() {
        return destTableName;
    }

    public String getDestDbLink() {
        return destDbLink;
    }

    public void setDestDbLink(String destDbLink) {
        this.destDbLink = destDbLink;
    }

    public String getDestTableName() {
        return destTableName;
    }

    public void setDestTableName(String destTableName) {
        this.destTableName = destTableName;
    }

    public String getSrcTableName() {
        return srcTableName;
    }

    public void setSrcTableName(String srcTableName) {
        this.srcTableName = srcTableName;
    }

    public String getSrcSql() {
        return srcSql;
    }

    public String getAttachedSql() {
        return attachedSql;
    }

    public void setAttachedSql(String attachedSql) {
        this.attachedSql = attachedSql;
    }

    public void setSrcSql(String srcSql) {
        this.srcSql = srcSql;
    }

    public List<ColumnMapper> getColumnMappers() {
        return columnMappers;
    }

    public void setColumnMappers(List<ColumnMapper> columnMappers) {
        if (columnMappers == null) {
            this.columnMappers = new ArrayList<ColumnMapper>();
        } else {
            this.columnMappers = columnMappers;
        }
    }

    @Override
    public String toString() {
        return "TableMapper{" + "destTableName=" + destTableName + ", srcTableName=" + srcTableName + ", srcSql=" + srcSql + ", columnMappers=" + columnMappers + '}';
    }

    public void updateSrcComment(int rowIndex, String colName, String srcComment, String srcSqlType) {
        if (rowIndex >= 0 && rowIndex < this.columnMappers.size()) {
            ColumnMapper m = this.columnMappers.get(rowIndex);
            m.setSrcComment(srcComment);
            m.setSrcType(srcSql);
        }
    }

    public String generateSql() {
        if (this.destTableName == null || this.destTableName.isEmpty()
                || (this.srcTableName == null || this.srcTableName.isEmpty())
                && (this.srcSql == null || this.srcSql.isEmpty())
                || this.columnMappers.isEmpty()) {
            return "";
        }
        //INSERT INTO tablename(xxx,xxx,xx) SELECT * FROM xxx WHERE xxxx
        StringBuilder sql = new StringBuilder();
        if (isGenerateDeleteSql) {
            sql.append("DELETE FROM ");

            sql.append(this.destTableName);
            if (this.destDbLink != null || this.destDbLink.isEmpty() == false) {
                sql.append("@").append(this.destDbLink);
            }
            sql.append(";\n");
        }
        sql.append("INSERT INTO ");
        sql.append(this.destTableName);
        if (this.destDbLink != null || this.destDbLink.isEmpty() == false) {
                sql.append("@").append(this.destDbLink);
            }
        sql.append("(");

        StringBuilder insertColumns = new StringBuilder();
        StringBuilder selectColumns = new StringBuilder();
        for (int i = 0; i < this.columnMappers.size(); i++) {
            ColumnMapper map = this.columnMappers.get(i);
            insertColumns.append(map.getDestName());
            if (map.getSrcSql() != null && map.getSrcSql().isEmpty() == false) {
                String tmpSrcSql = map.getSrcSql();
                if (map.getSrcName() != null && map.getSrcName().length() > 0) {
                    tmpSrcSql = tmpSrcSql.replace("${SRC}", map.getSrcName());
                }
                selectColumns.append("(").append(tmpSrcSql).append(")");
            } else if (map.getSrcName() != null && map.getSrcName().isEmpty() == false) {
                selectColumns.append(map.getSrcName());
            } else {
                selectColumns.append("null");
            }
            selectColumns.append(" AS " + map.getDestName()) ;
            if (i < this.columnMappers.size() - 1) {
                insertColumns.append(",");
                selectColumns.append(",");
            }
        }

        sql.append(insertColumns.toString())
                .append(") ")
                .append("\n")
                .append(" SELECT ")
                .append(selectColumns.toString())
                .append("\n")
                .append(" FROM ");

        if (this.srcTableName != null && this.srcTableName.isEmpty() == false) {
            sql.append(this.srcTableName)
                    .append(" src ");
            if (this.srcSql != null && this.srcSql.isEmpty() == false) {
                sql.append(" WHERE ").append(this.srcSql);
            }
        } else {
            sql.append("(")
                    .append(this.srcSql)
                    .append(") src ");
        }
        sql.append(";").append("\n");
        if (isGenerateCommitSql) {
            sql.append("commit;").append("\n");
        }
        if (attachedSql != null
                && attachedSql.length() > 0
                && attachedSql.charAt(attachedSql.length() - 1) != ';') {
            sql.append(attachedSql).append(";");
        }
        return sql.toString();
    }
}
