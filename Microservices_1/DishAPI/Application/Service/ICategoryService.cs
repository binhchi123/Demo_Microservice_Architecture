﻿namespace DishAPI.Application.Service
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategoryAsync();
        Task<Category> GetCategoryByIdAsync(int loaiMonAnId);
        Task AddCategoryAsync(CategoryDTO createCategoryDTO);
        Task UpdateCategoryAsync(CategoryDTO updateCategoryDTO);
        Task DeleteCategoryAsync(int loaiMonAnId);
    }
}
