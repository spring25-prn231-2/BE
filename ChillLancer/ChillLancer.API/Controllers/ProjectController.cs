using ChillLancer.BusinessService.Interfaces;
using ChillLancer.BusinessService.Services;
using ChillLancer.Repository.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChillLancer.API.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly IProposalService _proposalService;

        public ProjectController(IProjectService projectService, IProposalService proposalService)
        {
            _projectService = projectService;
            _proposalService = proposalService;
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

        [HttpGet("projects/{projectId}/proposals")]
        public async Task<IActionResult> GetProposalsByProjectId([FromRoute] Guid projectId)
        {
            var payload = await _proposalService.GetProposalsByProjectId(projectId);
            return Ok(payload);
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
