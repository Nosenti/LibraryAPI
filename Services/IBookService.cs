using LibraryAPI.Dtos;
using LibraryAPI.Entities;

namespace LibraryAPI.Services
{
    public interface IBookService
    {
        Task<Book> CreateBookAsync(BookDto bookDto);
        Task<IEnumerable<Book>> GetAllBooksAsync();
    }
}
