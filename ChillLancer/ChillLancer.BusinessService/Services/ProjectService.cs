﻿using ChillLancer.BusinessService.BusinessModels;
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
                var category = await _categoryRepository.GetByIdAsync(projectModel.categoryId);
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
                await _projectRepository.RollbackAsync();
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

        public async Task<ProjectBM> GetProjectById(Guid id)
        {
            try
            {
                var project = _projectRepository.GetAll()
                                                .AsNoTracking()
                                                .Include(p => p.Employer)
                                                .Include(p => p.Category)
                                                .Include(p => p.ProjectSkills)
                                                .ToList()
                                                .FirstOrDefault(p => p.Id ==id);
                if (project == null) {
                    throw new NotFoundException("");
                }
                var projectResponse = project.Adapt<ProjectBM>();

                var skillIds = project.ProjectSkills
                            .Select(ps => ps.SkillId)
                            .Distinct()
                            .ToList();

                var skills = await _skillRepository.GetListAsync(s => skillIds.Contains(s.Id));

                projectResponse.ProjectSkills = skills.Adapt<List<SkillBM>>();
                return projectResponse;
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
                var projects = await _projectRepository.GetListAsync(p => p.Employer.Id == employerId);
                if (projects == null || projects.Count == 0) 
                {
                    throw new NotFoundException("");
                }
                return projects.Adapt<List<ProjectBM>> ();
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

        public async Task<bool> UpdateProject(Guid id, ProjectCreateBM projectModel)
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
                var category = await _categoryRepository.GetByIdAsync(projectModel.categoryId);
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
                await _projectRepository.RollbackAsync();
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
                await _projectRepository.RollbackAsync();
                throw new BadRequestException(ex.Message);
            }
        }

        public async Task<List<ProjectBM>> GetProjects()
        {
            var projects = await _projectRepository
                .GetAll()
                .AsNoTracking()
                .Include(p => p.ProjectSkills)
                .Include(p => p.Category)
                .Include(p => p.Employer)
                .ToListAsync<Project>();
            var projectResponseList = projects.Adapt<List<ProjectBM>>();
            var skillIds = projects
                            .SelectMany(p => p.ProjectSkills) 
                            .Select(ps => ps.SkillId)          
                            .Distinct()                         
                            .ToList();

            var skills = await _skillRepository.GetListAsync(s => skillIds.Contains(s.Id));

            foreach (var projectBM in projectResponseList)
            {
                projectBM.ProjectSkills = skills
                    .Where(s => projectBM.ProjectSkills?.Any(ps => ps.Id == s.Id) ?? false)
                    .Select(s => new SkillBM { Id = s.Id, Name = s.Name }) // Map to your `SkillBM`
                    .ToList();
            }
            return projectResponseList;
        }
    }
}
