namespace Kakeibo.Application.DTO
{
    public class RegisterTransactionRequest
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public decimal Amount { get; set; }
        public bool IsIncome { get; set; }
        public int CategoryId { get; set; }
        public DateTime Date { get; set; }
        public string? Memo { get; set; }
        public string? ImageUrl { get; set; }
    }
}
