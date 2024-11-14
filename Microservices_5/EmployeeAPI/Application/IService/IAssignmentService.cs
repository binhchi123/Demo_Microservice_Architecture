namespace EmployeeAPI.Application.IService
{
    public interface IAssignmentService
    {
        Task<List<Assignment>> GetAllAssignmentAsync();
        Task<Assignment> GetAssignmentByIdAsync(int id);
        Task AddAssignmentAsync(AssignmentDTO createAssignmentDTO);
        Task DeleteAssignmentAsync(int id);
    }
}
