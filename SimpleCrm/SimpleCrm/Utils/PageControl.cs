using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SimpleCrm.Config;
using SimpleCrm.Manager;


namespace SimpleCrm.Utils
{
    /// <summary>
    /// Pagination control for displaying records number and button.
    /// </summary>
    [DefaultEvent("ScrollPage")]
    public partial class PageControl : UserControl
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="PageControl"/> class.
        /// </summary>
        public PageControl()
        {
            InitializeComponent();
        }


        private int totalRecords = 0;
        int from = 0;
        int to = 0;
        private int lastPageNo = 99999;


        /// <summary>
        /// Gets or sets the total records.
        /// </summary>
        /// <value>The total records.</value>
        [Browsable(false)]
        public int TotalRecords
        {
            get { return totalRecords; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                totalRecords = value;
                lastPageNo = (int)Math.Ceiling(totalRecords * 1.0 / this.pageSize);
                this.txtPageNumber.MaxValue = lastPageNo;
                this.txtPageNumber.Value = this.currentPage;

                if (lastPageNo < this.currentPage && this.currentPage != 1)
                {
                    //last page < current page means user changed condition, but click scroll button to searching. if current page no 
                    // is greater than all page number in data, the searching result will be empty.
                    this.currentPage = lastPageNo + 1;
                    this.txtPageNumber.ValueObject = null;
                }

                SetControlsStatus();
            }
        }
        private int currentPage = 1;

        /// <summary>
        /// Gets or sets the current page.
        /// </summary>
        /// <value>The current page.</value>
        [Browsable(false)]
        public int CurrentPage
        {
            get { return currentPage; }
            set
            {
                if (value <= 0)
                {
                    value = 1;
                }
                currentPage = value;
            }
        }

        /// <summary>
        /// Gets the start from record.
        /// </summary>
        /// <value>The start from rec.</value>
        [Browsable(false)]
        public int StartFromRec
        {
            get { return (currentPage - 1) * this.pageSize; }
        }

        private int pageSize = 10;

        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>The size of the page.</value>
        [Browsable(false)]
        public int PageSize
        {
            get { return pageSize; }
            set
            {
                if (value > 0)
                {
                    pageSize = value;
                }

                if (value >= MAX_PAGE_SIZE)
                {
                    btnFirst.Visible = false;
                    btnPrevious.Visible = false;
                    btnNext.Visible = false;
                    btnLast.Visible = false;
                    btnGo.Visible = false;
                    txtPageNumber.Visible = false;
                    this.TabStop = false;
                }
                else
                {
                    btnFirst.Visible = true;
                    btnPrevious.Visible = true;
                    btnNext.Visible = true;
                    btnLast.Visible = true;
                    btnGo.Visible = true;
                    txtPageNumber.Visible = true;
                    this.TabStop = true;
                }
            }
        }

        private event EventHandler<PageControlArgs> scrollPage;
        private int MAX_PAGE_SIZE = 9999;

        /// <summary>
        /// Occurs when [scroll page].
        /// </summary>
        public event EventHandler<PageControlArgs> ScrollPage
        {
            add { scrollPage += value; }
            remove { scrollPage -= value; }
        }

        /// <summary>
        /// Raises the scroll page event.
        /// </summary>
        /// <param name="args">The args.</param>
        private void RaiseScrollPageEvent(PageControlArgs args)
        {
            if (scrollPage != null)
            {
                scrollPage(this, args);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnFirst control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnFirst_Click(object sender, EventArgs e)
        {
            this.currentPage = 1;
            this.RaiseScrollPageEvent(new PageControlArgs());
            SetControlsStatus();

        }

        /// <summary>
        /// Handles the Click event of the btnPrevious control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            this.currentPage--;
            this.RaiseScrollPageEvent(new PageControlArgs());
            SetControlsStatus();
        }

        /// <summary>
        /// Handles the Click event of the btnNext control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnNext_Click(object sender, EventArgs e)
        {
            this.currentPage++;
            this.RaiseScrollPageEvent(new PageControlArgs());
            SetControlsStatus();
        }

        /// <summary>
        /// Handles the Click event of the btnLast control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnLast_Click(object sender, EventArgs e)
        {
            this.currentPage = lastPageNo;

            this.RaiseScrollPageEvent(new PageControlArgs());
            SetControlsStatus();
        }

        /// <summary>
        /// Sets the controls status.
        /// </summary>
        public void SetControlsStatus()
        {
            this.btnFirst.Enabled = true;
            this.btnPrevious.Enabled = true;
            this.btnNext.Enabled = true;
            this.btnLast.Enabled = true;
            this.TabStop = true;
            this.txtPageNumber.Enabled = false;


            if (this.totalRecords == 0)
            {
                this.btnFirst.Enabled = false;
                this.btnPrevious.Enabled = false;
                this.btnNext.Enabled = false;
                this.btnLast.Enabled = false;
                this.btnGo.Enabled = false;
                this.txtPageNumber.Text = "";
                this.TabStop = false;
            }
            else
            {
                this.txtPageNumber.Enabled = true;

                this.btnGo.Enabled = this.txtPageNumber.ValueObject != null
                                                && this.txtPageNumber.Value != this.currentPage
                                                && this.txtPageNumber.Value > 0;

                if (lastPageNo <= this.currentPage)
                {
                    this.btnNext.Enabled = false;
                    this.btnLast.Enabled = false;
                }
                if (this.currentPage == 1)
                {
                    this.btnPrevious.Enabled = false;
                    this.btnFirst.Enabled = false;
                }
            }
            from = 0;
            to = 0;
            if (totalRecords > 0)
            {
                if (pageSize < MAX_PAGE_SIZE)
                {
                    from = pageSize * (currentPage - 1) + 1;
                    to = pageSize * (currentPage);
                    if (to > totalRecords)
                    {
                        to = totalRecords;
                    }
                    if (from > totalRecords)
                    {
                        from = 0;
                        to = 0;
                    }
                }
                else
                {
                    from = 1;
                    to = totalRecords;
                }
            }

            //  lblResultStatus.Text = string.Format("Record {0}-{1} (Total Record:{2})",
            //    from,to,totalRecords);

            lblResultStatus.Text = string.Format(ErrorCode.TOTAL_REC,
               from, to, totalRecords);

        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (txtPageNumber.ValueObject != null && txtPageNumber.Value > 0)
            {
                this.currentPage = txtPageNumber.Value;
                RaiseScrollPageEvent(new PageControlArgs());
                SetControlsStatus();
            }

        }

        private void txtPageNumber_ValueChanged(object sender, EventArgs e)
        {
            if (this.txtPageNumber.ValueObject == null
                || this.txtPageNumber.Value == 0m
                || this.txtPageNumber.Value == this.currentPage)
            {
                this.btnGo.Enabled = false;
            }
            else
            {
                this.btnGo.Enabled = true;
            }
        }

        private void PageControl_Load(object sender, EventArgs e)
        {
            if (AppConfigManager.AppConfig != null)
            {
                this.pageSize = AppConfigManager.AppConfig.PageSize;
            }
        }




    }
    /// <summary>
    /// Arguments of Page Control
    /// </summary>
    public class PageControlArgs : EventArgs
    {
        //    private PageStatus _page;

        //    public PageStatus PageStatus
        //    {
        //        get { return _page; }
        //        set { _page = value; }
        //    }

        //    public PageControlArgs(PageStatus pageStatus)
        //    {
        //        _page = pageStatus;
        //    }
        //}

    }

}
