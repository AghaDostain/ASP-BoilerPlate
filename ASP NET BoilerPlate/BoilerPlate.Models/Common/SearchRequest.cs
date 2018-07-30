using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoilerPlate.Models
{
    public class SearchRequest : PagingRequest
    {
        public SearchRequest()
        {
            this.Filters = new List<FilterInfo>();
        }

        public IList<FilterInfo> Filters { get; set; }
    }
}
