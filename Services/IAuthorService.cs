using LibraryAPI.Dtos;
using LibraryAPI.Entities;

namespace LibraryAPI.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAuthorsAsync();
        Task<Author> CreateAuthorAsync(CreateAuthorDto authorDto);
    }
}
