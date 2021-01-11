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
        private readonly ILanguageRepository languageRepository;

        public BookService(IBookRepository bookRepository, ILanguageRepository languageRepository)
        {
            this.bookRepository = bookRepository;
            this.languageRepository = languageRepository;
        }

        public async Task AddBookAsync(BookDetails book)
        {
            List<Language> languages = new List<Language>();
            foreach (var abbriviation in book.Languages)
            {
                Language entity = languageRepository.GetByAbbriviation(abbriviation);
                if (entity == null)
                {
                    entity = await languageRepository.AddLanguageAsync(new Language()
                    {
                        Abbriviation = abbriviation,
                        Name = GetLanguageNameByAbbriviation(abbriviation)
                    });
                }
                languages.Add(entity);
            }
            await bookRepository.AddAsync(book);
        }
        private string GetLanguageNameByAbbriviation(string abbriviation)
        {
            List<(string, string)> languages = new List<(string, string)>();
            languages.Add(("en", "English"));
            languages.Add(("ru", "Russian"));

            string name = languages.FirstOrDefault(l => l.Item1 == abbriviation).Item2;
            return name ?? abbriviation;

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
                Quantity = b.BookInstances.Count,
                Languages = b.Languages.Select(l => l.Name)
            });
        }

        public Task<IEnumerable<BookDetails>> SearchByIsbn(string isbn)
        {
            throw new System.NotImplementedException();
        }
    }
}