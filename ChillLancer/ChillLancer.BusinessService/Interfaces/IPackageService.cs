using ChillLancer.BusinessService.BusinessModels;
namespace ChillLancer.BusinessService.Interfaces
{
    public interface IPackageService
    {
        Task<List<PackageBM>> GetPackages();
    }
}
