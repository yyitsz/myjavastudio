using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Entity
{
    public class BaseSearchingResult<T>
    {
        public long TotalRecords { get; set; }
        private IList<T> result = new List<T>();
        public IList<T> Result
        {
            get { return result; }

            set
            {
                if (value == null)
                {
                    value = new List<T>();
                }
                result = value;
            }
        }
    }
}
