using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;

namespace SimpleCrm.Model
{
    public class AppointmentInfo : NotifyBaseModel
    {
        public static string UserCatgory = "User";
        public static String FollowUpCatgory = "FollowUp";


        private long? appointmentInfoId;
        [Key(true)]
        public long? AppointmentInfoId
        {
            get { return appointmentInfoId; }
            set
            {
                if (value != appointmentInfoId)
                {
                    appointmentInfoId = value;
                    this.NotifyPropertyChanged(m => m.AppointmentInfoId);
                }
            }
        }

        private String category;
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

        private DateTime? startTime;
        public DateTime? StartTime
        {
            get { return startTime; }
            set
            {
                if (value != startTime)
                {
                    startTime = value;
                    this.NotifyPropertyChanged(m => m.StartTime);
                }
            }
        }

        private DateTime? endTime;
        public DateTime? EndTime
        {
            get { return endTime; }
            set
            {
                if (value != endTime)
                {
                    endTime = value;
                    this.NotifyPropertyChanged(m => m.EndTime);
                }
            }
        }

        private String subject;
        public String Subject
        {
            get { return subject; }
            set
            {
                if (value != subject)
                {
                    subject = value;
                    this.NotifyPropertyChanged(m => m.Subject);
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

        private String categoryColor;
        public String CategoryColor
        {
            get { return categoryColor; }
            set
            {
                if (value != categoryColor)
                {
                    categoryColor = value;
                    this.NotifyPropertyChanged(m => m.CategoryColor);
                }
            }
        }

        private String timerMarker;
        public String TimerMarker
        {
            get { return timerMarker; }
            set
            {
                if (value != timerMarker)
                {
                    timerMarker = value;
                    this.NotifyPropertyChanged(m => m.TimerMarker);
                }
            }
        }

        private String owner;
        public String Owner
        {
            get { return owner; }
            set
            {
                if (value != owner)
                {
                    owner = value;
                    this.NotifyPropertyChanged(m => m.Owner);
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

        public AppointmentInfo()
        {
        }

        public override object GetPK()
        {
            return AppointmentInfoId;
        }
    }
}
