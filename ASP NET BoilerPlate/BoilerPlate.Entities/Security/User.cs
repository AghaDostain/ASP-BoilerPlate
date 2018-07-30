using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BoilerPlate.Entities
{
    public partial class User : IdentityUser<int, UserLogin, UserRole, UserClaim>, IUser<int>
    {
        public User()
        {
        }
        [StringLength(128)]
        public virtual string FirstName { get; set; }
        [StringLength(128)]
        public virtual string LastName { get; set; }
        public virtual bool? IsActive { get; set; }
        [StringLength(512)]
        public virtual string ImageUrl { get; set; }
        [StringLength(256)]
        public virtual string AlternateUserName { get; set; }
        //public virtual ICollection<Partner> PartnersAsClient { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User, int> manager, string authenticationType)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            return userIdentity;
        }
    }
}