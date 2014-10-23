using System;
using System.Collections.Generic;
using System.Text;
using SimpleCrm.Model;
using Dapper;
using System.Data;
using SimpleCrm.Common;
using System.Linq;

namespace SimpleCrm.Manager
{
    public class LovManager : BaseRepo<Lov, long?>
    {

        public LovManager(IDbConnection conn)
        {
            Connection = conn;
        }

        public IEnumerable<Lov> GetLovByType(String lovType)
        {
            return Connection.GetList<Lov>(new { LovType = lovType });
        }


        public Lov GetLovByTypeAndCode(String lovType, String code)
        {
            return Connection.GetList<Lov>(new { LovType = lovType, Code = code }).FirstOrDefault();
        }

        protected override void ValidateExists(Lov var)
        {
            int count = this.Count(new { LovType = var.LovType, Code = var.Code });
            if (count > 0)
            {
                throw new AppException(String.Format("{0}.{1} 已经存在.", var.LovType, var.Code));
            }
        }
    }
}
