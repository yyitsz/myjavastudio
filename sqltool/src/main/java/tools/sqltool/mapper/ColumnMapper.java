/**
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package tools.sqltool.mapper;

import java.io.Serializable;
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
public class ColumnMapper implements Serializable{
    private String destName;
    private String destComment;
    private String destType;
    private String srctype;
    private String srcName;
    private String srcSql;
    private String srcComment;
    private String lovTable;
    
    public ColumnMapper() {
    }

    public ColumnMapper(String destColumnName, String destColumnComment) {
        this.destName = destColumnName;
        this.destComment = destColumnComment;
    }
    
    public String getDestType() {
        return destType;
    }

    public void setDestType(String destType) {
        this.destType = destType;
    }

    public String getSrcType() {
        return srctype;
    }

    public void setSrcType(String srctype) {
        this.srctype = srctype;
    }

    
    public String getDestName() {
        return destName;
    }

    
    public void setDestName(String destColumnName) {
        this.destName = destColumnName;
    }

    public String getDestComment() {
        return destComment;
    }

    public void setDestComment(String destColumnComment) {
        this.destComment = destColumnComment;
    }

    public String getSrcName() {
        return srcName;
    }

    public void setSrcName(String srcColumnName) {
        this.srcName = srcColumnName;
    }

    public String getSrcSql() {
        return srcSql;
    }

    public void setSrcSql(String srcSql) {
        this.srcSql = srcSql;
    }

    public String getSrcComment() {
        return srcComment;
    }

    public void setSrcComment(String srcColumnComment) {
        this.srcComment = srcColumnComment;
    }

    public String getSrctype() {
        return srctype;
    }

    public void setSrctype(String srctype) {
        this.srctype = srctype;
    }

    public String getLovTable() {
        return lovTable;
    }

    public void setLovTable(String lovTable) {
        this.lovTable = lovTable;
    }

    @Override
    public String toString() {
        return "ColumnMapper{" + "destName=" + destName + ", destComment=" + destComment + ", destType=" + destType + ", srctype=" + srctype + ", srcName=" + srcName + ", srcSql=" + srcSql + ", srcComment=" + srcComment + ", lovTable=" + lovTable + '}';
    }

    
   
    
    
}
