namespace ReceiptAPI.Application.Models
{
    public class Receipt
    {
        [Key]
        public int      PhieuThuId  { get; set; }
        public DateTime NgayLap     { get; set; } = DateTime.Now;

        [Required]
        public string   NhanVienLap { get; set; }
        public string   GhiChu      { get; set; }
        public double   ThanhTien   { get; set; }

        [JsonIgnore]
        public ICollection<ReceiptDetail> ReceiptDetails { get; set; }
    }
}
