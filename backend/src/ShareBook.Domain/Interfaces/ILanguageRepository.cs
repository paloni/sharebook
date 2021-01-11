using System.Collections.Generic;
using System.Threading.Tasks;
using ShareBook.Domain.Entities;

namespace ShareBook.Domain.Interfaces
{
    public interface ILanguageRepository
    {
        Language GetByAbbriviation(string abbriviation);
        Task<Language> AddLanguageAsync(Language language);
    }
}