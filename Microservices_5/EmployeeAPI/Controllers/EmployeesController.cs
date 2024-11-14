namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            return await _employeeService.GetAllEmployeeAsync();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {           
            return await _employeeService.GetEmployeeByIdAsync(id);
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<IActionResult> PutEmployee(EmployeeDTO updateEmployeeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _employeeService.UpdateEmployeeAsync(updateEmployeeDTO);
                return Ok("Nhân viên đã được cập nhật thành công.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi khi cập nhật nhân viên: {ex.Message}");
            }
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(EmployeeDTO createEmployeeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _employeeService.AddEmployeeAsync(createEmployeeDTO);
                return Ok("Nhân viên đã được thêm thành công.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi khi thêm nhân viên: {ex.Message}");
            }
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _employeeService.DeleteEmployeeAsync(id);
                return Ok("Nhân viên đã được xóa thành công.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi khi xóa nhân viên: {ex.Message}");
            }
        }

        [HttpGet("salary")]
        public async Task<IActionResult> CalculateSalary()
        {
            try
            {
                var salaryList = await _employeeService.CalculateSalaryAsync();
                return Ok(salaryList);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
