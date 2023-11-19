using GavrilovDmitryKT_41_20.Database.Configurations;
using GavrilovDmitryKT_41_20.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace GavrilovDmitryKT_41_20.Database
{
    public class SubjectDbContext : DbContext
    {
        public SubjectDbContext(DbContextOptions<SubjectDbContext> options) : base(options)
        {
        }

        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SubjectConfiguration());
        }
    }
}
