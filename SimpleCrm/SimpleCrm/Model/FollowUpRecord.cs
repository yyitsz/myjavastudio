using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;

namespace SimpleCrm.Model
{
    public class FollowUpRecord : NotifyBaseModel
    {

        private long? followUpRecordId;
        [Key(true)]
        public long? FollowUpRecordId
        {
            get { return followUpRecordId; }
            set
            {
                if (value != followUpRecordId)
                {
                    followUpRecordId = value;
                    this.NotifyPropertyChanged(m => m.FollowUpRecordId);
                }
            }
        }
        private long? customerId;
        public long? CustomerId
        {
            get { return customerId; }
            set
            {
                if (value != customerId)
                {
                    customerId = value;
                    this.NotifyPropertyChanged(m => m.CustomerId);
                }
            }
        }

        private DateTime? followDate;
        public DateTime? FollowDate
        {
            get { return followDate; }
            set
            {
                if (value != followDate)
                {
                    followDate = value;
                    this.NotifyPropertyChanged(m => m.FollowDate);
                }
            }
        }
        private String content;

        public String Content
        {
            get { return content; }
            set
            {
                if (value != content)
                {
                    content = value;
                    this.NotifyPropertyChanged(m => m.Content);
                }
            }
        }

        private String intentPhase;

        public String IntentPhase
        {
            get { return intentPhase; }
            set
            {
                if (value != intentPhase)
                {
                    intentPhase = value;
                    this.NotifyPropertyChanged(m => m.IntentPhase);
                }
            }
        }

        private DateTime? nextFollowUpDate;
        public DateTime? NextFollowUpDate
        {
            get { return nextFollowUpDate; }
            set
            {
                if (value != nextFollowUpDate)
                {
                    nextFollowUpDate = value;
                    this.NotifyPropertyChanged(m => m.NextFollowUpDate);
                }
            }
        }

        public DateTime? InputDate { get; set; }
        public String InputtedBy { get; set; }
        public String FollowedBy { get; set; }

        public override object GetPK()
        {
            return FollowUpRecordId;
        }
    }

    public class FollowUpRecordDateComparrer : IComparer<FollowUpRecord>
    {
        #region IComparer<FollowUpRecord> Members

        public int Compare(FollowUpRecord x, FollowUpRecord y)
        {
            var result = y.FollowDate.Value.CompareTo(x.FollowDate.Value);
            if (result == 0)
            {
                result = y.InputDate.Value.CompareTo(x.InputDate.Value);
            }
            return result;
        }

        #endregion
    }
}
