using ChillLancer.Repository.Interfaces;
using ChillLancer.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace ChillLancer.Repository.Repositories
{
    public class LanguageRepository : GenericRepository<Language>, ILanguageRepository
    {
        private readonly ChillLancerDbContext _context;
        public LanguageRepository(ChillLancerDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<bool> AddLanguagesToUser(AccountLanguage acclang)
        {
            await _context.AccountLanguages.AddAsync(acclang);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<AccountLanguage>?> GetLanguagesByUserId(Guid userId)
        {
            return await _context.AccountLanguages
            .Include(lan => lan.Language)
            .Where(lan => lan.AccountId == userId)
            .AsNoTracking()
            .ToListAsync();
        }
    }
}
