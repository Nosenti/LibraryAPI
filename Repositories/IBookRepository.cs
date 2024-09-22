using LibraryAPI.Entities;

namespace LibraryAPI.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetBookByIdAsync(int id);
        Task<Book> AddBookAsync(Book book);
        Task<Author> GetAuthorByIdAsync(int authorId);
    }
}
