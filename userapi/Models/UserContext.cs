using Microsoft.EntityFrameworkCore;


namespace userapi.Models

{
    public class UserContext:DbContext
    {
  
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }
        public DbSet<UserItems> UserItems { get; set; }
    }
}
