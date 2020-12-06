using System;
using System.Collections.Generic;

namespace ShareBook.DL.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Summary { get; set; }
        public string Isbn { get; set; }
        public ICollection<Author> Authors { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}; Title: {Title};";
        }
    }
}
