using System.Collections.Generic;

namespace ShareBook.Domain.Entities
{
    public class Tag
    {
        public int TagId { get; set; }
        public string Name { get; set; }
        public IList<Book> Books { get; set; }
    }
}