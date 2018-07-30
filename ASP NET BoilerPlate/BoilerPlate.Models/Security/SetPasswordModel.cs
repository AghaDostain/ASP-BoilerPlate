using System;
using System.Collections.Generic;

namespace BoilerPlate.Models
{
    public partial class SetPasswordModel : KeyedModel<int>
    {
        public SetPasswordModel()
        {
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
