/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package tools.sqltool.ui.model;

/**
 *
 * @author yy
 */
public class ValueName {

    private String value;
    private String name;

    public ValueName( String name, String value) {
        this.value = value;
        this.name = name;
    }

    
    public String getValue() {
        return value;
    }

    public void setValue(String value) {
        this.value = value;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    @Override
    public String toString() {
        return name;
    }
}
