using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShareBook.Domain.Entities;

namespace ShareBook.Data.Configurations
{
    public class LanguageConfig : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.Property(b => b.Name).IsRequired().HasMaxLength(100);
            builder
                .HasMany(b => b.Books)
                .WithOne(b => b.Language)
                .HasForeignKey(b => b.LanguageId);
        }
    }
}