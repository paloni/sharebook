using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShareBook.Domain.Entities;

namespace ShareBook.Data.Configurations
{
    public class LoanStatusConfig : IEntityTypeConfiguration<LoanStatus>
    {
        public void Configure(EntityTypeBuilder<LoanStatus> builder)
        {
            builder.Property(b => b.LoanStarted).IsRequired();
            builder.Property(b => b.DueBack).IsRequired();
            builder.Property(b => b.BorrowerId).IsRequired();
        }
    }
}