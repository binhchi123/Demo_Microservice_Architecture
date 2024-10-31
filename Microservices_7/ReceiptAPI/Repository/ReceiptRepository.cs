
namespace ReceiptAPI.Repository
{
    public class ReceiptRepository : IReceiptRepository
    {
        private readonly ApplicationDbContext _context;
        public ReceiptRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task AddReceiptAsync(Receipt receipt)
        {
            _context.Receipts.Add(receipt);
            await _context.SaveChangesAsync();
        }

        public async Task AddReceiptDetailAsync(ReceiptDetail receiptDetail)
        {
            _context.ReceiptDetails.Add(receiptDetail);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReceiptAsync(Receipt receipt)
        {
            _context?.Receipts.Remove(receipt);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Receipt>> GetAllReceiptAsync()
        {
            return await _context.Receipts.ToListAsync();
        }

        public async Task<List<Receipt>> GetReceiptByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.Receipts.Include(p => p.ReceiptDetails)
                                          .Where(p => p.NgayLap >= startDate && p.NgayLap <= endDate)
                                          .ToListAsync();
        }

        public Task<Receipt> GetReceiptByIdAsync(int receiptId)
        {
            return _context.Receipts.FirstOrDefaultAsync(r => r.PhieuThuId == receiptId);
        }

        public async Task<Receipt> GetReceiptWithDetailsAsync(int receiptId)
        {
            return await _context.Receipts.Include(r => r.ReceiptDetails)
                                          .FirstOrDefaultAsync(r => r.PhieuThuId == receiptId);
        }

        public async Task UpdateReceiptAsync(Receipt receipt)
        {
            _context.Receipts.Update(receipt);
            await _context.SaveChangesAsync();
        }
    }
}
