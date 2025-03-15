using ChillLancer.BusinessService.BusinessModels;
using ChillLancer.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillLancer.BusinessService.Interfaces
{
    public interface IProjectService
    {
        Task<bool> CallRepository();
        Task<List<ProjectBM>> GetProjects();
        Task<Project> GetProjectById(Guid id);
        Task<List<ProjectBM>> GetProjectsByEmployerId(Guid employerId);
        Task<List<ProjectBM>> getProjectsByFreelancerId(Guid freelancerId);
        Task<bool> DeleteProject(Guid id);
        Task<bool> UpdateProject(Guid id, ProjectBM projectModel);
        Task<bool> UpdateProjectStatus(Guid id, string status);
        Task<bool> CreateProject(ProjectBM projectModel);
    }
}
