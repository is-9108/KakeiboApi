using Kakeibo.Application.DTO;
using Kakeibo.Application.Repository;

namespace Kakeibo.Application
{
    public class Category
    {
        private readonly ICategoryRepository _categoryRepository;

        public Category(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        /// <summary>
        /// カテゴリを全件取得する
        /// </summary>
        /// <returns></returns>
        public async Task<List<CategoryResponse>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAllAsync();
        }
    }
}
