using ChillLancer.BusinessService.BusinessModels;
using ChillLancer.BusinessService.Extensions.Exceptions;
using ChillLancer.BusinessService.Interfaces;
using ChillLancer.Repository.Interfaces;
using ChillLancer.Repository.Models;
using Mapster;

namespace ChillLancer.BusinessService.Services
{
    public class ProcessService(IProcessRepository processRepository, IProposalRepository proposalRepository) : IProcessService
    {
        private readonly IProcessRepository _processRepository = processRepository;        
        private readonly IProposalRepository _proposalRepository = proposalRepository;        

        public async Task<bool> Add(List<ProcessCreateBM> inputData)
        {
            Proposal currentPRO;
            if (inputData.Count != 0)
            {
                foreach (var process in inputData)
                {
                    currentPRO = await _proposalRepository.GetProposalById(process.ProposalId);
                    var newProcess = process.Adapt<Process>();
                    newProcess.Proposal = currentPRO;
                    await _processRepository.AddAsync(newProcess);
                }
            }
            return await _processRepository.SaveChangeAsync();
        }
        public async Task<bool> Update(List<ProcessUpdateBM> inputData, Guid proposalId)
        {
            List<Process> processes = await _processRepository.GetProcessesByProposalId(proposalId);

            if (processes.Count == 0 || inputData.Count == 0) 
                throw new BadRequestException("No milestones are updated because selected milestones are not existed in server or none is selected!");

            List<Process> selectedProcesses = [];

            foreach (var input in inputData)
            {
                var existingProcess = processes.FirstOrDefault(p => p.Id == input.Id);

                if (existingProcess != null)
                {
                    input.Adapt(existingProcess);
                    selectedProcesses.Add(existingProcess);
                }
                else
                {
                    // Optionally handle the case where inputData contains new items not in DB
                    var newProcess = input.Adapt<Process>();
                    newProcess.Proposal.Id = proposalId;
                    selectedProcesses.Add(newProcess);
                }
            }
            return await _processRepository.UpdateProcesses(selectedProcesses);
        }
        public async Task<bool> Delete(List<ProcessUpdateBM> inputData, Guid proposalId)
        {
            List<Process> processes = await _processRepository.GetProcessesByProposalId(proposalId);
            if (processes.Count == 0 || inputData.Count == 0)
                throw new BadRequestException("No milestones are deleted because selected milestones are not existed in server or none is selected!");
            List<Process> selectedProcesses = [];
            foreach (var input in inputData)
            {
                var existingProcess = processes.FirstOrDefault(p => p.Id == input.Id);

                if (existingProcess != null)
                {
                    input.Adapt(existingProcess);
                    selectedProcesses.Add(existingProcess);
                }
            }
            return await _processRepository.DeleteProcesses(selectedProcesses);
        }
        public async Task<List<ProcessBM>> GetProcessbyProposalId(Guid proposalId)
        {
            var processes = await _processRepository.GetProcessesByProposalId(proposalId);
            var processBms = processes.Adapt<List<ProcessBM>>();
            return processBms;
        }

        public Task<bool> Add(List<ProcessBM> inputData)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProcessBM>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ProcessBM> GetProcessById(Guid id)
        {
            var process = await _processRepository.GetByIdAsync(id);
            if (process == null)
            {
                return null;
            }
            var a = process.Adapt<ProcessBM>();
            return process.Adapt<ProcessBM>();
        }

        public Task<bool> SubmitTask(Guid id, TaskSubmissionModel model)
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
