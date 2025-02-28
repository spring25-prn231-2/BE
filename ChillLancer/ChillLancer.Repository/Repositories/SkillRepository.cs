using ChillLancer.Repository.Interfaces;
using ChillLancer.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace ChillLancer.Repository.Repositories
{
    public class SkillRepository : GenericRepository<Skill>, ISkillRepository
    {
        private readonly ChillLancerDbContext _context;
        public SkillRepository(ChillLancerDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> AddSkillsToProposal(List<ProposalSkill> skills)
        {
            await _context.ProposalSkills.AddRangeAsync(skills);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<bool> AddSkillsToProject(List<ProjectSkill> skills)
        {
            await _context.ProjectSkills.AddRangeAsync(skills);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<List<ProposalSkill>?> GetProposalSkills(Guid proposalId)
        {
            return await _context.ProposalSkills
            .Include(propSki => propSki.Skill)
            .Where(propSki => propSki.ProposalId == proposalId)
            .AsNoTracking()
            .ToListAsync();
        }

        public async Task<List<ProjectSkill>?> GetProjectSkills(Guid projectId)
        {
            return await _context.ProjectSkills
            .Include(projSki => projSki.Skill)
            .Where(projSki => projSki.ProjectId == projectId)
            .AsNoTracking()
            .ToListAsync();
        }
    }
}
