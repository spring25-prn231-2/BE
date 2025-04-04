using ChillLancer.BusinessService.BusinessModels;
using ChillLancer.BusinessService.Extensions.Exceptions;
using ChillLancer.BusinessService.Interfaces;
using ChillLancer.Repository.Interfaces;
using ChillLancer.Repository.Models;
using ChillLancer.Repository.Repositories;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillLancer.BusinessService.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly ISkillRepository _skillRepository;
        public ProjectService(IProjectRepository projectRepository,
            ICategoryRepository categoryRepository,
            IAccountRepository accountRepository,
            ISkillRepository skillRepository)
        {
            _projectRepository = projectRepository;
            _categoryRepository = categoryRepository;
            _accountRepository = accountRepository;
            _skillRepository = skillRepository;
        }
        public async Task<bool> CallRepository()
        {
            return await _projectRepository.CallDb();
        }

        public async Task<bool> CreateProject(ProjectCreateBM projectModel)
        {
            try
            {
                //Date validation
                if (projectModel.StartDate < DateTime.Now)
                {
                    throw new BadRequestException("startDate must not in the past");
                }
                if (projectModel.EndDate <= projectModel.StartDate)
                {
                    throw new BadRequestException("startDate must before endDate");
                }

                var project = projectModel.Adapt<Project>();
                //Employer
                var employer = await _accountRepository.GetByIdAsync(projectModel.EmployerId);
                if (employer == null) 
                {
                    throw new NotFoundException("Employer is not found");
                }
                project.Employer = employer;
                //Category
                var category = await _categoryRepository.GetByIdAsync(projectModel.CategoryId);
                if (category == null)
                {
                    throw new NotFoundException("Category is not found");
                }
                project.Category = category;
                await _projectRepository.AddAsync(project);
                await _projectRepository.SaveChangeAsync();

                //Skills
                if (projectModel.skillIds != null && projectModel.skillIds.Any())
                {
                    var skills = _skillRepository.GetAll().Where(s => projectModel.skillIds.Contains(s.Id)).ToList();
                    if (skills.Count != projectModel.skillIds.Count)
                    {
                        throw new NotFoundException("One or more skills not found");
                    }

                    project.ProjectSkills = skills.Select(skill => new ProjectSkill
                    {
                        ProjectId = project.Id,
                        SkillId = skill.Id,
                    }).ToList();
                }
                await _projectRepository.UpdateAsync(project);
                await _projectRepository.SaveChangeAsync();
                return true;
            }
            catch (Exception ex)
            {
                //await _projectRepository.RollbackAsync();
                throw new BadRequestException(ex.Message);
            }
        }

        public async Task<bool> DeleteProject(Guid id)
        {
            try
            {
                var project = await _projectRepository.GetByIdAsync(id);
                if (project == null)
                {
                    return false;
                }
                await _projectRepository.DeleteAsync(project);
                return true;
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }

        public async Task<Project> GetProjectById(Guid id)
        {
            try
            {
                var project = await _projectRepository.GetByIdAsync(id);
                if (project == null)
                {
                    throw new NotFoundException("");
                }
                return project;
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }

        public async Task<List<ProjectBM>> GetProjectsByEmployerId(Guid employerId)
        {
            try
            {
                var projects = await _projectRepository.GetProjectsByEmployerId(employerId);
                if (projects == null || projects.Count == 0) 
                {
                    throw new NotFoundException("");
                }
                return projects.Adapt<List<ProjectBM>>();
            }
            catch (Exception ex)
            {
                throw new BadRequestException(ex.Message);
            }
        }

        public Task<List<ProjectBM>> getProjectsByFreelancerId(Guid freelancerId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdateProject(Guid id, ProjectBM projectModel)
        {
            try
            {
                //Date validation
                if (projectModel.StartDate < DateTime.Now)
                {
                    throw new BadRequestException("startDate must not in the past");
                }
                if (projectModel.EndDate <= projectModel.StartDate)
                {
                    throw new BadRequestException("startDate must before endDate");
                }

                var project = await _projectRepository.GetByIdAsync(id);
                //Employer
                var employer = await _accountRepository.GetByIdAsync(projectModel.EmployerId);
                if (employer == null)
                {
                    throw new NotFoundException("Employer is not found");
                }
                project.Employer = employer;
                //Category
                var category = await _categoryRepository.GetByIdAsync(projectModel.CategoryId);
                if (category == null)
                {
                    throw new NotFoundException("Category is not found");
                }
                project.Category = category;

                //Skills
                if (projectModel.skillIds != null && projectModel.skillIds.Any())
                {
                    var skills = _skillRepository.GetAll().Where(s => projectModel.skillIds.Contains(s.Id)).ToList();
                    if (skills.Count != projectModel.skillIds.Count)
                    {
                        throw new NotFoundException("One or more skills not found");
                    }

                    project.ProjectSkills = (ICollection<ProjectSkill>?)skills.Select(skill => new ProjectSkill
                    {
                        ProjectId = project.Id,
                        SkillId = skill.Id,
                    });
                }
                await _projectRepository.AddAsync(project);
                await _projectRepository.SaveChangeAsync();
                return true;
            }
            catch (Exception ex)
            {
                //await _projectRepository.RollbackAsync();
                throw new BadRequestException(ex.Message);
            }
        }

        public async Task<bool> UpdateProjectStatus(Guid id, string status)
        {
            try
            {
                var project = await _projectRepository.GetByIdAsync(id);
                if (project == null)
                {
                    throw new NotFoundException("");
                }
                project.Status = status;
                _projectRepository.UpdateAsync(project);
                return true;
            }
            catch (Exception ex)
            {
                //await _projectRepository.RollbackAsync();
                throw new BadRequestException(ex.Message);
            }
        }

        public async Task<List<ProjectBM>> GetProjects()
        {
            var a = await _projectRepository.GetAll().AsNoTracking().ToListAsync<Project>();
            //var a = await _projectRepository.GetListAsync(p => true);
            return a.Adapt<List<ProjectBM>>();
        }

        public async Task<List<ProjectBM>> GetListProjectsByCategory(string categoryName)
        {
            var existCategory = await _categoryRepository.GetOneAsync(cate => cate.SpecializedName.Equals(categoryName))
                ?? throw new NotFoundException("Not found this category!");

            var projects = await _projectRepository.GetListAsync(proj => proj.Category.SpecializedName.Equals(existCategory.SpecializedName))
                ?? throw new NotFoundException("Not found any project!"); ;
            return projects.Adapt<List<ProjectBM>>();
        }
    }
}
