using Kakeibo.Application.DTO;

namespace Kakeibo.Application.Repository
{
    public interface ITransactionsRepository
    {
        Task<List<TransactionResponse>> GetAllAsync();
        Task<TransactionResponse> GetByIdAsync(int id);
        Task AddAsync(RegisterTransactionRequest transaction);
        Task UpdateAsync(UpdateTransactionRequest transaction);
        Task DeleteAsync(int id);
    }
}
