using Kakeibo.Application.DTO;

namespace Kakeibo.Application.Repository
{
    public interface ICategoryRepository
    {
        Task<List<CategoryResponse>> GetAllAsync();
    }
}
