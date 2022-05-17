using ArGeTesvikTool.Entities.Concrete;
using ArGeTesvikTool.Entities.Concrete.EntityFramework.EfCodeFirstMappings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

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

                entity.Property(x => x.IdentityNumber)
                    .HasColumnName("IdentityNumber")
                    .HasMaxLength(11);

                entity.Property(x => x.RegistrationNo)
                    .HasColumnName("RegistrationNo")
                    .HasMaxLength(26);

                entity.Property(x => x.IsActive)
                    .HasColumnName("IsActive");
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
