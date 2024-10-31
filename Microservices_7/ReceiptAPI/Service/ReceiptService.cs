
using ReceiptAPI.Application.Models;

namespace ReceiptAPI.Service
{
    public class ReceiptService : IReceiptService
    {
        private readonly IReceiptRepository    _receiptRepository;
        private readonly IIngredientRepository _ingredientRepository;
        private readonly ApplicationDbContext  _context;
        public ReceiptService(IReceiptRepository receiptRepository, IIngredientRepository ingredientRepository, ApplicationDbContext context)
        {
            _receiptRepository    = receiptRepository;
            _ingredientRepository = ingredientRepository;
            _context              = context;
        }
        public async Task AddReceiptAsync(ReceiptDTO createReceiptDTO)
        {
            if (!DateTime.TryParse(createReceiptDTO.NgayLap.ToString(), out var ngayLap))
            {
                throw new ArgumentException("Ngày lập không hợp lệ định dạng đúng yyyy/MM/dd");
            }

            if (string.IsNullOrWhiteSpace(createReceiptDTO.NhanVienLap))
            {
                throw new ArgumentException("Nhân viên lập không để trống");
            }
            var phieuThu = new Receipt
            {
                NgayLap     = createReceiptDTO.NgayLap,
                NhanVienLap = createReceiptDTO.NhanVienLap,
                GhiChu      = createReceiptDTO.GhiChu,
                ThanhTien   = 0
            };

            await _receiptRepository.AddReceiptAsync(phieuThu);
            double tongThanhTien = 0;
            foreach (var chiTiet in createReceiptDTO.ReceiptDetails)
            {
                var nguyenLieu = await _ingredientRepository.GetIngredientByIdAsync(chiTiet.NguyenLieuId);
                if (nguyenLieu == null)
                    throw new KeyNotFoundException("Nguyên liệu không tồn tại.");

                if (chiTiet.SoLuongBan <= 0)
                    throw new ArgumentException("Nhập số lượng bán");

                if (nguyenLieu.SoLuongKho < chiTiet.SoLuongBan)
                    throw new InvalidOperationException("Số lượng tồn kho không đủ");

                var receiptDetail = new ReceiptDetail
                {
                    PhieuThuId   = phieuThu.PhieuThuId,
                    NguyenLieuId = chiTiet.NguyenLieuId,
                    SoLuongBan   = chiTiet.SoLuongBan
                };

                await _receiptRepository.AddReceiptDetailAsync(receiptDetail);

                nguyenLieu.SoLuongKho -= chiTiet.SoLuongBan;
                tongThanhTien += chiTiet.SoLuongBan * nguyenLieu.GiaBan;
            }

            phieuThu.ThanhTien = tongThanhTien;
            await _receiptRepository.UpdateReceiptAsync(phieuThu);
        }

        public async Task<Receipt> AddReceiptDetailsAsync(int receiptId, List<ReceiptDetailDTO> detailsDTO)
        {
            var receipt = await _receiptRepository.GetReceiptWithDetailsAsync(receiptId);
            if (receipt == null)
                throw new KeyNotFoundException("Phiếu thu không tồn tại");

            double totalAmount = 0;

            foreach (var dto in detailsDTO)
            {
                var detail = new ReceiptDetail
                {
                    PhieuThuId = dto.PhieuThuId,
                    NguyenLieuId = dto.NguyenLieuId,
                    SoLuongBan = dto.SoLuongBan
                };

                if (detail.NguyenLieuId <= 0 || detail.SoLuongBan <= 0)
                    throw new ArgumentException("Số lượng không hợp lệ.");

                var nguyenLieu = await _ingredientRepository.GetIngredientByIdAsync(detail.NguyenLieuId);
                if (nguyenLieu == null)
                    throw new KeyNotFoundException("Nguyên liệu không tồn tại");

                if (nguyenLieu.SoLuongKho < detail.SoLuongBan)
                    throw new InvalidOperationException("Không đủ hàng.");

                await _receiptRepository.AddReceiptDetailAsync(detail);

                nguyenLieu.SoLuongKho -= detail.SoLuongBan;
                await _ingredientRepository.UpdateIngredientAsync(nguyenLieu);

                totalAmount += detail.SoLuongBan * nguyenLieu.GiaBan;
            }

            receipt.ThanhTien = totalAmount;
            await _receiptRepository.UpdateReceiptAsync(receipt);

            return receipt;
        }

        public async Task DeleteReceiptAsync(int receiptId)
        {
            var existingReceipt = await _receiptRepository.GetReceiptByIdAsync(receiptId);
            if (existingReceipt == null)
            {
                throw new Exception("Phiếu thu không tồn tại.");
            }
            await _receiptRepository.DeleteReceiptAsync(existingReceipt);
        }

        public async Task<List<Receipt>> GetAllReceiptAsync()
        {
            return await _receiptRepository.GetAllReceiptAsync();
        }

        public async Task<List<Receipt>> GetReceiptByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _receiptRepository.GetReceiptByDateRangeAsync(startDate, endDate);
        }

        public async Task<Receipt> GetReceiptByIdAsync(int receiptId)
        {
            return await _receiptRepository.GetReceiptByIdAsync(receiptId);
        }

        public async Task UpdateReceiptAsync(ReceiptDTO updateReceiptDTO)
        {
            var phieuThuId = updateReceiptDTO.PhieuThuId;
            var existingReceipt = await _receiptRepository.GetReceiptByIdAsync(phieuThuId);
            if (existingReceipt == null)
            {
                throw new Exception("Phiếu thu không tồn tại.");
            }
            existingReceipt.NgayLap = updateReceiptDTO.NgayLap;
            existingReceipt.NhanVienLap = updateReceiptDTO.NhanVienLap;
            existingReceipt.GhiChu = updateReceiptDTO.GhiChu;

            await _receiptRepository.UpdateReceiptAsync(existingReceipt);
        }
    }
}
