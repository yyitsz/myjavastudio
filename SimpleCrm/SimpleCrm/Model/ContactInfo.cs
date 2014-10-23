using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;

namespace SimpleCrm.Model
{
    public class ContactInfo : NotifyBaseModel
    {

        private long? contactInfoId;
        [Key(true)]
        public long? ContactInfoId
        {
            get { return contactInfoId; }
            set
            {
                if (value != contactInfoId)
                {
                    contactInfoId = value;
                    this.NotifyPropertyChanged(m => m.ContactInfoId);
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

        private String contactType;
        public String ContactType
        {
            get { return contactType; }
            set
            {
                if (value != contactType)
                {
                    contactType = value;
                    this.NotifyPropertyChanged(m => m.ContactType);
                }
            }
        }

        private String contactMethod;
        public String ContactMethod
        {
            get { return contactMethod; }
            set
            {
                if (value != contactMethod)
                {
                    contactMethod = value;
                    this.NotifyPropertyChanged(m => m.ContactMethod);
                }
            }
        }

        private bool isActive;
        public bool IsActive
        {
            get { return isActive; }
            set
            {
                if (value != isActive)
                {
                    isActive = value;
                    this.NotifyPropertyChanged(m => m.IsActive);
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


        //***************************************************
        public Customer Customer { get; set; }

        public ContactInfo()
        {
            isActive = true;
        }

        public override object GetPK()
        {
            return ContactInfoId;
        }
    }
}
