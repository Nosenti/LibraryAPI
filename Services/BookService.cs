using LibraryAPI.Data;
using LibraryAPI.Dtos;
using LibraryAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Services
{
    public class BookService : IBookService
    {
        private readonly BookLibraryContext _context;

        public BookService(BookLibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _context.Books.Include(b => b.Author).ToListAsync();
        }
        public async Task<Book> CreateBookAsync(CreateBookDto bookDto)
        {
            var author = await _context.Authors.FindAsync(bookDto.AuthorId);
            if (author == null)
            {
                throw new Exception("Author not found");
            }
            // Mapping - Check Automapper
            var newBook = new Book
            {
                Title = bookDto.Title,
                PublishedDate = bookDto.PublishedDate,
                AuthorId = bookDto.AuthorId,
            };

            _context.Books.Add(newBook);
            await _context.SaveChangesAsync();
            return newBook;
        }
    }
}
