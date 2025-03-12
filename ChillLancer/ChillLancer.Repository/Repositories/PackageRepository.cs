using ChillLancer.Repository.Interfaces;
using ChillLancer.Repository.Models;

namespace ChillLancer.Repository.Repositories
{
    public class PackageRepository(ChillLancerDbContext context) : GenericRepository<Package>(context), IPackageRepository
    {

    }
}
