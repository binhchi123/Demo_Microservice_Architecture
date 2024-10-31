namespace DishAPI.Application.Models;

public partial class Dish
{
    public int      MonAnId     { get; set; }
    public string   TenMon      { get; set; }
    public string?  GhiChu      { get; set; }
    public int?     LoaiMonAnId { get; set; }

    [JsonIgnore]
    public virtual Category? Category { get; set; }

    [JsonIgnore]
    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}
