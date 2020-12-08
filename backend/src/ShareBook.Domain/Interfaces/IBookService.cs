using System.Collections.Generic;
using System.Threading.Tasks;
using ShareBook.Domain.Models;

namespace ShareBook.Domain.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDetails>> GetBooksByUserAsync(string userId);
    }
}