using Kakeibo.Application.DTO;
using Kakeibo.Application.Repository;

namespace Kakeibo.Application
{
    public class Transaction
    {
        private readonly ITransactionsRepository _transactionsRepository;
        public Transaction(ITransactionsRepository transactionsRepository)
        {
            _transactionsRepository = transactionsRepository;
        }

        /// <summary>
        /// 取引全件取得
        /// </summary>
        /// <returns></returns>
        public async Task<List<TransactionResponse>> GetAllTransactionsAsync()
        {
            return await _transactionsRepository.GetAllAsync();
        }

        /// <summary>
        /// IDで取引を取得する
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<TransactionResponse> GetTransactionById(int id)
        {
            return await _transactionsRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// 取引を追加
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public Task AddTransactionAsync(RegisterTransactionRequest transaction)
        {
            return _transactionsRepository.AddAsync(transaction);
        }

        /// <summary>
        /// 取引を更新
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public Task UpdateTransactionAsync(UpdateTransactionRequest transaction)
        {
            return _transactionsRepository.UpdateAsync(transaction);
        }

        /// <summary>
        /// 取引を削除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task DeleteTransactionAsync(int id)
        {
            return _transactionsRepository.DeleteAsync(id);
        }

    }
}
