namespace ReceiptAPI.DTOs
{
    public class ReceiptDTO
    {
        public int      PhieuThuId  { get; set; }
        public DateTime NgayLap     { get; set; } = DateTime.Now;
        public string   NhanVienLap { get; set; }
        public string   GhiChu      { get; set; }
        public double   ThanhTien   { get; set; }

        public List<ReceiptDetailDTO> ReceiptDetails { get; set; }
    }
}
