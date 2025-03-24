using ChillLancer.BusinessService.BusinessModels;
using ChillLancer.BusinessService.Extensions.Exceptions;
using ChillLancer.BusinessService.Interfaces;
using ChillLancer.Repository.Interfaces;
using ChillLancer.Repository.Models;
using Mapster;

namespace ChillLancer.BusinessService.Services
{
    public class ProposalService(IProposalRepository proposalRepository) : IProposalService
    {
        private readonly IProposalRepository _proposalRepository = proposalRepository;
        public async Task<bool> Add(ProposalBM inputData)
        {
            var existProposals = await _proposalRepository.GetProposalsByAccount(inputData.AccountId);
            Account currentACC = await _proposalRepository.GetAccountById(inputData.AccountId);
            Project currentPRO = await _proposalRepository.GetProjectById(inputData.ProjectId);
            if (currentPRO.Employer.Id == currentACC.Id)
                throw new ConflictException("You cannot send proposal to your own project!");
            if (inputData.ProjectId != Guid.Empty)
                foreach (var proposal in existProposals)
                    if (inputData.ProjectId == proposal.Project!.Id)
                        throw new ConflictException("You have sent proposal for this project already!");
            foreach (var proposal in existProposals)
            {
                if (inputData.Title == proposal.Title) 
                    throw new ConflictException("This title is already existed");
            }
            
            var newProposal = inputData.Adapt<Proposal>();
            newProposal.Freelancer = currentACC;
            newProposal.Project = currentPRO;

            //Check if there are any processes in the inputData then add them to the new proposal
            if (inputData.Processes != null)
            {
                newProposal.Processes = inputData.Processes.Adapt<List<Process>>();
                foreach (var process in newProposal.Processes)
                {
                    process.Proposal = newProposal;
                }
            }

            await _proposalRepository.AddAsync(newProposal);
            return await _proposalRepository.SaveChangeAsync();
        }
        public async Task<List<ProposalBM>> GetAll()
        {
            var proposals = await _proposalRepository.GetAll();
            var proposalBms = proposals.Adapt<List<ProposalBM>>();
            return proposalBms;
        }
        public async Task<List<ProposalBM>> GetProposalsByProjectId(Guid projectId)
        {
            var proposals = await _proposalRepository.GetProposalsByProjectId(projectId);
            var proposalBms = proposals.Adapt<List<ProposalBM>>();
            return proposalBms;
        }
        public async Task<bool> Delete(Guid proposalId)
        {
            var selectedProposal = await _proposalRepository.GetByIdAsync(proposalId) ?? throw new NotFoundException("Proposal is not selected yet!");
            await _proposalRepository.DeleteAsync(selectedProposal);
            return await _proposalRepository.SaveChangeAsync();
        }
        public async Task<bool> AcceptProposal(Guid proposalId)
        {
            var proposal = await _proposalRepository.GetProposalById(proposalId);
            proposal.Status = "ACCEPTED";
            await _proposalRepository.UpdateAsync(proposal);
            return await _proposalRepository.SaveChangeAsync();
        }
        public async Task<bool> CheckAcceptedProposal(Guid projectId)
        {
            var proposals = await _proposalRepository.GetProposalsByProjectId(projectId);
            foreach (Proposal proposal in proposals)
                if (proposal.Status == "ACCEPTED")
                    return true;
            return false;
        }
    }
}
