namespace DishAPI.Application.Models;

public partial class Category
{
    public int     LoaiMonAnId { get; set; }
    public string  TenLoai     { get; set; }

    [JsonIgnore]
    public ICollection<Dish> Dishes { get; set; } = new List<Dish>();
}
