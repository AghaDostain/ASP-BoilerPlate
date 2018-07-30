using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace BoilerPlate.Models
{
    public partial class ChangePasswordModel
    {
        public ChangePasswordModel()
        {
        }
        [Required(ErrorMessage = "Username is required", AllowEmptyStrings = false)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Old password is required", AllowEmptyStrings = false)]
        public string OldPassword { get; set; }
        [Required(ErrorMessage = "Password is required",AllowEmptyStrings =false)]
        public string NewPassword { get; set; }
        [Compare("NewPassword",ErrorMessage ="Password doesn't match")]
        [Required(ErrorMessage = "Confirm password is required", AllowEmptyStrings = false)]
        public string ConfirmPassword { get; set; }
    }
}