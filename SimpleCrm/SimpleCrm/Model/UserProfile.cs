using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrm.Model
{
    public class UserProfile : Dapper.ICrudContext
    {
        public String UserId { get; set; }
        public String UserName { get; set; }
        public IList<String> RoleList { get; set; }

        public bool IsInRole(String role)
        {
            return RoleList.Contains(role);
        }

        #region ICrudContext Members

        public string GetUser()
        {
            return UserId;
        }

        #endregion

        public  bool IsInRole(string[] roleList)
        {
            if (roleList == null || roleList.Length == 0)
            {
                return true;
            }
            foreach (String role in roleList)
            {
                if (IsInRole(role))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
