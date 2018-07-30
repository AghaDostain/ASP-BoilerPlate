using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BoilerPlate.Common.Enumeration;
namespace BoilerPlate.Models
{
    public class FilterInfo
    {
        public string Field { get; set; }
        public FilterOperators Op { get; set; }
        public object Value { get; set; }
    }
}