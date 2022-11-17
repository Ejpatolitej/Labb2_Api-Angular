using Microsoft.EntityFrameworkCore;

namespace Labb2_Api_Angular.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>().HasData(new Department { DepartmentID = 1, DepName = "IT" });
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentID = 2, DepName = "Economy" });
            modelBuilder.Entity<Department>().HasData(new Department { DepartmentID = 3, DepName = "Design" });
        }


    }
}
