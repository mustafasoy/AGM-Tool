using ArGeTesvikTool.Entities.Concrete.Business;
using ArGeTesvikTool.Entities.EfCodeFirstMappings;
using Microsoft.EntityFrameworkCore;

namespace ArGeTesvikTool.DataAccess.Concrete.EntityFramework
{
    public class AGMDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=TR996928-1809;Initial Catalog=AGMDb;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new BusinessInfoMap(modelBuilder.Entity<BusinessInfoDto>());
        }

        public DbSet<BusinessInfoDto> BusinessInfos { get; set; }
    }
}
