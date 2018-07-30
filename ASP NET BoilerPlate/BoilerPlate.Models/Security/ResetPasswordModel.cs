using System;
using System.Collections.Generic;

namespace BoilerPlate.Models
{
    public partial class ResetPasswordModel
    {
        public ResetPasswordModel()
        {
        }

        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string ResetToken { get; set; }
    }
}
