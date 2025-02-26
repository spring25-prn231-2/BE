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
        Task<List<Project>> GetProjects();
    }
}
