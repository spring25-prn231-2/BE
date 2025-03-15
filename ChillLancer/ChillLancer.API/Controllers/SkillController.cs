using ChillLancer.BusinessService.BusinessModels;
using ChillLancer.BusinessService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChillLancer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SkillController : Controller
    {
        //=================================[ Declares ]================================
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService;
        }

        //=================================[ Endpoints ]================================
        [HttpPost]
        public async Task<IActionResult> CreateSkill([FromBody] SkillBM inputData)
        {
            bool result = await _skillService.CreateSkill(inputData);
            return result ? Created(nameof(CreateSkill), "Create Successfully!") : BadRequest("Create Failed!");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ViewSkillDetail([FromRoute] Guid id)
        {
            var SkillInfo = await _skillService.ViewSkill(id);
            return Ok(SkillInfo);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSkills()
        {
            return Ok(await _skillService.GetAllSkills());
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateSkill([FromBody] SkillBM inputData)
        {
            bool result = await _skillService.UpdateSkill(inputData);
            return result ? Ok("Update Successfully!") : BadRequest("Update Failed!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSkill([FromRoute] Guid id)
        {
            bool result = await _skillService.DeleteSkill(id);
            return result ? Ok("Delete Successfully!") : BadRequest("Delete Failed!");
        }
        [HttpGet("project/{projectId}")]
        public async Task<IActionResult> GetProjectSkills([FromRoute] Guid projectId)
        {
            try
            {
                var listSkill = await _skillService.GetProjectSkills2(projectId);
                return Ok(new OkObjectResult(new
                {
                    message = "Get Project Skills Successfully!",
                    data = listSkill
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(new OkObjectResult(new
                {
                    message = ex.Message
                }));
            }
        }
    }
}