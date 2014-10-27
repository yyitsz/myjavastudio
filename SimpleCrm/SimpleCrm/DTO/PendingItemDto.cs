using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using SimpleCrm.Model;

namespace SimpleCrm.DTO
{
    public class PendingItemDto : BaseDto, INotifiable
    {
        private long? pendingItemId;
        public long? PendingItemId
        {
            get { return pendingItemId; }
            set
            {
                if (value != pendingItemId)
                {
                    pendingItemId = value;
                    this.NotifyPropertyChanged(m => m.PendingItemId);
                }
            }
        }
        private String category;
        /// <summary>
        /// Birthday, Renew
        /// </summary>
        public String Category
        {
            get { return category; }
            set
            {
                if (value != category)
                {
                    category = value;
                    this.NotifyPropertyChanged(m => m.Category);
                }
            }
        }

        private long? refId;
        public long? RefId
        {
            get { return refId; }
            set
            {
                if (value != refId)
                {
                    refId = value;
                    this.NotifyPropertyChanged(m => m.RefId);
                }
            }
        }
        private DateTime? actionDate;
        public DateTime? ActionDate
        {
            get { return actionDate; }
            set
            {
                if (value != actionDate)
                {
                    actionDate = value;
                    this.NotifyPropertyChanged(m => m.ActionDate);
                }
            }
        }
        private String handleResult;
        /// <summary>
        /// Unhandled, Renewed, Handled
        /// </summary>
        public String HandleResult
        {
            get { return handleResult; }
            set
            {
                if (value != handleResult)
                {
                    handleResult = value;
                    this.NotifyPropertyChanged(m => m.HandleResult);
                }
            }
        }

        private DateTime? handleDate;
        public DateTime? HandleDate
        {
            get { return handleDate; }
            set
            {
                if (value != handleDate)
                {
                    handleDate = value;
                    this.NotifyPropertyChanged(m => m.HandleDate);
                }
            }
        }

        private String remark;
        public String Remark
        {
            get { return remark; }
            set
            {
                if (value != remark)
                {
                    remark = value;
                    this.NotifyPropertyChanged(m => m.Remark);
                }
            }
        }

        public String CustomerName { get; set; }
        public long? CustomerId { get; set; }
        public String Content { get; set; }
        public String InsurancePolicyNo { get; set; }

        public override object GetPK()
        {
            return pendingItemId;
        }

        #region INotifiable Members

        public void NotifyPropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        #endregion
    }
}
