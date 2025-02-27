using ChillLancer.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace ChillLancer.Repository.Interfaces
{
    public interface ISkillRepository : IGenericRepository<Skill>
    {
        Task<bool> AddSkillsToProposal(List<ProposalSkill> skills);
        Task<bool> AddSkillsToProject(List<ProjectSkill> skills);
        Task<List<ProposalSkill>?> GetProposalSkills(Guid proposalId);
        Task<List<ProjectSkill>?> GetProjectSkills(Guid projectId);
    }
}
