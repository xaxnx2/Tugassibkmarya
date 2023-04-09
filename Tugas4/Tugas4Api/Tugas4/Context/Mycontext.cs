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
    }
}
