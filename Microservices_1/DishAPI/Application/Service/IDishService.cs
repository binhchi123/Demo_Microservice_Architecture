namespace DishAPI.Application.Service
{
    public interface IDishService
    {
        Task<List<Dish>> GetAllDishAsync();
        Task<Dish> GetDishByIdAsync(int monAnId);
        Task<List<Dish>> GetDishesByIngredientNameAsync(string ingredientName);
        Task AddDishAsync(DishDTO createDishDTO);
        Task UpdateDishAsync(DishDTO updateDishDTO);
        Task DeleteDishAsync(int monAnId);
    }
}
