using ChillLancer.BusinessService.BusinessModels;
using ChillLancer.BusinessService.Interfaces;
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
        public async Task<ActionResult> SubmitTask(Guid id, IFormFile? file, string? url, string? text)
        {
            if (file is null && file.Length == 0 
                && url is null && url == "" 
                && text is null && text == "")
            {
                return BadRequest("file, url, text must not all be null");
            }

            TaskSubmissionModel model = new TaskSubmissionModel();
            model.Text = text;
            model.Link = url;
            model.Image = file;

            return await _processService.SubmitTask(id, model) ? Ok("test") : BadRequest();
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProcessBM>> getById(Guid id)
        {
            var process = await _processService.GetProcessById(id);
            if (process is null)
            {
                return NotFound();
            }
            return Ok(process);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProcesses([FromBody] List<ProcessUpdateBM> inputData, Guid proposalId)
        {
            bool result = await _processService.Update(inputData, proposalId);
            if (result)
            {
                return Ok(new { message = "Processes updated successfully." });
            }
            else
            {
                return BadRequest(new { error = "Failed to update processes. Please check the input data." });
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProcesses([FromBody] List<ProcessUpdateBM> inputData, Guid proposalId)
        {
            bool result = await _processService.Delete(inputData, proposalId);
            if (result)
            {
                return Ok(new { message = "Processes deleted successfully." });
            }
            else
            {
                return BadRequest(new { error = "Failed to delete processes. Please check the input data." });
            }
        }
    }
}
