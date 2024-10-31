namespace ReceiptAPI.Service
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly ApplicationDbContext  _context;
        public IngredientService(IIngredientRepository ingredientRepository, ApplicationDbContext context)
        {
            _ingredientRepository = ingredientRepository;
            _context              = context;
        }
        public async Task AddIngredientAsync(IngredientDTO createIngredientDTO)
        {
            var nguyenLieu = await _context.Ingredients.FindAsync(createIngredientDTO.LoaiNguyenLieuId);
            if (nguyenLieu == null)
            {
                throw new ArgumentException("Loại nguyên liệu không tồn tại.");
            }

            if (string.IsNullOrWhiteSpace(createIngredientDTO.TenNguyenLieu))
            {
                throw new ArgumentException("Tên nguyên liệu không để trống");
            }

            if (string.IsNullOrWhiteSpace(createIngredientDTO.DonViTinh))
            {
                throw new ArgumentException("Nhập đơn vị tính");
            }

            if (createIngredientDTO.GiaBan <= 0)
            {
                throw new ArgumentException("Giá bán phải lớn hơn 0");
            }

            if (createIngredientDTO.SoLuongKho <= 0)
            {
                throw new ArgumentException("Số lượng kho phải lớn hơn 0");
            }

            var newIngredient = new Ingredient
            {
                LoaiNguyenLieuId = createIngredientDTO.LoaiNguyenLieuId,
                TenNguyenLieu    = createIngredientDTO.TenNguyenLieu,
                GiaBan           = createIngredientDTO.GiaBan,
                DonViTinh        = createIngredientDTO.DonViTinh,
                SoLuongKho       = createIngredientDTO.SoLuongKho
            };
            await _ingredientRepository.AddIngredientAsync(newIngredient);
        }

        public async Task DeleteIngredientAsync(int nguyenLieuId)
        {
            var existingIngredient = await _ingredientRepository.GetIngredientByIdAsync(nguyenLieuId);
            if (existingIngredient == null)
            {
                throw new Exception("Nguyên liệu không tồn tại.");
            }
            await _ingredientRepository.DeleteIngredientAsync(existingIngredient);
        }

        public async Task<List<Ingredient>> GetAllIngredientAsync()
        {
            return await _ingredientRepository.GetAllIngredientAsync();
        }

        public async Task<Ingredient> GetIngredientByIdAsync(int nguyenLieuId)
        {
            return await _ingredientRepository.GetIngredientByIdAsync(nguyenLieuId);
        }

        public async Task UpdateIngredientAsync(IngredientDTO updateIngredientDTO)
        {
            var nguyenLieuId       = updateIngredientDTO.NguyenLieuId;
            var existingIngredient = await _ingredientRepository.GetIngredientByIdAsync(nguyenLieuId);
            if (existingIngredient == null)
            {
                throw new Exception("Nguyên liệu không tồn tại.");
            }
            existingIngredient.LoaiNguyenLieuId = updateIngredientDTO.LoaiNguyenLieuId;
            existingIngredient.TenNguyenLieu    = updateIngredientDTO.TenNguyenLieu;
            existingIngredient.GiaBan           = updateIngredientDTO.GiaBan;
            existingIngredient.DonViTinh        = updateIngredientDTO.DonViTinh;
            existingIngredient.SoLuongKho       = updateIngredientDTO.SoLuongKho;
            await _ingredientRepository.UpdateIngredientAsync(existingIngredient);
        }
    }
}
