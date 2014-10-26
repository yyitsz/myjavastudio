using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SimpleCrm.Facade;
using SimpleCrm.DTO;
using SimpleCrm.Utils;
using SimpleCrm.Model;

namespace SimpleCrm.PendingItemForm
{
    public partial class PendingItemListForm : SimpleCrm.BaseForm
    {
        public PendingItemCategory PendingItemCategory { get; set; }

        private BindingList<PendingItemDto> todayPendingItems;
        private BindingList<PendingItemDto> futurePendingItems;

        public PendingItemListForm()
        {
            InitializeComponent();
        }

        private void CustomerMainForm_Load(object sender, EventArgs e)
        {
            InitForm();
            SearchTodayPendingItems();
        }

        private void InitForm()
        {
            // ComboBoxUtil.BindLov(LovType.InsurancePolicyCategory, colCategory);
            //ComboBoxUtil.BindLov(LovType.InsurancePolicyStatus, colStatus);

            this.Text = "保单列表 - ";
            this.ribbonBarMergeContainer1.RibbonTabText = this.Text;
        }

        private void SearchTodayPendingItems()
        {
            DateTime fromDate = DateTime.Today;
            DateTime toDate = fromDate;
            List<PendingItemDto> list = AppFacade.Facade.SearchBirthdayPendingItems(this.PendingItemCategory,fromDate,toDate);
            futurePendingItems = new BindingList<PendingItemDto>(list);
            this.grdFutureResult.DataSource = todayPendingItems;
        }

        private void SearchFuturePendingItems()
        {
            DateTime fromDate = DateTime.Today;
            DateTime toDate = DateTime.Today.AddDays(30);
            List<PendingItemDto> list = AppFacade.Facade.SearchBirthdayPendingItems(this.PendingItemCategory, fromDate, toDate);
            todayPendingItems = new BindingList<PendingItemDto>(list);
            this.grdTodayResult.DataSource = todayPendingItems;
        }

        private void grdResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var column = grdTodayResult.Columns[e.ColumnIndex];
                var row = grdTodayResult.Rows[e.RowIndex];
                PendingItemDto dto = row.DataBoundItem as PendingItemDto;
                if (dto == null)
                {
                    return;
                }
                long insurancePolicyId = dto.RefId.Value;

                if (column.Name == "colEdit")
                {

                }

            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(ex);
            }
        }


        private void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                this.SearchTodayPendingItems();
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(ex);
            }
        }

        private void tabPending_SelectedTabChanging(object sender, DevComponents.DotNetBar.TabStripTabChangingEventArgs e)
        {
            try
            {

                if (e.NewTab == tiFuture && futurePendingItems == null)
                {
                    SearchFuturePendingItems();
                }
            }
            catch (System.Exception ex)
            {
                SimpleCrm.Utils.ExceptionHelper.HandleException(ex);
            }

        }

    }
}
