using System;
using System.Collections.Generic;

namespace BoilerPlate.Models
{
    public class UserStatusModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public bool IsActive { get; set; }
    }
}
