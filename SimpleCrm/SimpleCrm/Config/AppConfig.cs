using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCrm.Config
{
    [Serializable]
    public class AppConfig
    {
        public String CcyExchangeRateFile { get; set; }
      //  public String StaffAccountFile { get; set; }
        public String OAPaymentFolder { get; set; }
        public String OAPaymentArchiveFolder { get; set; }
        public String ExportFolder { get; set; }
    }
}
