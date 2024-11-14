namespace EmployeeAPI.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly EmployeeDbContext _context;
        public ProjectRepository(EmployeeDbContext context)
        {
            _context = context;
        }
        public async Task AddProjectAsync(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProjectAsync(Project project)
        {
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Project>> GetAllProjectAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            return await _context.Projects.FirstOrDefaultAsync(p => p.ProjectId == id);
        }

        public async Task UpdateProjectAsync(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
        }
    }
}
