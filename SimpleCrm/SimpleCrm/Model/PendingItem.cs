﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;

namespace SimpleCrm.Model
{
    public class PendingItem : NotifyBaseModel
    {

        private long? pendingItemId;
        [Key(true)]
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


        public override object GetPK()
        {
            return PendingItemId;
        }
    }
}
