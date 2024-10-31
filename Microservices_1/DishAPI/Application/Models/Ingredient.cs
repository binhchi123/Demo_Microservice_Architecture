namespace DishAPI.Application.Models;

public partial class Ingredient
{
    public int     NguyenLieuId  { get; set; }
    public string  TenNguyenLieu { get; set; }

    [JsonIgnore]
    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}
