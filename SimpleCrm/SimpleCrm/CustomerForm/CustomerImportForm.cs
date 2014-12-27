using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SimpleCrm.DTO;
using System.Collections;
using SimpleCrm.Utils;
using SimpleCrm.Facade;

namespace SimpleCrm.CustomerForm
{
    public partial class CustomerImportForm : BaseForm
    {
        public CustomerImportForm()
        {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "CSV文件(*.csv)|*.csv|Excel文件(*.xls)|*.xls|Excel文件(*.xlsx)|*.xlsx";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var cusotmerImportDtoList = AppFacade.Facade.ImportCustomers(dlg.FileName);
                int total = cusotmerImportDtoList.Count();
                int successful = cusotmerImportDtoList.Where(c => c.ImportStatus == CustomerImportDto.SUCCESS).Count();
                int skipped = total - successful;
                this.lblMsg.Text = String.Format("总记录数:{0}, 成功导入:{1}, 曾经导入过:{2}。", total, successful, skipped);
                this.grdResult.DataSource = new SortableBindingList<CustomerImportDto>(cusotmerImportDtoList.Cast<CustomerImportDto>().ToList());
            }
        }


    }
}
