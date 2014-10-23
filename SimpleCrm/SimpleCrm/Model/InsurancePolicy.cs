using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;

namespace SimpleCrm.Model
{
    public class InsurancePolicy : NotifyBaseModel
    {
        private long? insurancePolicyId;
        [Key(true)]
        public long? InsurancePolicyId
        {
            get { return insurancePolicyId; }
            set
            {
                if (value != insurancePolicyId)
                {
                    insurancePolicyId = value;
                    this.NotifyPropertyChanged(m => m.InsurancePolicyId);
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

        private String insurancePolicyNo;
        public String InsurancePolicyNo
        {
            get { return insurancePolicyNo; }
            set
            {
                if (value != insurancePolicyNo)
                {
                    insurancePolicyNo = value;
                    this.NotifyPropertyChanged(m => m.InsurancePolicyNo);
                }
            }
        }

        private DateTime? effectiveDate;
        public DateTime? EffectiveDate
        {
            get { return effectiveDate; }
            set
            {
                if (value != effectiveDate)
                {
                    effectiveDate = value;
                    this.NotifyPropertyChanged(m => m.EffectiveDate);
                }
            }
        }
        private int? insuredYear;
        public int? InsuredYear
        {
            get { return insuredYear; }
            set
            {
                if (value != insuredYear)
                {
                    insuredYear = value;
                    this.NotifyPropertyChanged(m => m.InsuredYear);
                }
            }
        }

        private Decimal? premium;
        public Decimal? Premium
        {
            get { return premium; }
            set
            {
                if (value != premium)
                {
                    premium = value;
                    this.NotifyPropertyChanged(m => m.Premium);
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

        private String category;
        /// <summary>
        /// 保险类别，Property, Life
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

        private String primaryIPName;
        /// <summary>
        /// 主险名称
        /// </summary>
        public String PrimaryIPName
        {
            get { return primaryIPName; }
            set
            {
                if (value != primaryIPName)
                {
                    primaryIPName = value;
                    this.NotifyPropertyChanged(m => m.PrimaryIPName);
                }
            }
        }

        private String primaryIPInfo;
        public String PrimaryIPInfo
        {
            get { return primaryIPInfo; }
            set
            {
                if (value != primaryIPInfo)
                {
                    primaryIPInfo = value;
                    this.NotifyPropertyChanged(m => m.PrimaryIPInfo);
                }
            }
        }

        private String secondaryIPName;
        /// <summary>
        /// 附加险名称
        /// </summary>
        public String SecondaryIPName
        {
            get { return secondaryIPName; }
            set
            {
                if (value != secondaryIPName)
                {
                    secondaryIPName = value;
                    this.NotifyPropertyChanged(m => m.SecondaryIPName);
                }
            }
        }

        private String secondaryIPInfo;
        public String SecondaryIPInfo
        {
            get { return secondaryIPInfo; }
            set
            {
                if (value != secondaryIPInfo)
                {
                    secondaryIPInfo = value;
                    this.NotifyPropertyChanged(m => m.SecondaryIPInfo);
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


        //-----------------------------------------------
        //public Customer Customer { get; set; }
        public Customer PolicyHolder { get; set; }
        public Customer Insured { get; set; }
        public List<Customer> Beneficiaries { get; set; }

        public InsurancePolicy()
        {
            Beneficiaries = new List<Customer>();
        }
        public override object GetPK()
        {
            return InsurancePolicyId;
        }
    }
}
