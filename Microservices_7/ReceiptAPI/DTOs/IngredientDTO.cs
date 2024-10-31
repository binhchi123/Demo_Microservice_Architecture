namespace ReceiptAPI.DTOs
{
    public class IngredientDTO
    {
        public int    NguyenLieuId     { get; set; }
        public int    LoaiNguyenLieuId { get; set; }
        public string TenNguyenLieu    { get; set; }
        public double GiaBan           { get; set; }
        public string DonViTinh        { get; set; }
        public int    SoLuongKho       { get; set; }
    }
}
