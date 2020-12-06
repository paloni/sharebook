using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShareBook.Domain.Entities;

namespace ShareBook.Data.Configurations
{
    internal class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder
                    .HasOne<Language>(b => b.Language)
                    .WithMany(g => g.Books)
                    .HasForeignKey(b => b.LanguageId);

            builder
                    .HasMany(b => b.Authors)
                    .WithMany(a => a.Books)
                    .UsingEntity(a => a.ToTable("BookAuthors"));

            builder
                    .HasMany(b => b.Genres)
                    .WithMany(b => b.Books)
                    .UsingEntity(b => b.ToTable("BookGenres"));

            builder
                    .HasMany(b => b.BookInstances)
                    .WithOne(b => b.Book)
                    .HasForeignKey(b => b.BookId);

            builder.Property(b => b.Title).IsRequired();
            builder.Property(b => b.OwnerId).IsRequired();
            builder.Property(b => b.Summary).HasMaxLength(2000);
        }
    }
}