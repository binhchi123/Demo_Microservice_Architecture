﻿namespace ReceiptAPI.Application.Service
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategoryAsync();
        Task<Category> GetCategoryByIdAsync(int loaiNguyenLieuId);
        Task AddCategoryAsync(CategoryDTO createCategoryDTO);
        Task UpdateCategoryAsync(CategoryDTO updateCategoryDTO);
        Task DeleteCategoryAsync(int loaiNguyenLieuId);
    }
}
