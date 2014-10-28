using System;
using System.Collections.Generic;
using Dapper;

namespace SimpleCrm.Model
{
    [Table("Customer")]
    public class Customer : NotifyBaseModel
    {
        private long? customerId;
        [Key(true)]
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

        private String customerName;
        public String CustomerName
        {
            get { return customerName; }
            set
            {
                if (value != customerName)
                {
                    customerName = value;
                    this.NotifyPropertyChanged(m => m.CustomerName);
                }
            }
        }

        private String idType;
        public String IdType
        {
            get { return idType; }
            set
            {
                if (value != idType)
                {
                    idType = value;
                    this.NotifyPropertyChanged(m => m.IdType);
                }
            }
        }
        private String idCardNo;
        public String IdCardNo
        {
            get { return idCardNo; }
            set
            {
                if (value != idCardNo)
                {
                    idCardNo = value;
                    this.NotifyPropertyChanged(m => m.IdCardNo);
                }
            }
        }

        private String gender;
        public String Gender
        {
            get { return gender; }
            set
            {
                if (value != gender)
                {
                    gender = value;
                    this.NotifyPropertyChanged(m => m.Gender);
                }
            }
        }


        private DateTime? birthday;
        public DateTime? Birthday
        {
            get { return birthday; }
            set
            {
                if (value != birthday)
                {
                    birthday = value;
                    this.NotifyPropertyChanged(m => m.Birthday);
                }
            }
        }

        private String unit;
        public String Unit
        {
            get { return unit; }
            set
            {
                if (value != unit)
                {
                    unit = value;
                    this.NotifyPropertyChanged(m => m.Unit);
                }
            }
        }

        private String position;
        public String Position
        {
            get { return position; }
            set
            {
                if (value != position)
                {
                    position = value;
                    this.NotifyPropertyChanged(m => m.Position);
                }
            }
        }


        private String houseInfo;
        public String HouseInfo
        {
            get { return houseInfo; }
            set
            {
                if (value != houseInfo)
                {
                    houseInfo = value;
                    this.NotifyPropertyChanged(m => m.HouseInfo);
                }
            }
        }
        private String familyInfo;
        public String FamilyInfo
        {
            get { return familyInfo; }
            set
            {
                if (value != familyInfo)
                {
                    familyInfo = value;
                    this.NotifyPropertyChanged(m => m.FamilyInfo);
                }
            }
        }

        private String incomingInfo;
        public String IncomingInfo
        {
            get { return incomingInfo; }
            set
            {
                if (value != incomingInfo)
                {
                    incomingInfo = value;
                    this.NotifyPropertyChanged(m => m.IncomingInfo);
                }
            }
        }

        private String carInfo;
        public String CarInfo
        {
            get { return carInfo; }
            set
            {
                if (value != carInfo)
                {
                    carInfo = value;
                    this.NotifyPropertyChanged(m => m.CarInfo);
                }
            }
        }

        private String otherInfo;
        public String OtherInfo
        {
            get { return otherInfo; }
            set
            {
                if (value != otherInfo)
                {
                    otherInfo = value;
                    this.NotifyPropertyChanged(m => m.OtherInfo);
                }
            }
        }

        private String status;
        public String Status
        {
            get { return status; }
            set
            {
                if (value != status)
                {
                    status = value;
                    this.NotifyPropertyChanged(m => m.Status);
                }
            }
        }
        private String customerClass;
        public String CustomerClass
        {
            get { return customerClass; }
            set
            {
                if (value != customerClass)
                {
                    customerClass = value;
                    this.NotifyPropertyChanged(m => m.CustomerClass);
                }
            }
        }
        private String intentPhase;
        /// <summary>
        /// 接触约访，取得面谈，递送建议书，签投保书，收取保费
        /// </summary>
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

        private String customerSource;
        /// <summary>
        /// 客户来源。默拜，转介绍，原故。
        /// </summary>
        public String CustomerSource
        {
            get { return customerSource; }
            set
            {
                if (value != customerSource)
                {
                    customerSource = value;
                    this.NotifyPropertyChanged(m => m.CustomerSource);
                }
            }
        }

        private String introducer;
        public String Introducer
        {
            get { return introducer; }
            set
            {
                if (value != introducer)
                {
                    introducer = value;
                    this.NotifyPropertyChanged(m => m.Introducer);
                }
            }
        }

        [Transient]
        public String Relation { get; set; }

        //*****************************************************************
        //contactInfo
        public List<ContactInfo> Contacts { get; set; }


        public Customer()
        {
            Contacts = new List<ContactInfo>();
        }
        public override object GetPK()
        {
            return CustomerId;
        }

    }
}
