using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShareBook.Domain.Entities;

namespace ShareBook.Data.Configurations
{
    public class GenreConfig : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder
                    .Property(b => b.Name)
                    .IsRequired()
                    .HasMaxLength(250);
        }
    }
}