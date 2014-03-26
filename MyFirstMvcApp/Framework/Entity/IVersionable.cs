using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Entity
{
    public interface IVersionable
    {
        int VersionNo { get; set; }
    }
}
