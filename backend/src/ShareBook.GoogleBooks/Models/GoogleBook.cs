using System.Collections.Generic;

namespace ShareBook.GoogleBooks.Models
{
    public class IndustryIdentifier
    {
        public string Type { get; set; }
        public string Identifier { get; set; }
    }
    public class ImageLink
    {
        public string SmallThumbnail { get; set; }
        public string Thumbnail { get; set; }
    }
    public class GoogleBook
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ImageLink ImageLinks { get; set; }
        public IEnumerable<IndustryIdentifier> industryIdentifiers { get; set; }
        public IEnumerable<string> Authors { get; set; }
        public string Language { get; set; }
    }
}