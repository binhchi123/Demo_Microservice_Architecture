namespace DishAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly ICategoryService _categoryService;

        public CategoriesController(ApplicationDbContext context, ICategoryService categoryService)
        {
            _context = context;
            _categoryService = categoryService;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<IActionResult> GetAllDishes()
        {
            var dishes = await _categoryService.GetAllCategoryAsync();
            return Ok(dishes);
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetCategory(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(CategoryDTO updateCategoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _categoryService.UpdateCategoryAsync(updateCategoryDTO);
                return Ok("Loại món ăn đã được cập nhật thành công.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi khi cập nhật Loại món ăn: {ex.Message}");
            }
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Category>> PostCategory(CategoryDTO createCategoryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _categoryService.AddCategoryAsync(createCategoryDTO);
                return Ok("Loại món ăn đã được thêm thành công.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi khi thêm Loại món ăn: {ex.Message}");
            }
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            try
            {
                await _categoryService.DeleteCategoryAsync(id);
                return Ok("Loại món ăn đã được xóa thành công.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi khi xóa Loại món ăn: {ex.Message}");
            }
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.LoaiMonAnId == id);
        }
    }
}
