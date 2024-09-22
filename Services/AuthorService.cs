using LibraryAPI.Dtos;
using LibraryAPI.Entities;
using LibraryAPI.Repositories;

namespace LibraryAPI.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            return await _authorRepository.GetAllAuthorsAsync();
        }

        public async Task<Author> CreateAuthorAsync(AuthorDto authorDto)
        {
            var newAuthor = new Author
            {
                FirstName = authorDto.FirstName,
                LastName = authorDto.LastName,
            };

            return await _authorRepository.AddAuthorAsync(newAuthor);
        }
    }
}
