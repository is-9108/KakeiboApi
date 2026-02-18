using Kakeibo.Application.DTO;
using Kakeibo.Application.Repository;
using Microsoft.EntityFrameworkCore;

namespace Kakeibo.Infrastructure.Repository
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly AppDbContext _dbContext;

        public CategoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<CategoryResponse>> GetAllAsync()
        {
            return await _dbContext.Categories
                .Select(c => new CategoryResponse
                {
                    Id = c.Id,
                    Name = c.Name
                })
                .ToListAsync();
        }
    }
}
