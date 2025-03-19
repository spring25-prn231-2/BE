using ChillLancer.BusinessService.BusinessModels;
using ChillLancer.BusinessService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChillLancer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EducationController : Controller
    {
        //=================================[ Declares ]================================
        private readonly IEducationService _educationService;

        public EducationController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        //=================================[ Endpoints ]================================
        [HttpPost]
        public async Task<IActionResult> CreateEducation([FromBody] EducationBM inputData)
        {
            bool result = await _educationService.CreateEducation(inputData);
            return result ? Created(nameof(CreateEducation), "Create Successfully!") : BadRequest("Create Failed!");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ViewEducationDetail([FromRoute] Guid id)
        {
            var EducationInfo = await _educationService.ViewEducation(id);
            return Ok(EducationInfo);
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetUserEducation([FromRoute] Guid id)
        {
            var EducationInfo = await _educationService.GetUserEducations(id);
            return Ok(EducationInfo);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateEducation([FromBody] EducationBM inputData)
        {
            bool result = await _educationService.UpdateEducation(inputData);
            return result ? Ok("Update Successfully!") : BadRequest("Update Failed!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEducation([FromRoute] Guid id)
        {
            bool result = await _educationService.DeleteEducation(id);
            return result ? Ok("Delete Successfully!") : BadRequest("Delete Failed!");
        }
    }
}
