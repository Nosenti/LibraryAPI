using LibraryAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Data
{
    public class BookLibraryContext : DbContext
    {
        public BookLibraryContext(DbContextOptions<BookLibraryContext> options) : base(options) { }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
    }
}
