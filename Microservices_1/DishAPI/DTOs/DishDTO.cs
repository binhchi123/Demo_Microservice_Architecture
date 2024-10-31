namespace DishAPI.DTOs
{
    public class DishDTO
    {
        public int              MonAnId     { get; set; }
        public string?          TenMon      { get; set; }
        public int              LoaiMonAnId { get; set; }
        public string?          GhiChu      { get; set; }
        public List<RecipeDTO>? Recipes     { get; set; }
    }
}
