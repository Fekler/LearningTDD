using Microsoft.EntityFrameworkCore;
using LearningTDD.Domain.Models;

namespace LearningTDD.InfraData
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configurações adicionais...
        }
    }
}
