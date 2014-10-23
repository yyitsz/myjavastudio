using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using SimpleCrm.Utils;
using SimpleCrm.Model;
using SimpleCrm.Facade;


namespace SimpleCrm.MasterForm
{
    public partial class LovMainForm : BaseForm
    {

        public LovMainForm()
        {
            InitializeComponent();
        }

        private void LovMainForm_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        private void InitForm()
        {
            ComboBoxUtil.BindLovType(cmbLovType, true);
            ComboBoxUtil.BindLovType(colLovType, true);
            grdResult.ReadOnly = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateLoadCriteria())
                {
                    if (IsDataChanged() == false || MessageBoxHelper.ShowYesNo(ErrorCode.DATA_CHANGED) == System.Windows.Forms.DialogResult.Yes)
                    {
                        int count = SearchData();
                        cmbLovType.Enabled = false;
                        grdResult.ReadOnly = false;
                    }
                  
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(ex);
            }
        }

        private int SearchData()
        {
            List<Lov> list = AppFacade.Facade.GetLovByType(cmbLovType.SelectedValue.ToString());
           // list.MarkAsPersisted();
            grdResult.DataSource = new BindingList<Lov>(list);
            DisableCell();
            return list.Count;
        }

        private bool ValidateLoadCriteria()
        {
            if (ComboBoxUtil.Selected(cmbLovType) == false)
            {
                MessageBoxHelper.ShowPrompt(lblLovType.Text + "是必填的。");
                return false;
            }
            return true;
        }

        private void grdResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String name = grdResult.Columns[e.ColumnIndex].Name;
                if (name == "colDelete")
                {
                    Lov lov = grdResult.Rows[e.RowIndex].DataBoundItem as Lov;
                    if (lov != null 
                        && lov.Owner == Lov.OWNER_USER
                        && MessageBoxHelper.ShowYesNo(ErrorCode.DELETE_REC) == DialogResult.Yes)
                    {
                        if (lov.IsNew() == false)
                        {
                            AppFacade.Facade.DeleteLov(lov);
                        }
                        grdResult.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(ex);
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsDataChanged() == false || MessageBoxHelper.ShowYesNo(ErrorCode.DATA_CHANGED) == System.Windows.Forms.DialogResult.Yes)
                {
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(ex);
            }
        }

        private void ClearForm()
        {
            cmbLovType.Enabled = true;

            grdResult.DataSource = new BindingList<Lov>();

            grdResult.ReadOnly = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateData())
                {
                    if (MessageBoxHelper.ShowYesNo("保存记录吗?") == DialogResult.Yes)
                    {
                        AppFacade.Facade.SaveLov(this.grdResult.DataSource as IEnumerable<Lov>);
                        MessageBoxHelper.ShowPrompt(ErrorCode.SAVE_SUCCESS);
                        SearchData();
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(ex);
            }
        }

        private bool ValidateData()
        {
            Boolean result = true;
            foreach (DataGridViewRow row in grdResult.Rows)
            {
                Lov ac = row.DataBoundItem as Lov;
                if (ac != null)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.ErrorText = "";
                        DataGridViewColumn column = grdResult.Columns[cell.ColumnIndex];
                        if (column.Visible
                            && column.IsDataBound
                            && column.DataPropertyName.StartsWith("Attribute") == false
                            && String.IsNullOrEmpty(Convert.ToString(cell.Value)))
                        {
                            cell.ErrorText = column.HeaderText + " 是必填的.";
                            result = false;
                        }
                    }
                }
            }

            IList<Lov> lovList = grdResult.DataSource as IList<Lov>;
            foreach (Lov outer in lovList)
            {
                foreach (Lov inner in lovList)
                {
                    if (outer != inner 
                        &&( outer.Code == inner.Code
                        || outer.Name == inner.Name))
                    {
                        result = false;
                        MessageBoxHelper.ShowPrompt("编码或名称不能重复.");
                    }
                }
            }
            return result;
        }

        private void LovMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsDataChanged() &&  MessageBoxHelper.ShowYesNo(ErrorCode.DATA_CHANGED) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void DisableCell()
        {
            foreach (DataGridViewRow row in grdResult.Rows)
            {
                Lov lov = row.DataBoundItem as Lov;
                if (lov != null && row.IsNewRow == false)
                {
                    if (lov.Owner == Lov.OWNER_SYS)
                    {
                        row.Cells["colCode"].ReadOnly = true;
                        row.Cells["colCode"].Style.ForeColor = Color.Gray;
                    }
                }

            }
        }
        private bool IsDataChanged()
        {
            bool changed = false;
            IList<Lov> list = (grdResult.DataSource as IList<Lov>);
            if (list != null)
            {
                changed = list.IsChanged();
            }
            return changed;
        }


        private void grdResult_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            if (ComboBoxUtil.Selected(cmbLovType))
            {
                foreach (Lov lov in grdResult.DataSource as IList<Lov>)
                {
                    if (lov.LovType == null)
                    {
                        lov.LovType = cmbLovType.SelectedValue.ToString();
                    }
                }
            }
        }

    }
}
