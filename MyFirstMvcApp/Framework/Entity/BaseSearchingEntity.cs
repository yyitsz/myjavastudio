using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Entity
{
    public class BaseSearchingEntity
    {
        private int firstResult = -1;
        private int maxResults = -1;
        private List<OrderBy> orderBy = new List<OrderBy>();

        public int FirstResult { get { return firstResult; } set { firstResult = value; } }
        public int MaxResults { get { return maxResults; } set { maxResults = value; } }

        public IList<OrderBy> OrderBy { get { return orderBy; } }
    }
}
