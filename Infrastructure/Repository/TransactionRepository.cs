using Kakeibo.Application.DTO;
using Kakeibo.Application.Repository;
using Kakeibo.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace Kakeibo.Infrastructure.Repository
{
    public class TransactionRepository : ITransactionsRepository
    {
        private readonly AppDbContext _dbContext;
        public TransactionRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(RegisterTransactionRequest transaction)
        {
            var entity = new Transactions
            {
                UserId = transaction.UserId,
                Amount = transaction.Amount,
                IsIncome = transaction.IsIncome,
                CategoryId = transaction.CategoryId,
                Date = transaction.Date,
                Memo = transaction.Memo ?? string.Empty,
                ImageUrl = transaction.ImageUrl ?? string.Empty
            };

            await _dbContext.Transactions.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _dbContext.Transactions.Where(t => t.Id == id).ExecuteDeleteAsync();
        }

        public async Task<List<TransactionResponse>> GetAllAsync()
        {
            return await _dbContext.Transactions
                .Select(t => new TransactionResponse
                {
                    Id = t.Id,
                    Amount = t.Amount,
                    IsIncome = t.IsIncome,
                    Date = t.Date,
                    Memo = t.Memo
                })
                .ToListAsync();
        }

        public async Task<TransactionResponse> GetByIdAsync(int id)
        {
            var entity =  await _dbContext.Transactions
                .Where(t => t.Id == id)
                .Select(t => new TransactionResponse
                {
                    Id = t.Id,
                    Amount = t.Amount,
                    IsIncome = t.IsIncome,
                    Date = t.Date,
                    Memo = t.Memo
                })
                .FirstOrDefaultAsync();
            if(entity == null)
                throw new Exception("Transaction not found");

            return entity;
        }

        public async Task UpdateAsync(UpdateTransactionRequest transaction)
        {
            var entity = await _dbContext.Transactions.FirstOrDefaultAsync(t => t.Id == transaction.Id);
            if (entity == null)
                throw new Exception("Transaction not found");

            entity.Amount = transaction.Amount;
            entity.CategoryId = transaction.CategoryId;
            entity.Memo = transaction.Memo ?? string.Empty;
            entity.ImageUrl = transaction.ImageUrl ?? string.Empty;

            await _dbContext.SaveChangesAsync();

        }
    }
}
