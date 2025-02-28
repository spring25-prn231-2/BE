using ChillLancer.BusinessService.BusinessModels;

namespace ChillLancer.BusinessService.Interfaces
{
    public interface ILanguageService
    {
        Task<bool> CreateLanguage(LanguageBM inputData);
        Task<bool> AddLanguageToAccount(LanguageBM inputData);
        Task<LanguageBM> ViewLanguage(Guid id);
        Task<List<LanguageBM>> GetAllLanguages();
        Task<List<LanguageBM>> GetUserLanguages(Guid userId);
        Task<bool> UpdateLanguage(LanguageBM newData);
        Task<bool> DeleteLanguage(Guid id);
    }
}
