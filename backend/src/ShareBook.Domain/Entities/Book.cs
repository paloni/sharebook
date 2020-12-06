using System;
using System.Collections.Generic;

namespace ShareBook.Domain.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Isbn13 { get; set; }
        public string Isbn10 { get; set; }
        public IList<Author> Authors { get; set; }
        public IList<Genre> Genres { get; set; }
        public IList<BookInstance> BookInstances { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
        public string OwnerId { get; set; }

        public override string ToString()
        {
            return $"Id: {BookId}; Title: {Title}; OwnerId: {OwnerId}";
        }
    }
}
