using System;
using System.Collections.Generic;
using System.Text;
using SimpleCrm.Model;
using Dapper;
using System.Linq;
using SimpleCrm.Utils;
using System.Data;

namespace SimpleCrm.Manager
{
    public class SystemParameterManager : BaseRepo<SystemParameter, String>
    {
        private static SystemConfig systemConfig = new SystemConfig();
        public static SystemConfig SystemConfig { get { return systemConfig; } }
        public const String CONFIG = "SYS_CONFIG";

        public SystemParameterManager(IDbConnection conn)
        {
            Connection = conn;
        }

        public void Init()
        {
            SystemConfig conf = GetSystemConfig();
            if (conf != null)
            {
                systemConfig = conf;
            }
        }

        public SystemConfig GetSystemConfig()
        {
            SystemParameter sysParam = Connection.Get<SystemParameter>(CONFIG);
            if (sysParam == null || String.IsNullOrEmpty(sysParam.Config))
            {
                return null;
            }

            SystemConfig c = XmlUtil.Deserialize<SystemConfig>(sysParam.Config);
            return c;
        }

        public void SaveSystemConfig(SystemConfig config)
        {
            SystemParameter sysParam = Connection.Get<SystemParameter>(CONFIG);
            String configXml = XmlUtil.Serialize(config);
            if (sysParam == null)
            {
                sysParam = new SystemParameter();
                sysParam.Code = CONFIG;
                sysParam.Config = configXml;
                Connection.Insert(sysParam);
            }
            else
            {
                sysParam.Config = configXml;
                Connection.Update(sysParam);
            }
            systemConfig = config;
        }
    }
}
