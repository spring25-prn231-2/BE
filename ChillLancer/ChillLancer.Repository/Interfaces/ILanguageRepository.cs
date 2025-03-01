using ChillLancer.Repository.Models;

namespace ChillLancer.Repository.Interfaces
{
    public interface ILanguageRepository : IGenericRepository<Language>
    {
        Task<bool> AddLanguagesToUser(AccountLanguage acclang);
        Task<List<AccountLanguage>?> GetLanguagesByUserId(Guid userId);
    }
}
