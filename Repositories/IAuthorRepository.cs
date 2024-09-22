using LibraryAPI.Entities;

namespace LibraryAPI.Repositories
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAuthorsAsync();
        Task<Author> AddAuthorAsync(Author author);
    }
}
