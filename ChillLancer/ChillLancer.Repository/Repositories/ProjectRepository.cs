using ChillLancer.Repository.Interfaces;
using ChillLancer.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChillLancer.Repository.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        private readonly ChillLancerDbContext _context;
        public ProjectRepository(ChillLancerDbContext context) : base(context) 
        {
            _context = context;
        }
        public async Task<bool> CallDb()
        {
            return true;
        }
    }
}
