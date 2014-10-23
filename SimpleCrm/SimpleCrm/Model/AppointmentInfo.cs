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

        [Key(true)]
        public long? AppointmentInfoId { get; set; }
        public String Category { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public String Subject { get; set; }
        public String Content { get; set; }
        public String CategoryColor { get; set; }
        public String TimerMarker { get; set; }
        public String Owner { get; set; }

        public long? CustomerId { get; set; }


        public AppointmentInfo()
        {
        }

        public override object GetPK()
        {
            return AppointmentInfoId;
        }
    }
}
