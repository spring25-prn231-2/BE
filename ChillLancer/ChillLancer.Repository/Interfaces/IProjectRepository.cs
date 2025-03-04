using ChillLancer.Repository.Models;

namespace ChillLancer.Repository.Interfaces
{
    public interface IProjectRepository : IGenericRepository<Project>
    {
        Task<bool> CallDb();


    }
}
