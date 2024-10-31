namespace DishAPI.Repository
{
    public class DishRepository : IDishRepository
    {
        private readonly ApplicationDbContext _context;
        public DishRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddDishAsync(Dish dish)
        {
            _context.Dishes.Add(dish);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDishAsync(Dish dish)
        {
            _context.Dishes.Remove(dish);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Dish>> GetAllDishAsync()
        {
            return await _context.Dishes.Include(d => d.Recipes)
                                        .ThenInclude(r => r.Ingredient)
                                        .ToListAsync();
        }

        public async Task<Dish> GetDishByIdAsync(int monAnId)
        {
            return await _context.Dishes.Include(d => d.Recipes)
                                        .ThenInclude(r => r.Ingredient)
                                        .FirstOrDefaultAsync(d => d.MonAnId == monAnId);
        }

        public async Task<List<Dish>> GetDishesByIngredientNameAsync(string ingredientName)
        {
            return await _context.Dishes.Include(d => d.Recipes)
                                        .ThenInclude(r => r.Ingredient)
                                        .Where(d => d.Recipes.Any(r => r.Ingredient.TenNguyenLieu == ingredientName))
                                        .ToListAsync();
        }

        public async Task UpdateDishAsync(Dish dish)
        {
            _context.Dishes.Update(dish);
            await _context.SaveChangesAsync();
        }
    }
}
