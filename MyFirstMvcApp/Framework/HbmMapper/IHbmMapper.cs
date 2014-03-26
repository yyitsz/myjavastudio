using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Cfg.MappingSchema;

namespace Framework.HbmMapper
{
    public interface IHbmMapper
    {
        HbmMapping GetMapping();
        String GetMapingName();
    }
}
