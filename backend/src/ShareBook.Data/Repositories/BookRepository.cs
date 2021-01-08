using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShareBook.Domain.Entities;
using ShareBook.Domain.Helpers;
using ShareBook.Domain.Interfaces;
using ShareBook.Domain.Models;

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

        public async Task AddAsync(BookDetails book)
        {
            Book entity = new Book()
            {
                Title = book.Title,
                Summary = book.Summary,
                Thumbnail = book.Thumbnail,
                Isbn13 = book.Isbn13,
                Isbn10 = book.Isbn10,
                OwnerId = book.OwnerId,
                LanguageId = book.LanguageId
            };
            _context.Books.Add(entity);
            await _context.SaveChangesAsync();

            BookInstance bookInstance = new BookInstance()
            {
                BookId = entity.BookId,
                Added = DateTime.UtcNow
            };

            _context.BookInstances.Add(bookInstance);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByUserAsync(string userId)
        {
            return await _context.Books.Where(b => b.OwnerId == userId).ToListAsync();
        }
    }
}