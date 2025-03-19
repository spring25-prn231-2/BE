using ChillLancer.BusinessService.Interfaces;
using ChillLancer.Repository.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChillLancer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackageController(IPackageService packageService) : Controller
    {
        private readonly IPackageService _packageService = packageService;

        [HttpGet]
        public async Task<ActionResult<List<Package>>> GetPackages()
        {
            var packages = await _packageService.GetPackages();

            if (packages.Count == 0)
                return NotFound();

            return Ok(packages);
        }
    }
}
