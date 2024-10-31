namespace ReceiptAPI.Application.Models
{
    public class ReceiptDetail
    {
        [Key]
        public int ChiTietPhieuThuId { get; set; }

        [ForeignKey("Ingredient")]
        public int NguyenLieuId      { get; set; }

        [ForeignKey("Receipt")]
        public int PhieuThuId        { get; set; }
        public int SoLuongBan        { get; set; }

        [JsonIgnore]
        public Ingredient Ingredient { get; set; }

        [JsonIgnore]
        public Receipt Receipt { get; set; }
    }
}
