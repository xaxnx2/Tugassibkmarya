using Microsoft.EntityFrameworkCore;
using Tugas4.Models;

namespace Tugas4.Context
{

    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        // Introduce the model to the database that eventually become an entity
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Profiling> Profilings { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<University> Universities { get; set;}
        public DbSet<Account> Account { get; set; }
        public DbSet<Accountrole> Accountroles { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<University>()
                .HasMany(u => u.Educations)
                .WithOne(e => e.University)
                .IsRequired(false)
                .HasForeignKey(e => e.universityid)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Education>()
                   .HasOne(e => e.Profiling)
                   .WithOne(p => p.Education)
                   .IsRequired(false)
                   .HasForeignKey<Profiling>(p => p.EducationId)
                   .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                    .HasOne(e => e.Profiling)
                    .WithOne(p => p.Employee)
                    .HasForeignKey<Profiling>(p => p.EmployeeNIK)
                    .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Account)
                .WithOne(a => a.Employee)
                .HasForeignKey<Account>(e => e.employee_nik)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Role>()
                .HasMany(a => a.Accountrole)
                .WithOne(r => r.Role)
                .HasForeignKey(a => a.role_id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Account>()
                .HasMany(a => a.Accountrole)
                .WithOne(b => b.Account)
                .HasForeignKey(a => a.account_nik)
                .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
