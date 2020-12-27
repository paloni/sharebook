using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShareBook.Domain.Entities;
using ShareBook.Domain.Interfaces;

namespace ShareBook.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ShareBookDbContext _context;

        public BookRepository(ShareBookDbContext _context)
        {
            if (_context is null)
            {
                throw new System.ArgumentNullException(nameof(_context));
            }
            this._context = _context;
        }
        public async Task<IEnumerable<Book>> GetBooksByUserAsync(string userId)
        {
            return await _context.Books.Where(b => b.OwnerId == userId).ToListAsync();
        }
    }
}