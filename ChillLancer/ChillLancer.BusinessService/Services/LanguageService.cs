using ChillLancer.BusinessService.BusinessModels;
using ChillLancer.BusinessService.Extensions.Exceptions;
using ChillLancer.BusinessService.Interfaces;
using ChillLancer.Repository.Interfaces;
using ChillLancer.Repository.Models;
using Mapster;

namespace ChillLancer.BusinessService.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly ILanguageRepository _languageRepository;
        public LanguageService(ILanguageRepository languageRepository)
        {
            _languageRepository = languageRepository;
        }
        public async Task<bool> CreateLanguage(LanguageBM inputData)
        {
            var existLanguages = await _languageRepository.GetOneAsync(lang =>
            lang.Name.ToLower().Equals(inputData.Name.ToLower()));

            if (existLanguages is not null) throw new ConflictException("This Languages is existed!");

            await _languageRepository.AddAsync(inputData.Adapt<Language>());
            return await _languageRepository.SaveChangeAsync();
        }

        public async Task<bool> AddLanguageToAccount(LanguageBM inputData)
        {
            var existLanguages = await GetUserLanguages(inputData.AccountId);
            foreach (LanguageBM eachLanguage in existLanguages)
            {
                if (inputData.Name.ToLower().Equals(eachLanguage.Name.ToLower()))
                {
                    throw new BadRequestException("Already add this language to your profile!");
                }
            }

            return await _languageRepository.AddLanguagesToUser(inputData.Adapt<AccountLanguage>());
        }

        public async Task<LanguageBM> ViewLanguage(Guid id)
        {
            var existLanguages = await _languageRepository.GetOneAsync(lang => lang.Id == id);

            return existLanguages is null
                ? throw new NotFoundException("This Languages is not existed!")
                : existLanguages.Adapt<LanguageBM>();
        }

        public async Task<List<LanguageBM>> GetAllLanguages()
        {
            var listResult = await _languageRepository.GetListAsync(lang => !lang.Status.ToLower().Equals("deleted"));
            return listResult.Adapt<List<LanguageBM>>();
        }

        public async Task<List<LanguageBM>> GetUserLanguages(Guid userId)
        {
            var listresult = await _languageRepository.GetLanguagesByUserId(userId);

            return listresult is null
                ? throw new NotFoundException("There are no language of this user!")
            : listresult.Adapt<List<LanguageBM>>();
        }

        public async Task<bool> UpdateLanguage(LanguageBM newData)
        {
            var existLanguages = await _languageRepository.GetOneAsync(lang => lang.Id == newData.Id)
                ?? throw new NotFoundException("This Languages is not existed!");

            newData.Adapt(existLanguages);
            return await _languageRepository.SaveChangeAsync();
        }

        public async Task<bool> DeleteLanguage(Guid id)
        {
            var existLanguages = await _languageRepository.GetOneAsync(lang => lang.Id == id)
                ?? throw new NotFoundException("This Languages is not existed!");

            existLanguages.Status = "Deleted";
            return await _languageRepository.SaveChangeAsync();
        }
    }
}
