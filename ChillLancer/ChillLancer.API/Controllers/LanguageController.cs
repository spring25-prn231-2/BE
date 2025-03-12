using ChillLancer.BusinessService.BusinessModels;
using ChillLancer.BusinessService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChillLancer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LanguageController : Controller
    {
        //=================================[ Declares ]================================
        private readonly ILanguageService _languageService;

        public LanguageController(ILanguageService languageService)
        {
            _languageService = languageService;
        }

        //=================================[ Endpoints ]================================
        [HttpPost]
        public async Task<IActionResult> CreateLanguage([FromBody] LanguageBM inputData)
        {
            bool result = await _languageService.CreateLanguage(inputData);
            return result ? Created(nameof(CreateLanguage), "Create Successfully!") : BadRequest("Create Failed!");
        }

        [HttpPost("profile")]
        public async Task<IActionResult> AddLanguageToProfile([FromBody] LanguageBM inputData)
        {
            bool result = await _languageService.AddLanguageToAccount(inputData);
            return result ? Created(nameof(CreateLanguage), "Add Successfully!") : BadRequest("Add Failed!");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLanguages()
        {
            return Ok(await _languageService.GetAllLanguages());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ViewLanguageDetail([FromRoute] Guid id)
        {
            var LanguageInfo = await _languageService.ViewLanguage(id);
            return Ok(LanguageInfo);
        }

        [HttpGet("user/{id}")]
        public async Task<IActionResult> GetUserLanguage([FromRoute] Guid id)
        {
            var LanguageInfo = await _languageService.GetUserLanguages(id);
            return Ok(LanguageInfo);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateLanguage([FromBody] LanguageBM inputData)
        {
            bool result = await _languageService.UpdateLanguage(inputData);
            return result ? Ok("Update Successfully!") : BadRequest("Update Failed!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLanguage([FromRoute] Guid id)
        {
            bool result = await _languageService.DeleteLanguage(id);
            return result ? Ok("Delete Successfully!") : BadRequest("Delete Failed!");
        }
    }
}
