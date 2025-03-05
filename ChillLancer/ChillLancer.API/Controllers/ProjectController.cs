using ChillLancer.BusinessService.BusinessModels;
using ChillLancer.BusinessService.Interfaces;
using ChillLancer.BusinessService.Services;
using ChillLancer.Repository.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChillLancer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : Controller
    {
        private readonly IProjectService _projectService;
        private readonly IProposalService _proposalService;

        public ProjectController(IProjectService projectService, IProposalService proposalService)
        {
            _projectService = projectService;
            _proposalService = proposalService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Project>>> GetAppointments()
        {
            var projects = await _projectService.GetProjects();

            if (!projects.Any())
                return NotFound();

            return Ok(projects);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<List<Project>>> GetAppointmentById(Guid id)
        {
            var projects = await _projectService.GetProjectById(id);

            if (projects is null)
                return NotFound();

            return Ok(projects);
        }

        [HttpGet("projects/{projectId}/proposals")]
        public async Task<IActionResult> GetProposalsByProjectId([FromRoute] Guid projectId)
        {
            var payload = await _proposalService.GetProposalsByProjectId(projectId);
            return Ok(payload);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> PostEmployee(ProjectBM project)
        {
            bool result = await _projectService.CreateProject(project);

            return result ? Ok("created") : BadRequest("create failed");
        }

    }
}
