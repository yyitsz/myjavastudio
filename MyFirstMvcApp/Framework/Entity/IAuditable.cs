using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Entity
{
    public interface IAuditable
    {
        DateTime? CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
        String CreatedBy { get; set; }
        String UpdatedBy { get; set; }
    }
}
