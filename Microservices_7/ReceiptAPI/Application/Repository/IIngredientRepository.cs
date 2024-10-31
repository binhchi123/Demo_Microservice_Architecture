﻿namespace ReceiptAPI.Application.Repository
{
    public interface IIngredientRepository
    {
        Task<List<Ingredient>> GetAllIngredientAsync();
        Task<Ingredient> GetIngredientByIdAsync(int nguyenLieuId);
        Task AddIngredientAsync(Ingredient ingredient);
        Task UpdateIngredientAsync(Ingredient ingredient);
        Task DeleteIngredientAsync(Ingredient ingredient);
    }
}
