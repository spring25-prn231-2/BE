using ChillLancer.Repository.Models;

namespace ChillLancer.Repository.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<(List<Category>? listCategory, int totalCount)> SearchCategory
            (string? keyword, string? inField, string? status, int pageIndex, int pageSize);
    }
}
