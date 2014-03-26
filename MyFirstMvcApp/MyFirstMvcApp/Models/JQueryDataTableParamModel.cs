using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyFirstMvcApp.Models
{
    public class JQueryDataTableParamModel
    {
        public String sEcho { get; set; }
        public String sSearch { get; set; }
        public int iDisplayLength { get; set; }
        public int iDisplayStart { get; set; }
        public int iColumns { get; set; }
        public int iSortingCols { get; set; }
        public String sColumns { get; set; }

    }
}
