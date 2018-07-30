using BoilerPlate.Common;
using BoilerPlate.Data.Maps;
using BoilerPlate.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BoilerPlate.Data
{
    public partial class DataContext : IdentityDbContext<User, Role, int, UserLogin, UserRole, UserClaim>
    {
        private IUser CurrentUser { get { return this.SessionFactory.GetUser(); } }
        private readonly ISessionFactory SessionFactory;
        public DataContext(ISessionFactory sessionFactory) : base("name=DataContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            this.SessionFactory = sessionFactory;
        }
        public DataContext() : base("DataContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
        //security related items
        public DbSet<Client> Clients { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserClaim> UserClaims { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //security related maps
            //user and roles
            modelBuilder.Configurations.Add(new ClientMap());
            modelBuilder.Configurations.Add(new RefreshTokenMap());
            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new UserClaimMap());
            modelBuilder.Configurations.Add(new UserLoginMap());
            modelBuilder.Configurations.Add(new UserProfileMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new UserRoleMap());
            modelBuilder.Configurations.Add(new UserActionMap());
            modelBuilder.Configurations.Add(new EncompassContactMap());
        }
        public override int SaveChanges()
        {
            //process track able entities
            ProcessTrackableEntities();
            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            try
            {
                //process track able entities
                ProcessTrackableEntities();
                return base.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        private void ProcessTrackableEntities()
        {
            if (this.SessionFactory == null)
            {
                return;
            }
            var user = this.SessionFactory.GetUser();
            var entries = ChangeTracker.Entries<TrackableEntityBase<int>>().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified).ToList();
            foreach (var entry in entries)
            {
                var type = entry.Entity.GetType().BaseType;
                if (type.GetGenericTypeDefinition() == typeof(TrackableEntityBase<>))
                {
                    if (entry.State == EntityState.Added)
                    {
                        entry.Entity.CreatedBy = user.Id;
                        entry.Entity.CreatedOn = DateTime.UtcNow;
                        entry.Entity.ModifiedBy = user.Id;
                        entry.Entity.ModifiedOn = DateTime.UtcNow;
                    }
                    else if (entry.State == EntityState.Modified)
                    {
                        entry.Entity.ModifiedBy = user.Id;
                        entry.Entity.ModifiedOn = DateTime.UtcNow;
                    }
                }
            }
        }
    }
}