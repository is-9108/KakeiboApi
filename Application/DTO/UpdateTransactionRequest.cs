namespace Kakeibo.Application.DTO
{
    public class UpdateTransactionRequest
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int CategoryId { get; set; }
        public string? Memo { get; set; }
        public string? ImageUrl { get; set; }
    }
}
