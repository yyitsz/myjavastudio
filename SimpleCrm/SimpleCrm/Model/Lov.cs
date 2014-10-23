using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;

namespace SimpleCrm.Model
{
    public class Lov : NotifyBaseModel
    {
        public static String OWNER_USER = "User";
        public static string OWNER_SYS = "Sys";
        private long? lovId;
        [Key(true)]
        public long? LovId
        {
            get { return lovId; }
            set
            {
                if (value != lovId)
                {
                    lovId = value;
                    this.NotifyPropertyChanged(l => l.LovId);
                }
            }
        }
        private int? seq;
        public int? Seq
        {
            get { return seq; }
            set
            {
                if (value != seq)
                {
                    seq = value;
                    this.NotifyPropertyChanged(l => l.Seq);
                }
            }
        }

        private String lovType;
        public String LovType
        {
            get { return lovType; }
            set
            {
                if (value != lovType)
                {
                    lovType = value;
                    this.NotifyPropertyChanged(l => l.LovType);
                }
            }
        }

        private String code;
        public String Code
        {
            get { return code; }
            set
            {
                if (value != code)
                {
                    code = value;
                    this.NotifyPropertyChanged(l => l.Code);
                }
            }
        }
        private String name;
        public String Name
        {
            get { return name; }
            set
            {
                if (value != name)
                {
                    name = value;
                    this.NotifyPropertyChanged(l => l.Name);
                }
            }
        }
        private long? parentId;
        public long? ParentId
        {
            get { return parentId; }
            set
            {
                if (value != parentId)
                {
                    parentId = value;
                    this.NotifyPropertyChanged(l => l.ParentId);
                }
            }
        }


        private String attribute1;
        public String Attribute1
        {
            get { return attribute1; }
            set
            {
                if (value != attribute1)
                {
                    attribute1 = value;
                    this.NotifyPropertyChanged(l => l.Attribute1);
                }
            }
        }


        private String attribute2;
        public String Attribute2
        {
            get { return attribute2; }
            set
            {
                if (value != attribute2)
                {
                    attribute2 = value;
                    this.NotifyPropertyChanged(l => l.Attribute2);
                }
            }
        }

        private String attribute3;
        public String Attribute3
        {
            get { return attribute3; }
            set
            {
                if (value != attribute3)
                {
                    attribute3 = value;
                    this.NotifyPropertyChanged(l => l.Attribute3);
                }
            }
        }


        private String attribute4;
        public String Attribute4
        {
            get { return attribute4; }
            set
            {
                if (value != attribute4)
                {
                    attribute4 = value;
                    this.NotifyPropertyChanged(l => l.Attribute4);
                }
            }
        }

        private String owner;
        /// <summary>
        /// Sys, User
        /// </summary>
        public String Owner
        {
            get { return owner; }
            set
            {
                if (value != owner)
                {
                    owner = value;
                    this.NotifyPropertyChanged(l => l.Owner);
                }
            }
        }
        public Lov()
        {
            owner = OWNER_USER;
        }
        public override object GetPK()
        {
            return LovId;
        }
    }
}
