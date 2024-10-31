namespace CourseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ICourseService       _courseService;

        public CoursesController(ApplicationDbContext context, ICourseService courseService)
        {
            _context       = context;
            _courseService = courseService;
        }

        // GET: api/Courses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            return await _courseService.GetAllCourseAsync();
        }

        // GET: api/Courses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null) return NotFound();
            return Ok(course);
        }

        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(int id, CourseDTO updateCourseDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _courseService.UpdateCourseAsync(updateCourseDTO);
                return Ok("Khóa học đã được cập nhật thành công.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi khi cập nhật khóa học: {ex.Message}");
            }
        }

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(CourseDTO createCourseDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _courseService.AddCourseAsync(createCourseDTO);
                return Ok("Khóa học đã được thêm thành công.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi khi thêm khóa học: {ex.Message}");
            }
        }

        [HttpGet("Revenue")]
        public async Task<IActionResult> CalculateRevenue(int month, int year)
        {
            var revenue = await _courseService.CalculateRevenueAsync(month, year);
            return Ok(new { Month = month, Year = year, Revenue = revenue });
        }

        // DELETE: api/Courses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            try
            {
                await _courseService.DeleteCourseAsync(id);
                return Ok("Khóa học đã được xóa thành công.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi khi xóa khóa học: {ex.Message}");
            }
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.CourseId == id);
        }
    }
}
