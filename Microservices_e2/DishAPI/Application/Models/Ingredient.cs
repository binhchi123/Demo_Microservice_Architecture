namespace DishAPI.Application.Models
{
    public class Ingredient
    {
        [Key]
        public int           NguyenLieuId  { get; set; }
        [Required]
        public string?       TenNguyenLieu { get; set; }

        [JsonIgnore]
        public List<Recipe>? Recipes       { get; set; }
    }
}
