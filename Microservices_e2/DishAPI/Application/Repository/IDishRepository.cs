namespace DishAPI.Application.Repository
{
    public interface IDishRepository
    {
        Task<List<Dish>> GetAllDishAsync();
        Task<Dish> GetDishByIdAsync(int monAnId);
        Task<List<Dish>> GetDishesByIngredientNameAsync(string ingredientName);
        Task AddDishAsync(Dish dish);
        Task UpdateDishAsync(Dish dish);
        Task DeleteDishAsync(Dish dish);
    }
}
