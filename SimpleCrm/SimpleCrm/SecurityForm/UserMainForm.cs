using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SimpleCrm.Utils;
using SimpleCrm.Manager;
using SimpleCrm.Model;
using System.Linq;
using SimpleCrm.Common;
using SimpleCrm.Facade;


namespace SimpleCrm.Security
{
    public partial class UserMainForm : SimpleCrm.BaseForm
    {

        public UserMainForm()
        {
            InitializeComponent();
        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                SearchData();
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(ex);
            }
        }

        private int SearchData()
        {
            User user = new User();
            if (txtUserId.Text.Trim().Length > 0)
            {
                user.UserId = txtUserId.Text.Trim();
            }
            IList<User> list = AppFacade.Facade.SearchUserByExample(user);

            grdResult.DataSource = new BindingList<User>(list);
            return list.Count;
        }

        private void grdResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                String name = grdResult.Columns[e.ColumnIndex].Name;
                User user = grdResult.Rows[e.RowIndex].DataBoundItem as User;
                if (name == "colDelete")
                {
                    if (user.UserId == "admin")
                    {
                        MessageBoxHelper.ShowPrompt("admin user can not be deleted.");
                        return;
                    }
                    if (user != null
                        && MessageBoxHelper.ShowYesNo("Are you sure to delete this record?") == DialogResult.Yes)
                    {
                        if (user.UserId != null)
                        {
                            AppFacade.Facade.DeleteUser(user);
                        }
                        grdResult.Rows.RemoveAt(e.RowIndex);
                    }
                }
                else if (name == "colEdit")
                {

                    UserDetailForm form = new UserDetailForm();
                    form.StartPosition = FormStartPosition.CenterParent;
                    form.User = user;
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        SearchData();
                    }

                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(ex);
            }

        }

        private void UserMain_Load(object sender, EventArgs e)
        {
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                UserDetailForm form = new UserDetailForm();
                form.StartPosition = FormStartPosition.CenterParent;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    SearchData();
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(ex);
            }
        }

    }
}
