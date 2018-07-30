using Microsoft.AspNet.Identity.EntityFramework;
namespace BoilerPlate.Entities
{
    public class UserLogin : IdentityUserLogin<int>
    {
        public virtual User User { get; set; }
    }
}
