namespace DishAPI.Application.Models
{
    public class Category
    {
        [Key]
        public int         LoaiMonAnId { get; set; }
        [Required]
        public string?     TenLoai     { get; set; }

        [JsonIgnore]
        public List<Dish>? Dishes      { get; set; }
    }
}
