using ChillLancer.BusinessService.BusinessModels;
using ChillLancer.BusinessService.Extensions.Exceptions;
using ChillLancer.BusinessService.Interfaces;
using ChillLancer.Repository.Interfaces;
using ChillLancer.Repository.Models;
using ChillLancer.Repository.Repositories;
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
            if (inputData.ProjectId != Guid.Empty)
                foreach (var proposal in existProposals)
                    if (inputData.ProjectId == proposal.Project!.Id)
                        throw new ConflictException("You have sent proposal for this project!");

            foreach (var proposal in existProposals)
            {
                if (inputData.Title == proposal.Title) 
                    throw new ConflictException("This title is already existed");
            }
            var newProposal = inputData.Adapt<Proposal>();
            newProposal.Freelancer = currentACC;
            newProposal.Project = currentPRO;
            await _proposalRepository.AddAsync(newProposal);
            return await _proposalRepository.SaveChangeAsync();
        }
        public async Task<List<ProposalBM>> GetAll()
        {
            var proposals = await _proposalRepository.GetAll();
            var proposalBms = proposals.Adapt<List<ProposalBM>>();
            return proposalBms;
        }
        public async Task<bool> Delete(Guid proposalId)
        {
            var selectedProposal = await _proposalRepository.GetByIdAsync(proposalId) ?? throw new ConflictException("Proposal is not selected yet!");
            await _proposalRepository.DeleteAsync(selectedProposal);
            return await _proposalRepository.SaveChangeAsync();
        }
    }
}
