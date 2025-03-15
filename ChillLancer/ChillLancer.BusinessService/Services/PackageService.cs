using ChillLancer.BusinessService.BusinessModels;
using ChillLancer.BusinessService.Extensions.Exceptions;
using ChillLancer.BusinessService.Interfaces;
using ChillLancer.Repository.Interfaces;
using ChillLancer.Repository.Models;
using ChillLancer.Repository.Repositories;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace ChillLancer.BusinessService.Services
{
    public class PackageService(IPackageRepository packageRepository) : IPackageService
    {
        private readonly IPackageRepository _packageRepository = packageRepository;
        public async Task<List<PackageBM>> GetPackages()
        {
            var packages = await _packageRepository.GetAll().AsNoTracking().ToListAsync();
            return packages.Adapt<List<PackageBM>>();
        }
    }
}
