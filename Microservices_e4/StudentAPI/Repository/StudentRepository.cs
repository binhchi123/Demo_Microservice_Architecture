namespace StudentAPI.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDbContext _context;
        public StudentRepository(StudentDbContext context)
        {
            _context = context;
        }

        public async Task AddStudentAsync(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task<int> CountByClassIdAsync(int classId)
        {
            return await _context.Students.CountAsync(c => c.ClassId == classId);
        }

        public async Task DeleteStudentAsync(Student student)
        {
            _context?.Students.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Student>> GetAllStudentAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task<Class> GetClassByIdAsync(int classId)
        {
            return await _context.Classes.Include(c => c.Students)
                                         .FirstOrDefaultAsync(c => c.ClassId == classId);
        }

        public async Task<Student> GetStudentByIdAsync(int studentId)
        {
            return await _context.Students.FirstOrDefaultAsync(s => s.StudentId == studentId);
        }

        public async Task UpdateStudentAsync(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }
    }
}
