using ChillLancer.BusinessService.BusinessModels;

namespace ChillLancer.BusinessService.Interfaces
{
    public interface IProcessService
    {
        Task<bool> Add(List<ProcessBM> inputData);
    }
}
