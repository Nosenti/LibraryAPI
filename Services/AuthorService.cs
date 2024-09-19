using LibraryAPI.Data;
using LibraryAPI.Dtos;
using LibraryAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly BookLibraryContext _context;
        public AuthorService(BookLibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author> CreateAuthorAsync(CreateAuthorDto authorDto)
        {
            var newAuthor = new Author
            {
                FirstName = authorDto.FirstName,
                LastName = authorDto.LastName,
            };

            _context.Authors.Add(newAuthor);
            await _context.SaveChangesAsync();
            return newAuthor;
        }
    }
}
