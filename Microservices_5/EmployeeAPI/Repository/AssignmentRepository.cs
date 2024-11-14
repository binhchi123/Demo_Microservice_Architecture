namespace EmployeeAPI.Repository
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly EmployeeDbContext _context;
        public AssignmentRepository(EmployeeDbContext context)
        {
            _context = context;
        }

        public async Task AddAssignmentAsync(Assignment assignment)
        {
            _context.Assignments.Add(assignment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAssignmentAsync(Assignment assignment)
        {
            _context.Assignments.Remove(assignment);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Assignment>> GetAllAssignmentAsync()
        {
            return await _context.Assignments.ToListAsync(); 
        }

        public async Task<Assignment> GetAssignmentByIdAsync(int id)
        {
            return await _context.Assignments.FirstOrDefaultAsync(a => a.AssignmentId == id);
        }

        public async Task UpdateAssignmentAsync(Assignment assignment)
        {
            _context.Assignments.Update(assignment);
            await _context.SaveChangesAsync();
        }
    }
}
