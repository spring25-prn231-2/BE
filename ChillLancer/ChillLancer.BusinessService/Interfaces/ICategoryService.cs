using ChillLancer.BusinessService.BusinessModels;

namespace ChillLancer.BusinessService.Interfaces
{
    public interface ICategoryService
    {
        Task<bool> CreateCategory(CategoryBM inputData);
        Task<CategoryBM> ViewCategory(Guid id);
        Task<PagedResult<CategoryBM>> FilterCategory(QueryBM queryCondition);
        Task<bool> UpdateCategory(CategoryBM newData);
        Task<bool> DeleteCategory(Guid id);
    }
}
