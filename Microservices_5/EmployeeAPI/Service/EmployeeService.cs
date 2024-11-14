namespace EmployeeAPI.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository   _employeeRepository;
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly IProjectRepository    _projectRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, IAssignmentRepository assignmentRepository,
                               IProjectRepository projectRepository)
        {
            _employeeRepository   = employeeRepository;
            _assignmentRepository = assignmentRepository;
            _projectRepository    = projectRepository; 
        }
        public async Task AddEmployeeAsync(EmployeeDTO createEmployeeDTO)
        {
            var project = await _projectRepository.GetProjectByIdAsync(createEmployeeDTO.ProjectId);
            if (project == null)
            {
                throw new Exception("Dự án không tồn tại.");
            }
            if (createEmployeeDTO.Birthday < new DateTime(1970, 1, 1) || createEmployeeDTO.Birthday > new DateTime(2000, 12, 31))
            {
                throw new ArgumentException("Birthday between 1970 and 2000.");
            }

            if (createEmployeeDTO.SalaryCoefficient <= 0)
            {
                createEmployeeDTO.SalaryCoefficient = 1;
            }

            var emp = new Employee
            {
                EmployeeId        = createEmployeeDTO.EmployeeId,
                Name              = createEmployeeDTO.Name,
                Birthday          = createEmployeeDTO.Birthday,
                PhoneNumber       = createEmployeeDTO.PhoneNumber,
                Address           = createEmployeeDTO.Address,
                Email             = createEmployeeDTO.Email,
                SalaryCoefficient = createEmployeeDTO.SalaryCoefficient,
            };
            await _employeeRepository.AddEmployeeAsync(emp);

            var ass = new Assignment
            {
                EmployeeId = emp.EmployeeId,
                ProjectId = createEmployeeDTO.ProjectId,
                WorkHour = createEmployeeDTO.WorkHour
            };

            await _assignmentRepository.AddAssignmentAsync(ass);
        }

        public async Task<List<EmployeeSalaryDTO>> CalculateSalaryAsync()
        {
            var employees = await _employeeRepository.GetAllEmployeeAsync();

            if (employees == null || !employees.Any())
            {
                throw new Exception("Not found employees.");
            }

            var employeeSalaries = employees.Select(e => new EmployeeSalaryDTO
            {
                EmployeeId = e.EmployeeId,
                Name = e.Name,
                TotalSalary = e.Assignments != null && e.Assignments.Any()
                    ? e.Assignments.Sum(a => a.WorkHour * 15 * e.SalaryCoefficient)
                    : 0 
            }).ToList();

            return employeeSalaries;
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var existingEmp = await _employeeRepository.GetEmployeeByIdAsync(id);
            if (existingEmp == null) {
                throw new ArgumentException("EmployeeId not found");
            }
            await _employeeRepository.DeleteEmployeeAsync(existingEmp);
        }

        public async Task<List<Employee>> GetAllEmployeeAsync()
        {
            return await _employeeRepository.GetAllEmployeeAsync();
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return await _employeeRepository.GetEmployeeByIdAsync(id);
        }

        public async Task UpdateEmployeeAsync(EmployeeDTO updateEmployeeDTO)
        {
            if (updateEmployeeDTO.Birthday < new DateTime(1970, 1, 1) || updateEmployeeDTO.Birthday > new DateTime(2000, 12, 31))
            {
                throw new ArgumentException("Birthday between 1970 and 2000.");
            }

            if (updateEmployeeDTO.SalaryCoefficient <= 0)
            {
                updateEmployeeDTO.SalaryCoefficient = 1;
            }
            var existingEmp = await _employeeRepository.GetEmployeeByIdAsync(updateEmployeeDTO.EmployeeId);
            if (existingEmp == null)
            {
                throw new ArgumentException("EmployeeId not found");
            }
            
            existingEmp.Name              = updateEmployeeDTO.Name;
            existingEmp.Birthday          = updateEmployeeDTO.Birthday;
            existingEmp.PhoneNumber       = updateEmployeeDTO.PhoneNumber;
            existingEmp.Address           = updateEmployeeDTO.Address;
            existingEmp.Email             = updateEmployeeDTO.Email;
            existingEmp.SalaryCoefficient = updateEmployeeDTO.SalaryCoefficient;
            await _employeeRepository.UpdateEmployeeAsync(existingEmp);
            var existingPro = await _projectRepository.GetProjectByIdAsync(updateEmployeeDTO.ProjectId);
            if (existingPro == null)
            {
                throw new ArgumentException("ProjectId not found");
            }

            var existingAss = await _assignmentRepository.GetAssignmentByIdAsync(updateEmployeeDTO.EmployeeId);
            if (existingAss == null)
            {
                throw new ArgumentException("AssignmentId not found by employeeId");
            }
            existingAss.ProjectId = updateEmployeeDTO.ProjectId;
            existingAss.WorkHour  = updateEmployeeDTO.WorkHour;
            await _assignmentRepository.UpdateAssignmentAsync(existingAss);
        }
    }
}
