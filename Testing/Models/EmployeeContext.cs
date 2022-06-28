using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Testing.Models
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
            .HasData(
               new Employee
               {
                   Id = Guid.NewGuid(),
                   Name = "purva",
                   Account = "123-9999999999-55",
                   Age = 35
               },
               new Employee
               {
                   Id = Guid.NewGuid(),
                   Name = "ansh",
                   Account = "123-9999999999-55",
               });
        }
        public DbSet<Employee>? Employees { get; set; }
        public object Employee { get; internal set; }
    }
}
