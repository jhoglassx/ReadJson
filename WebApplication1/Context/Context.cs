using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.DataContext
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Answers> Answers { get; set; }
        public DbSet<AnswerTypes> AnswerTypes { get; set; }
        public DbSet<CheckList> CheckList { get; set; }
        public DbSet<Levels> Levels { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Sections> Sections { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
