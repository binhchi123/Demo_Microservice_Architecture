namespace EmployeeAPI.Application.IService
{
    public interface IProjectService
    {
        Task<List<Project>> GetAllProjectAsync();
        Task<Project> GetProjectByIdAsync(int id);
        Task AddProjectAsync(ProjectDTO createProjectDTO);
        Task UpdateProjectAsync(ProjectDTO updateProjectDTO);
        Task DeleteProjectAsync(int id);
    }
}
