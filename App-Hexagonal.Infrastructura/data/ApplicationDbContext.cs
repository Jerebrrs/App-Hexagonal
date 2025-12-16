
using App_Hexagonal.Infrastructura.student.persistence.entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App_Hexagonal.Infrastructura.data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<StudentEntity> Students { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}