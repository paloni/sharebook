using System;
using ShareBook.Domain.Helpers;

namespace ShareBook.Domain.Entities
{
    public class LoanStatus
    {
        public int LoanStatusId { get; set; }
        public Guid BookInstanceId { get; set; }
        public BookInstance BookInstance { get; set; }
        public LoanStatusType Status { get; set; }
        public DateTime? LoanStarted { get; set; }
        public DateTime? DueBack { get; set; }
        public string BorrowerId { get; set; }
    }
}