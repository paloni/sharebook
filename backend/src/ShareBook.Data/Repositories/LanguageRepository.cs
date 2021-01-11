using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShareBook.Domain.Entities;
using ShareBook.Domain.Interfaces;

namespace ShareBook.Data.Repositories
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly ShareBookDbContext _context;
        public LanguageRepository(ShareBookDbContext _context)
        {
            this._context = _context ?? throw new System.ArgumentNullException(nameof(_context));

        }
        public Language GetByAbbriviation(string abbriviation)
        {
            return _context.Languages.FirstOrDefault(l => l.Abbriviation == abbriviation);
        }
        public async Task<Language> AddLanguageAsync(Language language)
        {
            _context.Languages.Add(language);
            await _context.SaveChangesAsync();
            return language;
        }
    }
}