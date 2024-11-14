namespace EmployeeAPI.Service
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task AddProjectAsync(ProjectDTO createProjectDTO)
        {
            var newPro = new Project()
            {
                ProjectId   = createProjectDTO.ProjectId,
                ProjectName = createProjectDTO.ProjectName,
                Description = createProjectDTO.Description,
                Note        = createProjectDTO.Note,
            };
            await _projectRepository.AddProjectAsync(newPro);
        }

        public async Task DeleteProjectAsync(int id)
        {
            var existingPro = await _projectRepository.GetProjectByIdAsync(id);
            if (existingPro == null)
            {
                throw new ArgumentException("ProjectId not found");
            }
            await _projectRepository.DeleteProjectAsync(existingPro);
        }

        public async Task<List<Project>> GetAllProjectAsync()
        {
            return await _projectRepository.GetAllProjectAsync();
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            return await _projectRepository.GetProjectByIdAsync(id);
        }

        public async Task UpdateProjectAsync(ProjectDTO updateProjectDTO)
        {
            var existingPro = await _projectRepository.GetProjectByIdAsync(updateProjectDTO.ProjectId);
            if (existingPro == null)
            {
                throw new ArgumentException("ProjectId not found");
            }
            existingPro.ProjectName = updateProjectDTO.ProjectName;
            existingPro.Description = updateProjectDTO.Description;
            existingPro.Note        = updateProjectDTO.Note;
            await _projectRepository.UpdateProjectAsync(existingPro);
        }
    }
}
