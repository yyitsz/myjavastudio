/**
 * To change this template, choose Tools | Templates and open the template in
 * the editor.
 */
package tools.sqltool.lov;

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
public class LovRow implements Serializable {

    private String code;
    private String name;
    private String seq = "";
    private String remark = "";
    private String oldCode = "";
    private String groupName;

    public String getGroupName() {
        if (this.groupName == null) {
            return "";
        }
        return groupName;

    }

    public void setGroupName(String groupName) {
        this.groupName = groupName;
    }

    public String getCode() {
        return code;
    }

    public void setCode(String code) {
        this.code = code;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getSeq() {
        if (seq == null) {
            return "";
        }
        return seq;
    }

    public void setSeq(String seq) {
        this.seq = seq;
    }

    public String getRemark() {

        if (this.remark == null) {
            return "";
        }
        return remark;

    }

    public void setRemark(String remark) {
        this.remark = remark;
    }

    public String getOldCode() {
        if (oldCode == null) {
            return "";
        }
        return oldCode;
    }

    public void setOldCode(String oldCode) {
        this.oldCode = oldCode;
    }

    @Override
    public String toString() {
        return "LovRow{" + "code=" + code + ", name=" + name + ", seq=" + seq + ", remark=" + remark + ", oldCode=" + oldCode + '}';
    }
}
