using WebApplication_empty_minimul;
using Microsoft.EntityFrameworkCore;

namespace WebApplication_empty_minimul
{
    public class ApiContext:DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public ApiContext(DbContextOptions<ApiContext>options):base(options) { }

    }
}
