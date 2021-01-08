using System.Collections.Generic;
using System.Threading.Tasks;
using ShareBook.Domain.Entities;
using ShareBook.Domain.Models;

namespace ShareBook.Domain.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksByUserAsync(string userId);
        Task AddAsync(BookDetails book);
    }
}