using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShareBook.Domain.Entities;
using ShareBook.Domain.Interfaces;
using ShareBook.Domain.Models;

namespace ShareBook.Domain.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookDetails>> GetBooksByUserAsync(string userId);
        Task<IEnumerable<BookDetails>> SearchByIsbn(string isbn);
        Task AddBookAsync(BookDetails book);
    }
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task AddBookAsync(BookDetails book)
        {
            await bookRepository.AddAsync(book);
        }

        public async Task<IEnumerable<BookDetails>> GetBooksByUserAsync(string userId)
        {
            IEnumerable<Book> models = await bookRepository.GetBooksByUserAsync(userId);

            return models.Select(b => new BookDetails()
            {
                Id = b.BookId,
                Title = b.Title,
                Summary = b.Summary,
                Thumbnail = b.Thumbnail,
                Isbn13 = b.Isbn13,
                Isbn10 = b.Isbn10,
                Authors = b.Authors.Select(a => a.Name),
                Genres = b.Genres.Select(g => g.Name),
                Tags = b.Tags.Select(t => t.Name),
                LanguageId = b.Language.LanguageId,
                Quantity = b.BookInstances.Count
            });
        }

        public Task<IEnumerable<BookDetails>> SearchByIsbn(string isbn)
        {
            throw new System.NotImplementedException();
        }
    }
}