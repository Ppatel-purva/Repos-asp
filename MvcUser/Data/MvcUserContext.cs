using Microsoft.EntityFrameworkCore;
using MvcUser.Models;


namespace MvcUser.Data
{
    public class MvcUserContext:DbContext
    {
        public MvcUserContext(DbContextOptions<MvcUserContext> options) : base(options)
        { }
        public DbSet<User> User { get; set; }
    }
}

