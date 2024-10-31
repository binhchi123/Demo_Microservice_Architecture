namespace DishAPI.Application.Service
{
    public interface IIngredientService
    {
        Task<List<Ingredient>> GetAllIngredientAsync();
        Task<Ingredient> GetIngredientByIdAsync(int nguyenLieuId);
        Task AddIngredientAsync(IngredientDTO createIngredientDTO);
        Task UpdateIngredientAsync(IngredientDTO updateIngredientDTO);
        Task DeleteIngredientAsync(int nguyenLieuId);
    }
}
