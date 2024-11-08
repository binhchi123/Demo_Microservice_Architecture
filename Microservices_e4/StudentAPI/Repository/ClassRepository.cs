namespace StudentAPI.Repository
{
    public class ClassRepository : IClassRepository
    {
        private readonly StudentDbContext _context;
        public ClassRepository(StudentDbContext context)
        {
            _context = context;
        }

        public async Task AddClassAsync(Class classes)
        {
            _context.Classes.Add(classes);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClassAsync(Class classes)
        {
            _context.Classes.Remove(classes);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Class>> GetAllClassAsync()
        {
            return await _context.Classes.ToListAsync();
        }

        public async Task<Class> GetClassByIdAsync(int classId)
        {
            return await _context.Classes.FirstOrDefaultAsync(c => c.ClassId == classId);
        }

        public async Task UpdateClassAsync(Class classes)
        {
            _context.Update(classes);
            await _context.SaveChangesAsync();
        }
    }
}
