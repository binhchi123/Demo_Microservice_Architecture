
namespace CourseAPI.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddStudentAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task<int> CountByCourseIdAsync(int courseId)
        {
            return await _context.Courses.CountAsync(c => c.CourseId == courseId);
        }

        public async Task DeleteStudentAsync(Student student)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Student>> GetAllStudentAsync()
        {
            return await _context.Students.ToListAsync();   
        }

        public async Task<Student> GetStudentByIdAsync(int studentId)
        {
            return await _context.Students.FirstOrDefaultAsync(s => s.StudentId == studentId);
        }

        public async Task<List<Student>> SearchStudentsAsync(string name, string courseName)
        {
            return await(from s in _context.Students
                         join c in _context.Courses on s.CourseId equals c.CourseId
                         where (string.IsNullOrEmpty(name) || s.Name.Contains(name)) &&
                               (string.IsNullOrEmpty(courseName) || c.CourseName.Contains(courseName))
                         select s).ToListAsync();
        }

        public async Task UpdateStudentAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }
    }
}
