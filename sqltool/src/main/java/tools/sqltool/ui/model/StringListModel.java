/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package tools.sqltool.ui.model;

import java.util.ArrayList;
import java.util.List;
import javax.swing.AbstractListModel;

/**
 *
 * @author yy
 */
public class StringListModel extends AbstractListModel {
    private List<String> list = new ArrayList<String>();

    public StringListModel() {
    }

    
    public StringListModel(List<String> list) {
        this.list = list;
    }

    public List<String> getList() {
        return list;
    }

    public void setList(List<String> list) {
        this.list = list;
        this.fireContentsChanged(this, 0, this.list.size());
    }
    
    
    
    @Override
    public int getSize() {
        return list.size();
    }

    @Override
    public Object getElementAt(int index) {
        return list.get(index);
    }
    
}
