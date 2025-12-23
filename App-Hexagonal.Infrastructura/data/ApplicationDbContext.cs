
using App_Hexagonal.Infrastructura.identity.entity;
using App_Hexagonal.Infrastructura.student.persistence.entity;
using App_Hexagonal.Infrastructura.tenant.persistence.entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App_Hexagonal.Infrastructura.data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public DbSet<TenantEntity> Tenants { get; set; }
        public DbSet<StudentEntity> Students { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(ApplicationDbContext).Assembly);
        }

    }
}