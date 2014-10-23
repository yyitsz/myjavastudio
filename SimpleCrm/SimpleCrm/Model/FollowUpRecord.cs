using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;

namespace SimpleCrm.Model
{
    public class FollowUpRecord : NotifyBaseModel
    {
        [Key(true)]
        public long? FollowUpRecordId { get; set; }
        public long? CustomerId { get; set; }
        private DateTime? followDate;
        public DateTime? FollowDate
        {
            get { return followDate; }
            set
            {
                if (value != followDate)
                {
                    followDate = value;
                    this.RaisePropertyChanged("FollowDate");
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
                    this.RaisePropertyChanged("Content");
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
                    this.RaisePropertyChanged("IntentPhase");
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
                    this.RaisePropertyChanged("NextFollowUpDate");
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
