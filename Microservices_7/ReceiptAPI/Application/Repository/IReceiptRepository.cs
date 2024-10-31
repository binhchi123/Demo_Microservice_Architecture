namespace ReceiptAPI.Application.Repository
{
    public interface IReceiptRepository
    {
        Task<List<Receipt>> GetAllReceiptAsync();
        Task<List<Receipt>> GetReceiptByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<Receipt> GetReceiptByIdAsync(int receiptId);
        Task<Receipt> GetReceiptWithDetailsAsync(int receiptId);
        Task AddReceiptAsync(Receipt receipt);
        Task AddReceiptDetailAsync(ReceiptDetail receiptDetail);
        Task UpdateReceiptAsync(Receipt receipt); 
        Task DeleteReceiptAsync(Receipt receipt);
    }
}
