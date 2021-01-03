using System.Collections.Generic;
using System.Threading.Tasks;
using ShareBook.Domain.Models;

namespace ShareBook.Domain.Interfaces
{
    public interface IInternetBookService
    {
        Task<IEnumerable<BookDetails>> SearchAsync(InternetBookSearchParams searchParams);
    }
}