using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;

namespace SimpleCrm.Model
{
    public class CustomerRelation : NotifyBaseModel
    {
        private long? customerRelationId;
        [Key(true)]
        public long? CustomerRelationId
        {
            get { return customerRelationId; }
            set
            {
                if (value != customerRelationId)
                {
                    customerRelationId = value;
                    this.NotifyPropertyChanged(m => m.CustomerRelationId);
                }
            }
        }

        private long? baseCustomerId;
        public long? BaseCustomerId
        {
            get { return baseCustomerId; }
            set
            {
                if (value != baseCustomerId)
                {
                    baseCustomerId = value;
                    this.NotifyPropertyChanged(m => m.BaseCustomerId);
                }
            }
        }

        private long? againstCustomerId;
        public long? AgainstCustomerId
        {
            get { return againstCustomerId; }
            set
            {
                if (value != againstCustomerId)
                {
                    againstCustomerId = value;
                    this.NotifyPropertyChanged(m => m.AgainstCustomerId);
                }
            }
        }

        private String relation;
        public String Relation
        {
            get { return relation; }
            set
            {
                if (value != relation)
                {
                    relation = value;
                    this.NotifyPropertyChanged(m => m.Relation);
                }
            }
        }



        public override object GetPK()
        {
            return customerRelationId;
        }
    }
}
