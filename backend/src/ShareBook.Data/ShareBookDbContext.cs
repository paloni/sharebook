using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShareBook.Domain.Entities;

namespace ShareBook.Data
{
    public class ShareBookDbContext : IdentityDbContext<AppUser>
    {
        public ShareBookDbContext(DbContextOptions<ShareBookDbContext> options)
            : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<BookInstance> BookInstances { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<LoanStatus> LoanStatuses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(assembly: typeof(ShareBookDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}