using ChillLancer.BusinessService.BusinessModels;
using ChillLancer.BusinessService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChillLancer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CertificationController : Controller
    {
        //=================================[ Declares ]================================
        private readonly ICertificationService _certificationService;

        public CertificationController(ICertificationService certificationService)
        {
            _certificationService = certificationService;
        }

        //=================================[ Endpoints ]================================
        [HttpPost]
        public async Task<IActionResult> CreateCertification([FromForm] CertificationBM inputData)
        {
            bool result = await _certificationService.CreateCertification(inputData);
            return result ? Created(nameof(CreateCertification), "Create Successfully!") : BadRequest("Create Failed!");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCertification()
        {
            var certificationInfo = await _certificationService.GetAllCertifications();
            return Ok(certificationInfo);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ViewCertificationDetail([FromRoute] Guid id)
        {
            var certificationInfo = await _certificationService.ViewCertification(id);
            return Ok(certificationInfo);
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetUserCertification([FromRoute] Guid id)
        {
            var certificationInfo = await _certificationService.GetUserCertifications(id);
            return Ok(certificationInfo);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateCertification([FromForm] CertificationBM inputData)
        {
            bool result = await _certificationService.UpdateCertification(inputData);
            return result ? Ok("Update Successfully!") : BadRequest("Update Failed!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCertification([FromRoute] Guid id)
        {
            bool result = await _certificationService.DeleteCertification(id);
            return result ? Ok("Delete Successfully!") : BadRequest("Delete Failed!");
        }
    }
}
