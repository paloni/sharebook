using System;

namespace ShareBook.Domain.Entities
{
    public class BookInstance
    {
        public Guid BookInstanceId { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public DateTime Added { get; set; }
        public LoanStatus LoanStatus { get; set; }

    }
}