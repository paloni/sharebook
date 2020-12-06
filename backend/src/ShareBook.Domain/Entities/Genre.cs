using System.Collections.Generic;

namespace ShareBook.Domain.Entities
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public IList<Book> Books { get; set; }

        public override string ToString()
        {
            return $"Genre Id: {GenreId}; Name: {Name}";
        }
    }
}