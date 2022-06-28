using Microsoft.EntityFrameworkCore;

namespace middelware.Data
{
    public class StudentContext:DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options 
            :base(options));
       
    }
}
