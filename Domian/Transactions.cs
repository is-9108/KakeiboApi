namespace Kakeibo.domian
{
    public class Transactions
    {
        /// <summary>
        /// ユニークID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// ユーザーID（外部キー）
        /// </summary>
        public string UserId { get; set; }
        /// <summary>
        /// 金額
        /// </summary>
        public decimal Amount { get; set; }
        /// <summary>
        /// 0: 支出, 1: 収入
        /// </summary>
        public bool IsIncome { get; set; }
        /// <summary>
        /// カテゴリテーブルのID（外部キー）
        /// </summary>
        public int CategoryId { get; set; }
        /// <summary>
        /// 登録日
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// メモ
        /// </summary>
        public string Memo { get; set; }
        /// <summary>
        /// Blob Strageに保存された画像のURL
        /// </summary>
        public string ImageUrl { get; set; }
    }
}
