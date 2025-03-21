using ChillLancer.BusinessService.BusinessModels;
using ChillLancer.BusinessService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace ChillLancer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectOdataController : ODataController
    {
        private readonly IProjectService _projectService;

        public ProjectOdataController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<List<ProjectBM>>> getProjects()
        {
            var projects = await _projectService.GetProjects();

            if (!projects.Any())
                return NotFound();

            return Ok(projects);
        }
    }
}
