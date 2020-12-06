using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShareBook.Domain.Entities;

namespace ShareBook.Data.Configurations
{
    public class LoanStatusConfig : IEntityTypeConfiguration<LoanStatus>
    {
        public void Configure(EntityTypeBuilder<LoanStatus> builder)
        {
            builder.Property(b => b.Status).IsRequired();
            builder.Property(b => b.BorrowerId).IsRequired();
        }
    }
}