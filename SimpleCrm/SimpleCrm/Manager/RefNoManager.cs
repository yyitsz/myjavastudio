using System;
using System.Collections.Generic;
using System.Text;
using SimpleCrm.Model;
using Dapper;
using System.Linq;
using System.Data;

namespace SimpleCrm.Manager
{
    public class RefNoManager : BaseRepo
    {
        public RefNoManager(IDbConnection conn)
        {
            Connection = conn;
        }

        public String GenerateRefNo(String refNoType, String prefix, int len)
        {
            long seq = 1;
            var result = Connection.Query("select seq from RefNo where code = @code", new { code = refNoType })
                .FirstOrDefault();
            if (result == null || !result.ContainsKey("seq"))
            {
                Connection.Execute("insert into RefNo (code, seq) values (@code, @seq)", new { code = refNoType, seq = seq });
            }
            else
            {
                seq = (long)result["seq"];
                seq++;
                Connection.Execute("update RefNo set  seq = @seq where code = @code", new { code = refNoType, seq = seq });
            }
            return prefix + seq.ToString().PadLeft(len, '0');
        }
    }
}
