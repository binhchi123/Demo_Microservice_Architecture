
namespace EmployeeAPI.Service
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;
        public AssignmentService(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        public Task AddAssignmentAsync(AssignmentDTO createAssignmentDTO)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAssignmentAsync(int id)
        {
            var existingAss = await _assignmentRepository.GetAssignmentByIdAsync(id);
            if (existingAss == null)
            {
                throw new ArgumentException("AssignmentId not found");
            }
            await _assignmentRepository.DeleteAssignmentAsync(existingAss);
        }

        public async Task<List<Assignment>> GetAllAssignmentAsync()
        {
            return await _assignmentRepository.GetAllAssignmentAsync();
        }

        public async Task<Assignment> GetAssignmentByIdAsync(int id)
        {
            return await _assignmentRepository.GetAssignmentByIdAsync(id);
        }
    }
}
