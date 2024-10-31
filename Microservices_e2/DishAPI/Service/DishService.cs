namespace DishAPI.Service
{
    public class DishService : IDishService
    {
        private readonly IDishRepository _dishRepository;
        private readonly ApplicationDbContext _context;
        public DishService(IDishRepository dishRepository, ApplicationDbContext context)
        {
            _dishRepository = dishRepository;
            _context = context;
        }
        public async Task AddDishAsync(DishDTO createDishDTO)
        {
            if (string.IsNullOrWhiteSpace(createDishDTO.TenMon))
            {
                throw new ArgumentException("Tên món ăn không hợp lệ.");
            }

            if (createDishDTO.LoaiMonAnId <= 0 || !_context.Categories.Any(c => c.LoaiMonAnId == createDishDTO.LoaiMonAnId))
            {
                throw new ArgumentException("ID loại món ăn không hợp lệ hoặc không tồn tại.");
            }

            foreach (var recipe in createDishDTO.Recipes)
            {
                if (recipe.NguyenLieuId <= 0)
                {
                    throw new ArgumentException("Nguyên liệu ID không hợp lệ");
                }

                if (recipe.SoLuong <= 0)
                {
                    throw new ArgumentException("Số lượng phải lớn hơn 0");
                }

                if (string.IsNullOrWhiteSpace(recipe.DonViTinh))
                {
                    throw new ArgumentException("Đơn vị tính không hợp lệ.");
                }
            }
            var newDish = new Dish
            {
                TenMon = createDishDTO.TenMon,
                LoaiMonAnId = createDishDTO.LoaiMonAnId,
                GhiChu = createDishDTO.GhiChu,
                Recipes = createDishDTO.Recipes.Select(r => new Recipe
                {
                    NguyenLieuId = r.NguyenLieuId,
                    SoLuong = r.SoLuong,
                    DonViTinh = r.DonViTinh
                }).ToList()
            };
            await _dishRepository.AddDishAsync(newDish);
        }

        public async Task DeleteDishAsync(int monAnId)
        {
            var existingDish = await _dishRepository.GetDishByIdAsync(monAnId);
            if (existingDish == null)
            {
                throw new Exception("Món ăn không tồn tại.");
            }
            await _dishRepository.DeleteDishAsync(existingDish);
        }

        public async Task<List<Dish>> GetAllDishAsync()
        {
            return await _dishRepository.GetAllDishAsync();
        }

        public async Task<Dish> GetDishByIdAsync(int monAnId)
        {
            return await _dishRepository.GetDishByIdAsync(monAnId);
        }

        public async Task<List<Dish>> GetDishesByIngredientNameAsync(string ingredientName)
        {
            return await _dishRepository.GetDishesByIngredientNameAsync(ingredientName);
        }

        public async Task UpdateDishAsync(DishDTO updateDishDTO)
        {
            var monAnId = updateDishDTO.MonAnId;
            var existingDish = await _dishRepository.GetDishByIdAsync(monAnId);
            if (existingDish == null)
            {
                throw new Exception("Món ăn không tồn tại.");
            }

            existingDish.TenMon = updateDishDTO.TenMon;
            existingDish.LoaiMonAnId = updateDishDTO.LoaiMonAnId;
            existingDish.Recipes = updateDishDTO.Recipes.Select(r => new Recipe
            {
                NguyenLieuId = r.NguyenLieuId,
                SoLuong = r.SoLuong,
                DonViTinh = r.DonViTinh
            }).ToList();

            await _dishRepository.UpdateDishAsync(existingDish);
        }
    }
}
