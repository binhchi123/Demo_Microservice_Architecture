namespace DishAPI.Service
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;
        private readonly ApplicationDbContext _context;
        public IngredientService(IIngredientRepository ingredientRepository, ApplicationDbContext context)
        {
            _ingredientRepository = ingredientRepository;
            _context = context;
        }
        public async Task AddIngredientAsync(IngredientDTO createIngredientDTO)
        {
            var newIngredient = new Ingredient
            {
                TenNguyenLieu = createIngredientDTO.TenNguyenLieu,
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
            var nguyenLieuId = updateIngredientDTO.NguyenLieuId;
            var existingIngredient = await _ingredientRepository.GetIngredientByIdAsync(nguyenLieuId);
            if (existingIngredient == null)
            {
                throw new Exception("Nguyên liệu không tồn tại.");
            }
            existingIngredient.TenNguyenLieu = updateIngredientDTO.TenNguyenLieu;
            await _ingredientRepository.UpdateIngredientAsync(existingIngredient);
        }
    }
}
