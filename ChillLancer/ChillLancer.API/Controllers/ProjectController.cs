using ChillLancer.BusinessService.BusinessModels;
using ChillLancer.BusinessService.Interfaces;
using ChillLancer.BusinessService.Middleware;
using ChillLancer.BusinessService.Services;
using ChillLancer.BusinessService.Services.Auth;
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

        [HttpGet("category/{categoryName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAppointments([FromRoute]string categoryName)
        {
            var projects = await _projectService.GetListProjectsByCategory(categoryName);

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

        [HttpGet("{projectId}/proposals")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProposalsByProjectId([FromRoute] Guid projectId)
        {
            var payload = await _proposalService.GetProposalsByProjectId(projectId);
            if (payload is null)
                return NotFound();
            return Ok(payload);
        }
        // sửa lại nghiệp vụ tạo project, thêm middleware để xác thực
        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult> PostEmployee(ProjectBM project)
        //{
        //    bool result = await _projectService.CreateProject(project);

        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<ActionResult> PostEmployee(ProjectCreateBM project)
        //    return result ? Ok("created") : BadRequest("create failed");
        //}
        [Protected]
        [HttpGet("employer-projects")]
        public async Task<IActionResult> GetProjects()
        {
            try
            {

            }catch(Exception ex)
            {
                return BadRequest(new OkObjectResult(new
                {
                    message = ex.Message,
                }));
            }
            var payload = HttpContext.Items["payload"] as Payload;
            if (payload == null || payload.Role != "Employer")
            {
                return Unauthorized();
            }
            var projects = await _projectService.GetProjectsByEmployerId(payload.UserId);
            return Ok(new OkObjectResult(new
            {
                data = projects
            }));
        }
        [Protected]
        [HttpPost]
        public async Task<IActionResult> CreateProject(ProjectCreateBM project)
        {
            try
            {
                var payload = HttpContext.Items["payload"] as Payload;
                if (payload == null || payload.Role != "Employer")
                {
                    return Unauthorized();
                }
                project.EmployerId = payload.UserId;
                var result = await _projectService.CreateProject(project);
                return Ok(new ObjectResult(new
                {
                    message = result ? "Project created" : "Project create failed"
                }));
            }
            catch (Exception e)
            {
                return BadRequest(new ObjectResult(new
                {
                    message = e.Message
                }));

            }
        }
    }
}
