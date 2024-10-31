namespace ReceiptAPI.Application.Models
{
    public class Category
    {
        [Key]
        public int    LoaiNguyenLieuId { get; set; }

        [Required, StringLength(20), MaxLength(20)]
        public string TenLoai          { get; set; }
        public string MoTa             { get; set; }

        [JsonIgnore]
        public ICollection<Ingredient> Ingredients { get; set; }
    }
}
