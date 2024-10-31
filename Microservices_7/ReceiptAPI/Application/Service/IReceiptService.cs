namespace ReceiptAPI.Application.Service
{
    public interface IReceiptService
    {
        Task<List<Receipt>> GetAllReceiptAsync();
        Task<List<Receipt>> GetReceiptByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<Receipt> GetReceiptByIdAsync(int receiptId);
        Task<Receipt> AddReceiptDetailsAsync(int receiptId, List<ReceiptDetailDTO> details);
        Task AddReceiptAsync(ReceiptDTO createReceiptDTO);
        Task UpdateReceiptAsync(ReceiptDTO updateReceiptDTO);
        Task DeleteReceiptAsync(int receiptId);
    }
}
