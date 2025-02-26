using ChillLancer.BusinessService.Interfaces;
using ChillLancer.Repository.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChillLancer.API.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("projects")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Project>>> GetAppointments()
        {
            var projects = await _projectService.GetProjects();

            if (!projects.Any())
                //return NotFound(new ApiResponseModel<string>
                //{
                //    StatusCode = System.Net.HttpStatusCode.NotFound,
                //    Message = "No appointments!"
                //});
                return NotFound();

            return Ok(projects);
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
