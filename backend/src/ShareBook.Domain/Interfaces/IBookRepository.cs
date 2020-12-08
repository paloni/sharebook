using System.Collections.Generic;
using System.Threading.Tasks;
using ShareBook.Domain.Entities;

namespace ShareBook.Domain.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksByUserAsync(string userId);
    }
}