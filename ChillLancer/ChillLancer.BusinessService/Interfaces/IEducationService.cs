using ChillLancer.BusinessService.BusinessModels;

namespace ChillLancer.BusinessService.Interfaces
{
    public interface IEducationService
    {
        Task<bool> CreateEducation(EducationBM inputData);
        Task<EducationBM> ViewEducation(Guid id);
        Task<List<EducationBM>> GetAllEducations();
        Task<List<EducationBM>> GetUserEducations(Guid userId);
        Task<bool> UpdateEducation(EducationBM newData);
        Task<bool> DeleteEducation(Guid id);
    }
}
