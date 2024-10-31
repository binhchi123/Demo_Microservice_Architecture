namespace DishAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DishesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IDishService _dishService;

        public DishesController(ApplicationDbContext context, IDishService dishService)
        {
            _context = context;
            _dishService = dishService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDishes()
        {
            var dishes = await _dishService.GetAllDishAsync();
            return Ok(dishes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DishDTO>> GetDishById(int id)
        {
            var dish = await _dishService.GetDishByIdAsync(id);
            if (dish == null) return NotFound();
            return Ok(dish);
        }

        // POST: api/Dishes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> AddDish([FromBody] DishDTO createDishDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _dishService.AddDishAsync(createDishDTO);
                return Ok("Món ăn đã được thêm thành công.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi khi thêm món ăn: {ex.Message}");
            }
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchDishesByIngredient([FromQuery] string ingredientName)
        {
            var dishes = await _dishService.GetDishesByIngredientNameAsync(ingredientName);
            if (dishes == null || !dishes.Any())
            {
                return NotFound("Không tìm thấy món ăn nào với nguyên liệu này.");
            }

            return Ok(dishes);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDish([FromBody] DishDTO updateDishDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _dishService.UpdateDishAsync(updateDishDto);
                return Ok("Món ăn đã được cập nhật thành công.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi khi cập nhật món ăn: {ex.Message}");
            }
        }

        // DELETE: api/dish/{dishId}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDish(int monAnId)
        {
            try
            {
                await _dishService.DeleteDishAsync(monAnId);
                return Ok("Món ăn đã được xóa thành công.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi khi xóa món ăn: {ex.Message}");
            }
        }

        private bool DishExists(int id)
        {
            return _context.Dishes.Any(e => e.MonAnId == id);
        }
    }
}
