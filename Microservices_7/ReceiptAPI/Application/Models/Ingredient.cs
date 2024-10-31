namespace ReceiptAPI.Application.Models
{
    public class Ingredient
    {
        [Key]
        public int    NguyenLieuId     { get; set; }

        [ForeignKey("Category")]
        public int    LoaiNguyenLieuId { get; set; }

        [Required, StringLength(20), MaxLength(20)]
        public string TenNguyenLieu    { get; set; }

        [Required, Range(0.01, double.MaxValue, ErrorMessage = "Giá bán phải lớn hơn 0")]
        public double GiaBan           { get; set; }

        [Required, StringLength(10), MaxLength(10)]
        public string DonViTinh        { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "Số lượng kho phải lớn hơn 0")]
        public int    SoLuongKho       { get; set; }

        [JsonIgnore]
        public Category Category { get; set; }

        [JsonIgnore]
        public ICollection<ReceiptDetail> ReceiptDetails { get; set; }
    }
}
