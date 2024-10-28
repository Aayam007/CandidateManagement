using CandidateManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CandidateManagement.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Candidate> Candidates { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Candidate>().HasIndex((c) => c.Email).IsUnique();
            base.OnModelCreating(modelBuilder);
        }
    }
}