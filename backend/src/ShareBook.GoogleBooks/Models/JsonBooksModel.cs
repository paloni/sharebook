using System.Collections.Generic;
using ShareBook.GoogleBooks.Models;

namespace ShareBook.GoogleBooks
{
    public class SearchBookDto
    {
        public GoogleBook VolumeInfo { get; set; } = new GoogleBook();
    }
    public class JsonBooksModel
    {
        public IEnumerable<SearchBookDto> Items { get; set; } = new List<SearchBookDto>();
    }
}