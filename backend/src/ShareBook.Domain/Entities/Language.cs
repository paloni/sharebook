using System.Collections.Generic;

namespace ShareBook.Domain.Entities
{
    public class Language
    {
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public IList<Book> Books { get; set; }

        public override string ToString()
        {
            return $"Language Id: {LanguageId}; Name: {Name}";
        }
    }
}