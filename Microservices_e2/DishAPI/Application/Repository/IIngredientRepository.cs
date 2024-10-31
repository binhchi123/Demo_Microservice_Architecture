namespace DishAPI.Application.Repository
{
    public interface IIngredientRepository
    {
        Task<List<Ingredient>> GetAllIngredientAsync();
        Task<Ingredient> GetIngredientByIdAsync(int loaiMonAnId);
        Task AddIngredientAsync(Ingredient ingredient);
        Task UpdateIngredientAsync(Ingredient ingredient);
        Task DeleteIngredientAsync(Ingredient ingredient);
    }
}
