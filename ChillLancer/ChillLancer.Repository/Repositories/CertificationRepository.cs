using ChillLancer.Repository.Interfaces;
using ChillLancer.Repository.Models;

namespace ChillLancer.Repository.Repositories
{
    public class CertificationRepository : GenericRepository<Certification>, ICertificationRepository
    {
        private readonly ChillLancerDbContext _context;
        public CertificationRepository(ChillLancerDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
