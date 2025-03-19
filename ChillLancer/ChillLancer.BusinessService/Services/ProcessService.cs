using ChillLancer.BusinessService.BusinessModels;
using ChillLancer.BusinessService.Extensions.Exceptions;
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

        public Task<bool> DeleteProcess(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProcessBM>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ProcessBM> GetProcessById(Guid id)
        {
            var process = await _processRepository.GetProposalById(id);
            if (process == null) {
                return null;
            }
            return process.Adapt<ProcessBM>();
        }

        public Task<bool> SubmitTask(Guid id, TaskSubmissionModel model)
        {

            throw new NotImplementedException();
            //file-link-verbal
        }

        public Task<bool> UpdateProcess(ProcessBM process)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateStatus(string status, Guid id)
        {
            try
            {
                var process = await _processRepository.GetByIdAsync(id);
                if (process == null)
                {
                    throw new NotFoundException("");
                }
                process.Status = status;
                await _processRepository.UpdateAsync(process);
                return await _processRepository.SaveChangeAsync();
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }
    }
}
