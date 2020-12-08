using System.Collections.Generic;
using System.Threading.Tasks;
using ShareBook.Domain.Entities;
using ShareBook.Domain.Interfaces;
using ShareBook.Domain.Models;

namespace ShareBook.Domain.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public async Task<IEnumerable<BookDetails>> GetBooksByUserAsync(string userId)
        {
            IEnumerable<Book> models = await bookRepository.GetBooksByUserAsync(userId);

            return null;
        }
    }
}