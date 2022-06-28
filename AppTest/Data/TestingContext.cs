#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AppTest.Models;



namespace AppTest.Data
{
    public class TestingContext : DbContext
    {
        public TestingContext(DbContextOptions<TestingContext> options)
            : base(options)
        {
        }

        public DbSet<AppTest.Models.Employee> Employee { get; set; }
    }
}
