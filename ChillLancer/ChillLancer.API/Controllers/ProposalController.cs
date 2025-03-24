using ChillLancer.BusinessService.BusinessModels;
using ChillLancer.BusinessService.Interfaces;
using ChillLancer.BusinessService.Services;
using ChillLancer.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace ChillLancer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProposalController(IProposalService proposalService) : Controller
    {
        private readonly IProposalService _proposalService = proposalService;

        [HttpPost]
        public async Task<IActionResult> CreateProposal([FromBody] ProposalBM inputData)
        {
            bool result = await _proposalService.Add(inputData);
            return result ? Created(nameof(CreateProposal), "Create Successfully!") : BadRequest("Create Failed!");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProposal(Guid proposalId)
        {
            bool result = await _proposalService.Delete(proposalId);
            return result ? NoContent() : NotFound("Proposal not found or could not be deleted.");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProposals()
        {
            var payload = await _proposalService.GetAll();
            if (!payload.Any())
                return NotFound();

            return Ok(payload);
        }
        [HttpGet("{projectId}")]
        public async Task<IActionResult> GetProposalsByProjectId(Guid projectId)
        {
            var payload = await _proposalService.GetProposalsByProjectId(projectId);
            if (!payload.Any())
                return NotFound();

            return Ok(payload);
        }
        [HttpPatch("{proposalId}")]
        public async Task<IActionResult> AcceptProposal(Guid proposalId)
        {
            bool result = await _proposalService.AcceptProposal(proposalId);
            return result ? Ok("Accepted proposal successfully!") : BadRequest("Accepting proposal failed!");
        }
        [HttpGet("checkAcceptedProposal/{projectId}")]
        public async Task<IActionResult> CheckAcceptedProposal(Guid projectId)
        {
            var payload = await _proposalService.CheckAcceptedProposal(projectId);
            if (!payload)
                return NotFound(payload);
            return Ok(payload);
        }
    }
}
