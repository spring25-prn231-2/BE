using ChillLancer.BusinessService.BusinessModels;

namespace ChillLancer.BusinessService.Interfaces
{
    public interface ISkillService
    {
        Task<bool> CreateSkill(SkillBM inputData);
        Task<bool> AddProjectSkills(List<SkillBM> listSkill);
        Task<bool> AddProposalSkills(List<SkillBM> listSkill);
        Task<SkillBM> ViewSkill(Guid id);
        Task<List<SkillBM>> GetAllSkills();
        Task<List<SkillBM>> GetProjectSkills(Guid ProjectId);
        Task<List<SkillBM>> GetProposalSkills(Guid proposalId);
        Task<bool> UpdateSkill(SkillBM newData);
        Task<bool> DeleteSkill(Guid id);
    }
}
