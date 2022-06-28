using Microsoft.EntityFrameworkCore;

namespace BookCRUD.Models
{
    public class BookContext:DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {

        }
        public DbSet<BookItems> BookItems { get; set; }
    }
}
