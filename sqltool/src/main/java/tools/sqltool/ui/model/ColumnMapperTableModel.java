/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package tools.sqltool.ui.model;

import java.util.ArrayList;
import java.util.List;
import javax.swing.table.AbstractTableModel;
import tools.sqltool.mapper.ColumnMapper;
import tools.sqltool.mapper.TableMapper;

/**
 *
 * @author yy
 */
public class ColumnMapperTableModel extends AbstractTableModel {

    private TableMapper tableMapper;

    public ColumnMapperTableModel() {
    }

    public ColumnMapperTableModel(TableMapper tableMapper) {
        this.tableMapper = tableMapper;
    }

    public TableMapper getTableMapper() {
        return tableMapper;
    }

    public void setTableMapper(TableMapper mapper) {
        this.tableMapper = mapper;
    }

    public void updateSrcColumnMapper(List<ColumnMapper> srcMappers) {
        for (ColumnMapper oldMapper : this.tableMapper.getColumnMappers()) {
            if (oldMapper.getSrcName() != null && oldMapper.getSrcName().isEmpty() == false) {
                ColumnMapper srcFound = null;
                for (ColumnMapper srcMapper : srcMappers) {
                    if (srcMapper.getDestName().equalsIgnoreCase(oldMapper.getSrcName())) {
                        srcFound = srcMapper;
                        break;
                    }
                }
                if (srcFound != null) {
                    oldMapper.setSrcComment(srcFound.getDestComment());
                    oldMapper.setSrcType(srcFound.getDestType());
                } else {
                    oldMapper.setSrcComment(null);
                    oldMapper.setSrcType(null);
                    oldMapper.setSrcSql(null);
                    oldMapper.setSrcName(null);
                }
            }
        }
        this.fireTableDataChanged();
    }

    public void mergeColumnMapper(List<ColumnMapper> mappers) {
        List<ColumnMapper> newMappers = new ArrayList<ColumnMapper>(mappers);
        List<ColumnMapper> removeMappers = new ArrayList<ColumnMapper>();
        for (ColumnMapper oldMapper : this.tableMapper.getColumnMappers()) {
            ColumnMapper found = null;
            for (ColumnMapper newMapper : mappers) {
                if (newMapper.getDestName().equalsIgnoreCase(oldMapper.getDestName())) {
                    found = newMapper;
                    break;
                }
            }
            if (found != null) {
                newMappers.remove(found);
                oldMapper.setDestComment(found.getDestComment());
                oldMapper.setDestType(found.getDestType());
            } else {
                removeMappers.add(oldMapper);
            }
        }
        this.tableMapper.getColumnMappers().removeAll(removeMappers);
        this.tableMapper.getColumnMappers().addAll(newMappers);

        this.fireTableDataChanged();
    }

    @Override
    public int getRowCount() {
        if (tableMapper != null && tableMapper.getColumnMappers() != null) {
            return tableMapper.getColumnMappers().size();
        }
        return 0;
    }

    @Override
    public int getColumnCount() {
        return 5;
    }

    @Override
    public Object getValueAt(int rowIndex, int columnIndex) {
        if (rowIndex < getRowCount()) {
            ColumnMapper colMapper = tableMapper.getColumnMappers().get(rowIndex);
            Object value = "";
            switch (columnIndex) {
                case 0:
                    value = colMapper.getDestName();
                    break;
                case 1:
                    value = colMapper.getDestComment();
                    break;
                case 2:
                    value = colMapper.getSrcName();
                    break;
                case 3:
                    value = colMapper.getSrcSql();
                    break;
                case 4:
                    value = colMapper.getSrcComment();
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
                value = "Dest Column Name";
                break;
            case 1:
                value = "Dest Column Comment";
                break;
            case 2:
                value = "Src Column Name";
                break;
            case 3:
                value = "Src Column Sql";
                break;
            case 4:
                value = "Src Column Comment";
                break;
            default:
                throw new IndexOutOfBoundsException(column + " is greater than the max column count (5)");
        }
        return value;
    }

    @Override
    public void setValueAt(Object aValue, int rowIndex, int columnIndex) {
        if (rowIndex < getRowCount()) {
            ColumnMapper colMapper = tableMapper.getColumnMappers().get(rowIndex);
            String value = String.valueOf(aValue);
            switch (columnIndex) {
                case 0:

                    break;
                case 1:

                    break;
                case 2:
                    colMapper.setSrcName(value);
                    break;
                case 3:
                    colMapper.setSrcSql(value);
                    break;
                case 4:
                    colMapper.setSrcComment(value);
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
        if (columnIndex < 2) {
            return false;
        }
        return true;
    }

    public void update(TableMapper newMapper) {
        this.tableMapper = newMapper;
        this.fireTableDataChanged();
    }
}
