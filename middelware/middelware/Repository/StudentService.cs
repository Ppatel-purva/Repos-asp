

using middelware.Data;

namespace middelware.Repository
{
    public class StudentService : IStudentService
    {
        public readonly StudentContext _context;


        public StudentService(StudentContext context)
        {
            _context = context;
        }
        public async Task<IResult> GetStudents()
        {
            return Results.Ok(await _context.ToListAsync());
        }
    }
}
