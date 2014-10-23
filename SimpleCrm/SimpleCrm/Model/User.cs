using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrm.Model
{
    [Dapper.Table("User")]
    public class User : NotifyBaseModel
    {
        public static readonly String ACTIVE = "Active";
        public static readonly String DISABLED = "Disabled";

        private String userId;
        [Dapper.Key(false)]
        public String UserId
        {
            get { return userId; }
            set
            {
                if (value != userId)
                {
                    userId = value;
                    this.NotifyPropertyChanged(l => l.UserId);
                }
            }
        }
        private String userName;
        public String UserName
        {
            get { return userName; }
            set
            {
                if (value != userName)
                {
                    userName = value;
                    this.NotifyPropertyChanged(l => l.UserName);
                }
            }
        }

        private String password;
        public String Password
        {
            get { return password; }
            set
            {
                if (value != password)
                {
                    password = value;
                    this.NotifyPropertyChanged(l => l.Password);
                }
            }
        }

        private String roleList;
        public String RoleList
        {
            get { return roleList; }
            set
            {
                if (value != roleList)
                {
                    roleList = value;
                    this.NotifyPropertyChanged(l => l.RoleList);
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
                    this.NotifyPropertyChanged(l => l.Status);
                }
            }
        }

        [Dapper.Transient]
        public String[] Roles
        {
            get
            {
                if (String.IsNullOrEmpty(RoleList))
                {
                    return new string[] { };
                }
                return RoleList.Split(new String[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            }
            set
            {
                if (value == null || value.Length == 0)
                {
                    RoleList = null;
                }
                else
                {
                    RoleList = String.Join(",", value);
                }
            }

        }

        public override object GetPK()
        {
            return UserId;
        }

        public override bool IsNew()
        {
            return base.VersionNo == null;
        }
    }
}
