using ChillLancer.BusinessService.Interfaces;
using ChillLancer.Repository.Interfaces;
using ChillLancer.Repository.Models;
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
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
        public async Task<bool> CallRepository()
        {
            return await _projectRepository.CallDb();
        }

        public async Task<List<Project>> GetProjects()
        {
            var a = _projectRepository.GetAll().AsNoTracking().ToListAsync<Project>();
            //var a = await _projectRepository.GetListAsync(p => true);
            return await a;
        }
    }
}
