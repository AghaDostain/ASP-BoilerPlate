using Microsoft.AspNet.Identity.EntityFramework;

namespace BoilerPlate.Entities
{
    public class UserClaim : IdentityUserClaim<int>
    {
        public virtual User User { get; set; }
    }
}
