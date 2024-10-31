namespace DishAPI.Application.Models;

public partial class Recipe
{
    public int     CongThucId   { get; set; }
    public int     MonAnId      { get; set; }
    public int     NguyenLieuId { get; set; }
    public int     SoLuong      { get; set; }
    public string  DonViTinh    { get; set; }

    [JsonIgnore]
    public virtual Dish? Dish { get; set; }

    [JsonIgnore]

    public virtual Ingredient? Ingredient { get; set; }
}
