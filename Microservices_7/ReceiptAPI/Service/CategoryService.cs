namespace ReceiptAPI.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository  _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task AddCategoryAsync(CategoryDTO createCategoryDTO)
        {
            if (string.IsNullOrWhiteSpace(createCategoryDTO.TenLoai))
            {
                throw new ArgumentException("Tên loại không để trống");
            }

            if (string.IsNullOrWhiteSpace(createCategoryDTO.MoTa))
            {
                throw new ArgumentException("Mô tả không để trống");
            }

            var newCategory = new Category
            {
                TenLoai = createCategoryDTO.TenLoai,
                MoTa    = createCategoryDTO.MoTa,
            };
            await _categoryRepository.AddCategoryAsync(newCategory);
        }

        public async Task DeleteCategoryAsync(int loaiNguyenLieuId)
        {
            var existingCategory = await _categoryRepository.GetCategoryByIdAsync(loaiNguyenLieuId);
            if (existingCategory == null)
            {
                throw new Exception("Loại nguyên liệu không tồn tại.");
            }
            await _categoryRepository.DeleteCategoryAsync(existingCategory);
        }

        public async Task<List<Category>> GetAllCategoryAsync()
        {
            return await _categoryRepository.GetAllCategoryAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int loaiNguyenLieuId)
        {
            return await _categoryRepository.GetCategoryByIdAsync(loaiNguyenLieuId);
        }

        public async Task UpdateCategoryAsync(CategoryDTO updateCategoryDTO)
        {
            var loaiNguyenLieuId = updateCategoryDTO.LoaiNguyenLieuId;
            var existingCategory = await _categoryRepository.GetCategoryByIdAsync(loaiNguyenLieuId);
            if (existingCategory == null)
            {
                throw new Exception("Loại nguyên liệu không tồn tại.");
            }
            existingCategory.TenLoai = updateCategoryDTO.TenLoai;
            existingCategory.MoTa    = updateCategoryDTO.MoTa;
            await _categoryRepository.UpdateCategoryAsync(existingCategory);
        }
    }
}
