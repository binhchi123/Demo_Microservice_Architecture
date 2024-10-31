﻿namespace ReceiptAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IReceiptService      _receiptService;

        public ReceiptsController(ApplicationDbContext context, IReceiptService receiptService)
        {
            _context        = context;
            _receiptService = receiptService;
        }

        // GET: api/Receipts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receipt>>> GetReceipts()
        {
            return await _receiptService.GetAllReceiptAsync();
        }

        // GET: api/Receipts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Receipt>> GetReceipt(int id)
        {
            var receipt = await _receiptService.GetReceiptByIdAsync(id);

            if (receipt == null)
            {
                return NotFound();
            }

            return receipt;
        }

        [HttpGet("GetReceiptByDateRange")]
        public async Task<IActionResult> GetPhieuThus(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                return BadRequest("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc.");
            }

            var phieuThu = await _receiptService.GetReceiptByDateRangeAsync(startDate, endDate);
            if (phieuThu == null || !phieuThu.Any())
            {
                return NotFound("Không tìm thấy phiếu thu nào trong khoảng thời gian đã cho.");
            }

            return Ok(phieuThu);
        }

        // PUT: api/Receipts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceipt(int id, ReceiptDTO updateReceiptDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _receiptService.UpdateReceiptAsync(updateReceiptDTO);
                return Ok("Phiếu thu đã được cập nhật thành công.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi khi cập nhật phiếu thu: {ex.Message}");
            }
        }

        // POST: api/Receipts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Receipt>> PostReceipt(ReceiptDTO createReceiptDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                await _receiptService.AddReceiptAsync(createReceiptDTO);
                return Ok("Phiếu thu đã được thêm thành công.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi khi thêm phiếu thu: {ex.Message}");
            }
        }

        [HttpPost("ChiTiet/{receiptId}")]
        public async Task<IActionResult> PostReceiptDetails(int receiptId, [FromBody] List<ReceiptDetailDTO> detailsDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var updatedReceipt = await _receiptService.AddReceiptDetailsAsync(receiptId, detailsDTO);
                return Ok(updatedReceipt);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi khi thêm chi tiết phiếu thu: {ex.Message}");
            }
        }

        // DELETE: api/Receipts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceipt(int id)
        {
            try
            {
                await _receiptService.DeleteReceiptAsync(id);
                return Ok("Phiếu thu đã được xóa thành công.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi khi xóa phiếu thu: {ex.Message}");
            }
        }

        private bool ReceiptExists(int id)
        {
            return _context.Receipts.Any(e => e.PhieuThuId == id);
        }
    }
}
