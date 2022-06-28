using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class CustomerContext:DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {

        }
        public DbSet<CustomersItems> CustomersItems { get; set; }
    }
}

