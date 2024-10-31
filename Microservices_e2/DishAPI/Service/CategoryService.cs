using DishAPI.DTOs;

namespace DishAPI.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ApplicationDbContext _context;
        public CategoryService(ICategoryRepository categoryRepository, ApplicationDbContext context)
        {
            _categoryRepository = categoryRepository;
            _context = context;
        }
        public async Task AddCategoryAsync(CategoryDTO createCategoryDTO)
        {
            var newCategory = new Category
            {
                TenLoai = createCategoryDTO.TenLoai,
            };
            await _categoryRepository.AddCategoryAsync(newCategory);
        }

        public async Task DeleteCategoryAsync(int loaiMonAnId)
        {
            var existingCategory = await _categoryRepository.GetCategoryByIdAsync(loaiMonAnId);
            if (existingCategory == null)
            {
                throw new Exception("Loại món ăn không tồn tại.");
            }
            await _categoryRepository.DeleteCategoryAsync(existingCategory);
        }

        public async Task<List<Category>> GetAllCategoryAsync()
        {
            return await _categoryRepository.GetAllCategoryAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int loaiMonAnId)
        {
            return await _categoryRepository.GetCategoryByIdAsync(loaiMonAnId);
        }

        public async Task UpdateCategoryAsync(CategoryDTO updateCategoryDTO)
        {
            var loaiMonAnId = updateCategoryDTO.LoaiMonAnId;
            var existingCategory = await _categoryRepository.GetCategoryByIdAsync(loaiMonAnId);
            if (existingCategory == null)
            {
                throw new Exception("Loại món ăn không tồn tại.");
            }
            existingCategory.TenLoai = updateCategoryDTO.TenLoai;
            await _categoryRepository.UpdateCategoryAsync(existingCategory);
        }
    }
}
