/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package tools.sqltool.ui.model;

import javax.swing.table.AbstractTableModel;
import tools.sqltool.lov.LovRow;
import tools.sqltool.lov.LovTable;

/**
 *
 * @author yy
 */
public class LovTableModel extends AbstractTableModel {

    private LovTable lovTable;
    private boolean changed;

    public LovTableModel() {
    }

    public LovTableModel(LovTable tableMapper) {
        this.lovTable = tableMapper;
    }

    public boolean isChanged() {
        return changed;
    }

    public void setChanged(boolean changed) {
        this.changed = changed;
    }

    public LovTable getLovTable() {
        return lovTable;
    }

    public void setLovTable(LovTable lovTable) {
        this.lovTable = lovTable;
        this.fireTableDataChanged();
    }

    @Override
    public int getRowCount() {
        if (lovTable != null && lovTable.getRows() != null) {
            return lovTable.getRows().size();
        }
        return 0;
    }

    @Override
    public int getColumnCount() {
        return 6;
    }

    @Override
    public Object getValueAt(int rowIndex, int columnIndex) {
        if (rowIndex < getRowCount()) {
            LovRow colMapper = lovTable.getRows().get(rowIndex);
            Object value = "";
            switch (columnIndex) {
                case 0:
                    value = colMapper.getCode();
                    break;
                case 1:
                    value = colMapper.getName();
                    break;
                case 2:
                    value = colMapper.getSeq();
                    break;
                case 3:
                    value = colMapper.getOldCode();
                    break;
                case 4:
                    value = colMapper.getRemark();
                    break;
                case 5:
                    value = colMapper.getGroupName();
                    break;
                default:
                    throw new IndexOutOfBoundsException(columnIndex + " is greater than the max column count (5)");
            }
            if (value == null) {
                return "";
            } else {
                return value;
            }

        } else {
            throw new IndexOutOfBoundsException(rowIndex + " is not between 0 and " + getColumnCount());
        }
    }

    @Override
    public String getColumnName(int column) {
        String value = null;
        switch (column) {
            case 0:
                value = "Code";
                break;
            case 1:
                value = "Name";
                break;
            case 2:
                value = "Sequence";
                break;
            case 3:
                value = "Old Code";
                break;
            case 4:
                value = "Remark";
                break;
            case 5:
                value = "Group Name";
                break;
            default:
                throw new IndexOutOfBoundsException(column + " is greater than the max column count (5)");
        }
        return value;
    }

    @Override
    public void setValueAt(Object aValue, int rowIndex, int columnIndex) {
        if (rowIndex < getRowCount()) {
            LovRow colMapper = lovTable.getRows().get(rowIndex);
            String value = String.valueOf(aValue);
            switch (columnIndex) {
                case 0:
                    colMapper.setCode(value);
                    break;
                case 1:
                    colMapper.setName(value);
                    break;
                case 2:
                    colMapper.setSeq(value);
                    break;
                case 3:
                    colMapper.setOldCode(value);
                    break;
                case 4:
                    colMapper.setRemark(value);
                    break;
                case 5:
                    colMapper.setGroupName(value);
                    break;
                default:
                    throw new IndexOutOfBoundsException(columnIndex + " is greater than the max column count (5)");
            }

            fireTableCellUpdated(rowIndex, columnIndex);

        } else {
            throw new IndexOutOfBoundsException(rowIndex + " is not between 0 and " + getColumnCount());
        }
    }

    @Override
    public boolean isCellEditable(int rowIndex, int columnIndex) {

        return true;
    }

    public void addLovRow() {
        this.lovTable.getRows().add(new LovRow());
        this.fireTableRowsInserted(this.lovTable.getRows().size() - 1, this.lovTable.getRows().size() - 1);
    }

    public void deleteLovRow(int modelIndex) {
        this.lovTable.removeLovRow(modelIndex);
        this.fireTableRowsDeleted(modelIndex, modelIndex);
    }
}
