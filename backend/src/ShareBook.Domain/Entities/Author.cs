using System;
using System.Collections.Generic;

namespace ShareBook.Domain.Entities
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public ICollection<Book> Books { get; set; }

        public override string ToString()
        {
            return $"Author Id: {AuthorId}; Name: {Name}";
        }
    }
}