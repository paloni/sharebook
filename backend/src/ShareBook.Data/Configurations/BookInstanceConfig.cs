using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShareBook.Domain.Entities;

namespace ShareBook.Data.Configurations
{
    public class BookInstanceConfig : IEntityTypeConfiguration<BookInstance>
    {
        public void Configure(EntityTypeBuilder<BookInstance> builder)
        {
            builder
                .HasOne(b => b.Book)
                .WithMany(b => b.BookInstances)
                .HasForeignKey(b => b.BookId);

            builder
                .HasOne(b => b.LoanStatus)
                .WithOne(b => b.BookInstance)
                .HasForeignKey<LoanStatus>(b => b.BookInstanceId);
        }
    }
}