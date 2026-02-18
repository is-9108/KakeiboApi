namespace Kakeibo.Domain.Entity
{
    public class Categories
    {
        /// <summary>
        /// ID（ユニークID）
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// カテゴリ名
        /// </summary>
        public string Name { get; set; }

        public Transactions transactions { get; set; }
    }
}
