namespace EmployeeAPI.Application.IService
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAllEmployeeAsync();
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task AddEmployeeAsync(EmployeeDTO createEmployeeDTO);
        Task UpdateEmployeeAsync(EmployeeDTO updateEmployeeDTO);
        Task DeleteEmployeeAsync(int id);
        Task<List<EmployeeSalaryDTO>> CalculateSalaryAsync();
    }
}
