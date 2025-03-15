using ChillLancer.BusinessService.BusinessModels;
using ChillLancer.BusinessService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChillLancer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        //=================================[ Declares ]================================
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        //=================================[ Endpoints ]================================
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryBM inputData)
        {
            bool result = await _categoryService.CreateCategory(inputData);
            return result ? Created(nameof(CreateCategory), "Create Successfully!") : BadRequest("Create Failed!");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ViewCategoryDetail([FromRoute] Guid id)
        {
            var categoryInfo = await _categoryService.ViewCategory(id);
            return Ok(categoryInfo);
        }

        [HttpGet]
        public async Task<IActionResult> AllCategories()
        {
            var categoryInfo = await _categoryService.GetAllCategories();
            return Ok(categoryInfo);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetListCategory([FromQuery] QueryBM queryString)
        {
            return Ok(await _categoryService.FilterCategory(queryString));
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateCategory([FromBody] CategoryBM inputData)
        {
            bool result = await _categoryService.UpdateCategory(inputData);
            return result ? Ok("Update Successfully!") : BadRequest("Update Failed!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] Guid id)
        {
            bool result = await _categoryService.DeleteCategory(id);
            return result ? Ok("Delete Successfully!") : BadRequest("Delete Failed!");
        }
    }
}
