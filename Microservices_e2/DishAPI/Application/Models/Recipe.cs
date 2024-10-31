using System.Text.Json.Serialization;

namespace DishAPI.Application.Models
{
    public class Recipe
    {
        [Key]
        public int         CongThucId   { get; set; }
        [ForeignKey("Dish")]
        public int         MonAnId      { get; set; }
        [ForeignKey("Ingredient")]
        public int         NguyenLieuId { get; set; }
        [Required]
        public int         SoLuong      { get; set; }
        [Required]
        public string?     DonViTinh    { get; set; }

        [JsonIgnore]
        public Dish?       Dish         { get; set; } 

        [JsonIgnore]
        public Ingredient? Ingredient   { get; set; } 
    }
}
