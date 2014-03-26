/**
 * To change this template, choose Tools | Templates and open the template in
 * the editor.
 */
package tools.sqltool.lov;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.List;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlTransient;
import javax.xml.bind.annotation.XmlType;
import tools.sqltool.utils.Assert;

/**
 *
 * @author yyi
 */
@XmlRootElement
@XmlType
@XmlAccessorType(XmlAccessType.FIELD)
public class LovTable implements Serializable {

    @XmlTransient
    private boolean changed;
    private String tableName;
    private boolean genDeleteSql = true;
    private boolean genEnumClass;
    private String fullClassName = "";
    private List<LovRow> rows = new ArrayList<LovRow>();

    public boolean isChanged() {
        return changed;
    }

    public void setChanged(boolean changed) {
        this.changed = changed;
    }

    public boolean isGenEnumClass() {
        return genEnumClass;
    }

    public void setGenEnumClass(boolean genEnumClass) {
        if(genEnumClass != this.genEnumClass) {
            this.genEnumClass = genEnumClass;
            changed = true;
        }
    }

    public String getFullClassName() {
        return fullClassName;
    }

    public void setFullClassName(String fullClassName) {
        if(this.fullClassName.equals(fullClassName) == false) {
            this.fullClassName = fullClassName;
            changed = true;
        }
    }

    public boolean isGenDeleteSql() {
        return genDeleteSql;
    }

    public void setGenDeleteSql(boolean genDeleteSql) {
        this.genDeleteSql = genDeleteSql;
    }

    public String getTableName() {
        return tableName;
    }

    public void setTableName(String tableName) {
        this.tableName = tableName;
    }

    public List<LovRow> getRows() {
        return rows;
    }

    public void setRows(List<LovRow> rows) {
        this.rows = rows;
    }

    public String genInsertSql() {
        //INSERT INTO "L_BANK" VALUES ('91', '邮政储汇', '39', 'Y', null, 'admin', TO_DATE('2013-03-30 15:06:21','YYYY-MM-DD HH24:MI:SS'), 'admin', TO_DATE('2013-03-30 15:06:21','YYYY-MM-DD HH24:MI:SS'), '0', '0');
        StringBuilder sb = new StringBuilder();
        sb.append("DELETE FROM ").append(tableName).append(";\n");
        for (LovRow row : rows) {
            StringBuilder rowSb = new StringBuilder();
            String remark = row.getRemark();
//            if (remark.isEmpty()) {
//                remark = row.getOldCode();
//            }

            rowSb.append("INSERT INTO ")
                    .append(tableName)
                    .append("(CODE,VAL,SEQ,GRP_NAME,IS_ACTIVE,REMARK,CREATED_BY,CREATE_TIME,UPDATED_BY,UPDATE_TIME,REC_VER,TAG_SEQ)")
                    .append(" VALUES(")
                    .append("'").append(row.getCode()).append("', ")
                    .append("'").append(row.getName()).append("', ")
                    .append(row.getSeq()).append(", ")
                     .append("'").append(row.getGroupName()).append("', ")
                    .append("'Y'").append(", ")
                    .append("'").append(remark).append("', ")
                    .append("'admin', sysdate, 'admin', sysdate, 0, 0")
                    .append(");")
                    .append("\n");
            sb.append(rowSb.toString());
        }


        return sb.toString();
    }

    public String genMergeIntoSql() {

//         MERGE INTO [your table-name] [rename your table here]
//
//USING ( [write your query here] )[rename your query-sql and using just like a table]
//
//ON ([conditional expression here] AND [...]...)
//
//WHEN MATHED THEN [here you can execute some update sql or something else ]
//
//WHEN NOT MATHED THEN [execute something else here ! ]

        StringBuilder sb = new StringBuilder();
        sb.append("MERGE INTO ")
                .append(tableName)
                .append(" target ").append("\n");
        sb.append("USING (");
        for (int i = 0; i < rows.size(); i++) {
            LovRow row = rows.get(i);
            StringBuilder rowSb = new StringBuilder();
            String remark = row.getRemark();
//            if (remark.isEmpty()) {
//                remark = row.getOldCode();
//            }
            rowSb.append("SELECT ")
                    .append("'").append(row.getCode()).append("' CODE, ")
                    .append("'").append(row.getName()).append("' VAL, ")
                    .append(row.getSeq()).append(" SEQ, ")
                     .append("'").append(row.getGroupName()).append("' GRP_NAME, ")
                    .append("'Y'").append(" IS_ACTIVE, ")
                    .append("'").append(remark).append("' REMARK ")
                    .append(" FROM DUAL \n");
            if (i < rows.size() - 1) {
                rowSb.append("UNION ALL \n");
            }
            sb.append(rowSb.toString());
        }

        sb.append(") src \n");
        sb.append("ON (src.code = target.code)\n");
        sb.append("WHEN MATCHED THEN UPDATE SET target.val = src.val, target.grp_name = src.grp_name,target.seq = src.seq, target.is_active = src.is_active, target.remark = src.remark, update_time = sysdate \n");
        sb.append("WHEN NOT MATCHED THEN INSERT(CODE,VAL,GRP_NAME,SEQ,IS_ACTIVE,REMARK,CREATED_BY,CREATE_TIME,UPDATED_BY,UPDATE_TIME,REC_VER,TAG_SEQ) ")
                .append(" VALUES (src.CODE,src.VAL,src.GRP_NAME,src.SEQ,src.IS_ACTIVE,src.REMARK,'admin',sysdate,'admin',sysdate,0,0);\n");


        return sb.toString();
    }

    public String genCaseSql(String columnName, boolean isNumber) {
        //CASE 
        StringBuilder sb = new StringBuilder();
        sb.append("CASE ")
                .append(columnName);
        for (int i = 0; i < rows.size(); i++) {
            LovRow row = rows.get(i);
            sb.append(" WHEN ");
            if (isNumber) {
                sb.append(" ").append(row.getOldCode()).append(" ");
            } else {
                sb.append("'").append(row.getOldCode()).append("' ");
            }
            sb.append("THEN '").append(row.getCode()).append("' ");
        }
        sb.append(" ELSE NULL END");
        return sb.toString();
    }

    public void removeLovRow(int rowIndex) {
        Assert.inRange(rowIndex, 0, this.rows.size() - 1);
        this.rows.remove(rowIndex);
    }

    public JavaClass genJavaClass() {
        String packageName = "";
        String className = this.tableName;
        if (fullClassName != null && fullClassName.length() > 0) {
            int loc = fullClassName.lastIndexOf(".");
            if (loc < 0) {
                className = fullClassName;
            } else if (loc < fullClassName.length() - 1) {
                packageName = fullClassName.substring(0, loc);
                className = fullClassName.substring(loc + 1);
            } else {
                throw new IllegalArgumentException(fullClassName + " is not legal class name.");
            }
        }
        StringBuilder sb = new StringBuilder();
        if (packageName != null && packageName.length() > 0) {
            sb.append("package ").append(packageName).append(";\n");
        }
        sb.append("public enum ").append(className).append("{\n");
        for (LovRow row : this.rows) {
            sb.append("    /**\n")
                    .append("    * ").append(row.getName()).append("\n")
                    .append("    */\n")
                    .append("    ").append(row.getCode()).append(",\n");

        }
        sb.append("}\n");
        JavaClass result = new JavaClass();
        result.setPackageName(packageName);
        result.setClassName(className);
        result.setCode(sb.toString());
        return result;
    }
}
