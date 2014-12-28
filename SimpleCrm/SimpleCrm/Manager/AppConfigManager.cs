using System;
using System.Collections.Generic;
using System.Text;
using SimpleCrm.Config;
using SimpleCrm.Utils;
using System.IO;
using System.Windows.Forms;

namespace SimpleCrm.Manager
{
    public class AppConfigManager
    {
        private static AppConfig appConfig = new AppConfig();
        public static AppConfig AppConfig { get { return appConfig; } }
        private static readonly String AppConfigFileName = "simplecrm-config.xml";

        public void Init()
        {
            AppConfig conf = GetAppConfig();
            if (conf != null)
            {
                appConfig = conf;
            }
        }

        public AppConfig GetAppConfig()
        {
            String path = GetConfigPath();
            String configFile = Path.Combine(path, AppConfigFileName);
            if (File.Exists(configFile))
            {
                AppConfig c = XmlUtil.Deserialize<AppConfig>(File.ReadAllText(configFile));
                return c;
            }
            else
            {
                return null;
            }
        }

        private static String GetConfigPath()
        {
            String path = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "conf");
            if (Directory.Exists(path) == false)
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }

        public void SaveAppConfig(AppConfig config)
        {
            String path = GetConfigPath();
            String configFile = Path.Combine(path, AppConfigFileName);

            String configXml = XmlUtil.Serialize(config);
            File.WriteAllText(configFile, configXml);
            appConfig = config;
        }

    }
}
