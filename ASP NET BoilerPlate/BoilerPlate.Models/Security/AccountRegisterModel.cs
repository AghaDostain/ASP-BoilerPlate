using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BoilerPlate.Models;

namespace BoilerPlate.Models
{
    public partial class AccountRegisterModel : KeyedModel<int>
    {
        public AccountRegisterModel()
        {
        }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Usertype is required")]
        public string UserType { get; set; }
        public string UserName { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}