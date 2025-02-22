using ChillLancer.Repository.Interfaces;
using ChillLancer.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace ChillLancer.Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly ChillLancerDbContext _context;
        public CategoryRepository(ChillLancerDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<(List<Category>? listCategory, int totalCount)> SearchCategory
            (string? keyword, string? inField, string? status, int pageIndex, int pageSize)
        {
            try
            {
                var query = _context.Categories
                    .AsNoTracking()
                    //.Include(cate => cate.Projects)
                    //.AsSplitQuery()   //For using Include() in query
                    .AsQueryable();

                // Apply search
                if (!string.IsNullOrEmpty(keyword))
                {
                    switch (inField)
                    {
                        case "MN":
                            query = query.Where(cate => cate.MajorName.ToLower().Contains(keyword.ToLower()));
                            break;
                        case "BN":
                            query = query.Where(cate => cate.BriefName.ToLower().Contains(keyword.ToLower()));
                            break;
                        case "SN":
                            query = query.Where(cate => cate.SpecializedName.ToLower().Contains(keyword.ToLower()));
                            break;
                        case "MN-BN":
                            query = query.Where(cate =>
                            cate.MajorName.ToLower().Contains(keyword.ToLower()) ||
                            cate.BriefName.ToLower().Contains(keyword.ToLower()));
                            break;
                        case "MN-SN":
                            query = query.Where(cate =>
                            cate.MajorName.ToLower().Contains(keyword.ToLower()) ||
                            cate.SpecializedName.ToLower().Contains(keyword.ToLower()));
                            break;
                        case "BN-SN":
                            query = query.Where(cate =>
                            cate.BriefName.ToLower().Contains(keyword.ToLower()) ||
                            cate.SpecializedName.ToLower().Contains(keyword.ToLower()));
                            break;
                        default:
                            query = query.Where(cate =>
                            cate.MajorName.ToLower().Contains(keyword.ToLower()) ||
                            cate.BriefName.ToLower().Contains(keyword.ToLower()) ||
                            cate.SpecializedName.ToLower().Contains(keyword.ToLower()));
                            break;
                    }
                }

                if (!string.IsNullOrEmpty(status))
                {
                    query = query.Where(cate => cate.Status.ToLower().Equals(status));
                }

                // Sort by Name
                query = query.OrderByDescending(cate => cate.SpecializedName);

                int countedObject = await query.CountAsync();

                // Apply paging
                var pagedList = await query
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                return (pagedList, countedObject);
            }
            catch (Exception)
            {
                return (null, 0);
            }
        }
    }
}
