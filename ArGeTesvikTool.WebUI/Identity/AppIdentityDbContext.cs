using ArGeTesvikTool.Entities.Concrete;
using ArGeTesvikTool.Entities.Concrete.Business;
using ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings;
using ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.Business;
using ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.Index;
using ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenter;
using ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenterCal;
using ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenterPerformance;
using ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenterPerson;
using ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings.RdCenterTech;
using ArGeTesvikTool.Entities.Concrete.Index;
using ArGeTesvikTool.Entities.Concrete.RdCenter;
using ArGeTesvikTool.Entities.Concrete.RdCenterCal;
using ArGeTesvikTool.Entities.Concrete.RdCenterPerformance;
using ArGeTesvikTool.Entities.Concrete.RdCenterPerson;
using ArGeTesvikTool.Entities.Concrete.RdCenterTech;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ArGeTesvikTool.WebUI.Models
{
    public class AppIdentityDbContext : IdentityDbContext<AppIdentityUser, AppIdentityRole, string>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Identity
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            modelBuilder.Entity<AppIdentityRole>(entity =>
            {
                entity.ToTable(name: "Roles");
                entity.Property(x => x.RoleText)
                .HasColumnName("RoleText")
                .HasMaxLength(20);
            });
            modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            modelBuilder.Entity<AppIdentityUser>(entity =>
            {
                entity.ToTable(name: "Users");
                entity.Property(x => x.Name)
                    .HasColumnName("Name")
                    .HasMaxLength(256);

                entity.Property(x => x.LastName)
                    .HasColumnName("LastName")
                    .HasMaxLength(256);
            });
            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });
            #endregion

            modelBuilder = CodeFirstMappings.CreateCodeFirstMapping(modelBuilder);
        }
    }
}
