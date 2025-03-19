using ChillLancer.BusinessService.BusinessModels;
using ChillLancer.BusinessService.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChillLancer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProcessController : Controller
    {
        private readonly IProcessService _processService;
        public ProcessController(IProcessService processService)
        {
            _processService = processService;
        }

        [HttpPost("{id}/submitTask")]
        public async Task<ActionResult> SubmitTask(Guid id, IFormFile? file, string? url)
        {
            TaskSubmissionModel model = new TaskSubmissionModel()
            {
                formFile = file,
                link = url
            };
            return await _processService.SubmitTask(id, model) ? Ok("test") : BadRequest();
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProcessBM>> getById(Guid id)
        {
            var process = _processService.GetProcessById(id);
            if (process is null)
            {
                return NotFound();
            }
            return Ok(process);
        }
    }
}
