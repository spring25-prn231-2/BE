using ChillLancer.Repository.Interfaces;
using ChillLancer.Repository.Models;

namespace ChillLancer.Repository.Repositories
{
    public class EducationRepository : GenericRepository<Education>, IEducationRepository
    {
        private readonly ChillLancerDbContext _context;
        public EducationRepository(ChillLancerDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
