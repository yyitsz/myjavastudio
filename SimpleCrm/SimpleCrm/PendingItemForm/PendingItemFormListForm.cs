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
using SimpleCrm.InsuranceForm;
using SimpleCrm.CustomerForm;
using DevComponents.DotNetBar.Controls;

namespace SimpleCrm.PendingItemForm
{
    public partial class PendingItemListForm : SimpleCrm.BaseForm
    {
        public PendingItemCategory? PendingItemCategory { get; set; }

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
            ComboBoxUtil.BindEnumType(typeof(PendingItemHandleResult), colFutureHandleResult, true);
            ComboBoxUtil.BindEnumType(typeof(PendingItemHandleResult), colTodayHandleResult, true);

            if (this.PendingItemCategory == Model.PendingItemCategory.Birthday)
            {
                colTodayInsurancePolicyNo.Visible = false;
                colFutureInsurancePolicyNo.Visible = false;
            }
            tabPending.SelectedTabIndex = 0;

            this.Text = "待办事项 - " + this.PendingItemCategory.GetDisplayName();
            this.ribbonBarMergeContainer1.RibbonTabText = this.Text;
        }

        private void SearchTodayPendingItems()
        {
            DateTime fromDate = DateTime.Today;
            DateTime toDate = fromDate;
            List<PendingItemDto> list = AppFacade.Facade.SearchPendingItems(this.PendingItemCategory.Value, fromDate, toDate);
            todayPendingItems = new BindingList<PendingItemDto>(list);
            this.grdTodayResult.DataSource = todayPendingItems;
        }

        private void SearchFuturePendingItems()
        {
            DateTime fromDate = DateTime.Today.AddDays(1);
            DateTime toDate = DateTime.Today.AddMonths(1);
            List<PendingItemDto> list = AppFacade.Facade.SearchPendingItems(this.PendingItemCategory.Value, fromDate, toDate);
            futurePendingItems = new BindingList<PendingItemDto>(list);
            this.grdFutureResult.DataSource = futurePendingItems;
        }

        private void grdResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewX grid = sender as DataGridViewX;
            try
            {
                var column = grid.Columns[e.ColumnIndex];
                var row = grid.Rows[e.RowIndex];
                PendingItemDto dto = row.DataBoundItem as PendingItemDto;
                if (dto == null)
                {
                    return;
                }
                long refId = dto.RefId.Value;

                if (column.Name == "colEdit")
                {
                    this.ShowNonModalForm<PendingItemHandlingForm>(
                        () =>
                        {
                            PendingItemHandlingForm form = new PendingItemHandlingForm();
                            form.PendingItemDto = dto;
                            form.FormMode = SimpleCrm.FormMode.Edit;
                            return form;
                        }
                       , f => f.PendingItemDto == dto && f.FormMode == SimpleCrm.FormMode.Edit
                        );
                }
                else if (column.DataPropertyName == "CustomerName")
                {
                    this.ShowMdiChildForm<CustomerBaseDetailForm>(() =>
                    {
                        CustomerBaseDetailForm form = new CustomerBaseDetailForm();
                        form.FormMode = SimpleCrm.FormMode.View;
                        form.CustomerId = dto.CustomerId.Value;
                        return form;
                    }
                       , f => f.CustomerId == dto.CustomerId.Value && f.FormMode == SimpleCrm.FormMode.View
                    );
                }
                else if (column.DataPropertyName == "InsurancePolicyNo")
                {
                    this.ShowMdiChildForm<InsurancePolicyDetailForm>(() =>
                    {
                        InsurancePolicyDetailForm form = new InsurancePolicyDetailForm();
                        form.FormMode = SimpleCrm.FormMode.View;
                        form.InsurancePolicyId = refId;
                        return form;
                    }
                        , f => f.InsurancePolicyId == refId && f.FormMode == SimpleCrm.FormMode.View
                     );
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
                this.SearchFuturePendingItems();
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

                if (PendingItemCategory != null && e.NewTab == tiFuture && futurePendingItems == null)
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
