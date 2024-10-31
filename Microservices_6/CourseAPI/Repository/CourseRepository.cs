namespace CourseAPI.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _context;
        public CourseRepository(ApplicationDbContext context)
        {
            _context = context; 
        }
        public async Task AddCourseAsync(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCourseAsync(Course course)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Course>> GetAllCourseAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public Task<Course> GetCourseByIdAsync(int courseId)
        {
            return _context.Courses.FirstOrDefaultAsync(c => c.CourseId == courseId);
        }

        public async Task UpdateCourseAsync(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }
    }
}
