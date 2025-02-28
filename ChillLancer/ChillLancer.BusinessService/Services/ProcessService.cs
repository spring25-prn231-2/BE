using ChillLancer.BusinessService.BusinessModels;
using ChillLancer.BusinessService.Interfaces;
using ChillLancer.Repository.Interfaces;
using ChillLancer.Repository.Models;
using Mapster;

namespace ChillLancer.BusinessService.Services
{
    public class ProcessService(IProcessRepository processRepository) : IProcessService
    {
        private readonly IProcessRepository _processRepository = processRepository;
        public async Task<bool> Add(List<ProcessBM> inputData)
        {
            //Proposal currentPRO;
            //if (inputData.Count != 0)
            //{
            //    foreach (var process in inputData)
            //    {
            //        currentPRO = await _processRepository.GetProposalById(process.ProposalId);
            //        var newProcess = process.Adapt<Process>();
            //        newProcess.Proposal = currentPRO;
            //        await _processRepository.AddAsync(newProcess);
            //    }
            //}
            return await _processRepository.SaveChangeAsync();
        }
    }
}
