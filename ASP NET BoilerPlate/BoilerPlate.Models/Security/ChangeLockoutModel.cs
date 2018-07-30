using System;
using System.Collections.Generic;

namespace BoilerPlate.Models
{
    public partial class ChangeLockoutModel : KeyedModel<int>
    {
        public ChangeLockoutModel()
        {
        }

        public string UserName { get; set; }
        public bool Locked { get; set; }
    }
}
