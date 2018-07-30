using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BoilerPlate.Entities
{
    public class Role : IdentityRole<int, UserRole>, IRole<int>
    {
        public Role() { }
        public Role(string name) : this()
        {
            this.Name = name;
        }
        public Role(string name, string description) : this(name)
        {
            this.Description = description;
        }

        public string Description { get; set; }
        public int RoleType { get; set; }
    }
}
