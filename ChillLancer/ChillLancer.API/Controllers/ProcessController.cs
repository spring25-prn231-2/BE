using ChillLancer.BusinessService.BusinessModels;
using ChillLancer.BusinessService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ChillLancer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProcessController(IProcessService processService) : Controller
    {
        private readonly IProcessService _processService = processService;

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
