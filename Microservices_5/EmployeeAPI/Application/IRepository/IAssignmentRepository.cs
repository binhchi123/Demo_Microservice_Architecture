using System.Security.Claims;

namespace EmployeeAPI.Application.IRepository
{
    public interface IAssignmentRepository
    {
        Task<List<Assignment>> GetAllAssignmentAsync();
        Task<Assignment> GetAssignmentByIdAsync(int id);
        Task AddAssignmentAsync(Assignment assignment);
        Task UpdateAssignmentAsync(Assignment assignment);
        Task DeleteAssignmentAsync(Assignment assignment);
    }
}
