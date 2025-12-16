using Microsoft.EntityFrameworkCore;
using App_Hexagonal.Infrastructura.student.ports.output.persistence.entity;

namespace App_Hexagonal.Infrastructura.student.ports.output.persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<StudentEntity> Students { get; set; }
    }
}
