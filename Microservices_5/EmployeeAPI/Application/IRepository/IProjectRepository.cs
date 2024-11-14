namespace EmployeeAPI.Application.IRepository
{
    public interface IProjectRepository
    {
        Task<List<Project>> GetAllProjectAsync();
        Task<Project> GetProjectByIdAsync(int id);
        Task AddProjectAsync(Project project);
        Task UpdateProjectAsync(Project project);
        Task DeleteProjectAsync(Project project);
    }
}
