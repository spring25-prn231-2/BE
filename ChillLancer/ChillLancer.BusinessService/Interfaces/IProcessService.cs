using ChillLancer.BusinessService.BusinessModels;

namespace ChillLancer.BusinessService.Interfaces
{
    public interface IProcessService
    {
<<<<<<< HEAD
        Task<bool> Add(List<ProcessCreateBM> inputData);
        Task<List<ProcessBM>> GetAll();
        Task<ProcessBM> GetProcessById(Guid id);
        Task<bool> DeleteProcess(Guid id);
        Task<bool> UpdateProcess(ProcessBM process);
        Task<bool> SubmitTask(Guid id, TaskSubmissionModel model);
        Task<bool> UpdateStatus(string status, Guid id);
=======
>>>>>>> a66a21bd2063b3cca3d8475db107af1341883cf9
        //Task<bool> Add(List<ProcessBM> inputData);
        Task<bool> Update(List<ProcessUpdateBM> inputData, Guid proposalId);
        Task<bool> Delete(List<ProcessUpdateBM> inputData, Guid proposalId);
    }
}
