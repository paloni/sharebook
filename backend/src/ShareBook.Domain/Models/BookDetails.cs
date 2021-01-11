using System;
using System.Collections.Generic;

namespace ShareBook.Domain.Models
{
    public class BookDetails
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Thumbnail { get; set; }
        public string Isbn13 { get; set; }
        public string Isbn10 { get; set; }
        public string Publisher { get; set; }
        public int? PageCount { get; set; }
        public IEnumerable<string> Authors { get; set; }
        public IEnumerable<string> Genres { get; set; }
        public IEnumerable<string> Tags { get; set; }
        public IEnumerable<string> Languages { get; set; }
        public int Quantity { get; set; }
        public string OwnerId { get; set; }
    }
}