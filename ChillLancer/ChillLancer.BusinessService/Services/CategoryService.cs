using ChillLancer.BusinessService.BusinessModels;
using ChillLancer.BusinessService.Extensions.Exceptions;
using ChillLancer.BusinessService.Interfaces;
using ChillLancer.Repository.Interfaces;
using ChillLancer.Repository.Models;
using Mapster;
using Microsoft.AspNetCore.Components.Forms;

namespace ChillLancer.BusinessService.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        //=============================================================================

        public async Task<bool> CreateCategory(CategoryBM inputData)
        {
            var existCategory = await _categoryRepository.GetOneAsync(cate =>
            cate.SpecializedName.ToLower().Equals(inputData.SpecializedName.ToLower()));

            if (existCategory is not null) throw new ConflictException("This Category is existed!");

            await _categoryRepository.AddAsync(inputData.Adapt<Category>());
            return await _categoryRepository.SaveChangeAsync();
        }

        public async Task<CategoryBM> ViewCategory(Guid id)
        {
            var existCategory = await _categoryRepository.GetOneAsync(cate => cate.Id == id);

            if (existCategory is null) throw new NotFoundException("This Category is not existed!");

            return existCategory.Adapt<CategoryBM>();
        }
        public async Task<List<CategoryBM>> GetAllCategories()
        {
            var listResult = await _categoryRepository.GetListAsync(cate => cate.Status.ToLower().Equals("created"));
            return listResult.Adapt<List<CategoryBM>>();
        }

        public async Task<PagedResult<CategoryBM>> FilterCategory(QueryBM queryCondition)
        {
            //Reset invalid number
            queryCondition.PageIndex = (queryCondition.PageIndex <= 0) ? 1 : queryCondition.PageIndex;
            queryCondition.PageSize = (queryCondition.PageSize <= 0) ? 10 : queryCondition.PageSize;

            var (result, totalCount) = await _categoryRepository.SearchCategory
                (queryCondition.KeyWord, queryCondition.InField, queryCondition.Status, queryCondition.PageIndex, queryCondition.PageSize);

            if (totalCount == 0) { throw new NotFoundException("Not found any account"); }

            //Convert "List Category" to "List CategoryBM"
            var mappedResult = result.Adapt<List<CategoryBM>>();

            return new PagedResult<CategoryBM>
            {
                PageSize = queryCondition.PageSize,
                PageIndex = queryCondition.PageIndex,
                TotalCount = totalCount,
                DataList = mappedResult
            };
        }

        public async Task<bool> UpdateCategory(CategoryBM newData)
        {
            var existCategory = await _categoryRepository.GetOneAsync(cate => cate.Id == newData.Id)
                ?? throw new NotFoundException("This Category is not existed!");

            newData.Adapt(existCategory);
            return await _categoryRepository.SaveChangeAsync();
        }

        public async Task<bool> DeleteCategory(Guid id)
        {
            var existCategory = await _categoryRepository.GetOneAsync(cate => cate.Id == id)
                ?? throw new NotFoundException("This Category is not existed!");

            existCategory.Status = "Deleted";
            return await _categoryRepository.SaveChangeAsync();
        }
    }
}
