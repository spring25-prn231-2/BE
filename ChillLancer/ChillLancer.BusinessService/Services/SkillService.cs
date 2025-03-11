using ChillLancer.BusinessService.BusinessModels;
using ChillLancer.BusinessService.Extensions.Exceptions;
using ChillLancer.BusinessService.Interfaces;
using ChillLancer.Repository.Interfaces;
using ChillLancer.Repository.Models;
using Mapster;

namespace ChillLancer.BusinessService.Services
{
    public class SkillService : ISkillService
    {
        private readonly ISkillRepository _skillRepository;
        public SkillService(ISkillRepository skillRepository)
        {
            _skillRepository = skillRepository;
        }
        public async Task<bool> CreateSkill(SkillBM inputData)
        {
            var existSkill = await _skillRepository.GetOneAsync(ski => ski.Name.ToLower().Equals(inputData.Name.ToLower()), false);

            if (existSkill is not null) throw new ConflictException("This Skill is existed!");

            await _skillRepository.AddAsync(inputData.Adapt<Skill>());
            return await _skillRepository.SaveChangeAsync();
        }

        public async Task<bool> AddProjectSkills(List<SkillBM> listSkill)
        {
            //SkillBM must have data of ProjectId
            var existSkills = await GetProjectSkills(listSkill[0].ProjectId);
            if (existSkills is not null) throw new ConflictException("Skills existed!");

            return await _skillRepository.AddSkillsToProject(listSkill.Adapt<List<ProjectSkill>>());
        }

        public async Task<bool> AddProposalSkills(List<SkillBM> listSkill)
        {
            var existSkills = await GetProposalSkills(listSkill[0].ProposalId);
            if (existSkills is not null) throw new ConflictException("Skills existed!");

            return await _skillRepository.AddSkillsToProposal(listSkill.Adapt<List<ProposalSkill>>());
        }

        public async Task<SkillBM> ViewSkill(Guid id)
        {
            var existSkill = await _skillRepository.GetOneAsync(ski => ski.Id == id);

            return existSkill is null
                ? throw new NotFoundException("This Skill is not existed!")
                : existSkill.Adapt<SkillBM>();
        }

        public async Task<List<SkillBM>> GetAllSkills()
        {
            var listResult = await _skillRepository.GetListAsync(ski => ski.Status.ToLower().Equals("created"));
            return listResult is null
                ? throw new NotFoundException("Not found any Skills!")
                : listResult.Adapt<List<SkillBM>>();
        }

        public async Task<List<SkillBM>> GetProjectSkills(Guid projectId)
        {
            var projectSkills = await _skillRepository.GetProjectSkills(projectId);
            return projectSkills is null
                ? throw new NotFoundException("Not found any skills of this Project Id!")
                : projectSkills.Adapt<List<SkillBM>>();
        }
        public async Task<List<SkillBM>> GetProposalSkills(Guid proposalId)
        {
            var proposalSkills = await _skillRepository.GetProposalSkills(proposalId);
            return proposalSkills is null
                ? throw new NotFoundException("Not found any skills of this Proposal Id!")
                : proposalSkills.Adapt<List<SkillBM>>();
        }

        public async Task<bool> UpdateSkill(SkillBM newData)
        {
            var existSkill = await _skillRepository.GetOneAsync(ski => ski.Id == newData.Id)
                ?? throw new NotFoundException("This Skill is not existed!");

            newData.Adapt(existSkill);
            return await _skillRepository.SaveChangeAsync();
        }

        public async Task<bool> DeleteSkill(Guid id)
        {
            var existSkill = await _skillRepository.GetOneAsync(ski => ski.Id == id)
                ?? throw new NotFoundException("This Skill is not existed!");

            existSkill.Status = "Deleted";
            return await _skillRepository.SaveChangeAsync();
        }
    }
}
