namespace DishAPI.Application.Models
{
    public class Dish
    {
        [Key]
        public int               MonAnId     { get; set; }
        [Required]
        public string?           TenMon      { get; set; }
        public string?           GhiChu      { get; set; }
        [ForeignKey("Category")]
        public int               LoaiMonAnId { get; set; }

        [JsonIgnore]
        public Category         Category    { get; set; } 

        [JsonIgnore]
        public List<Recipe>?     Recipes     { get; set; }
    }
}
