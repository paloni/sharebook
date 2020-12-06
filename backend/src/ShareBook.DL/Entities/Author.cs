using System;
using System.Collections.Generic;

namespace ShareBook.DL.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfDeath { get; set; }
        public ICollection<Book> Books { get; set; }
        public override string ToString()
        {
            return $"Author Id: {Id}; Name: {Name}";
        }
    }
}