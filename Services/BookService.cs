using LibraryAPI.Dtos;
using LibraryAPI.Entities;
using LibraryAPI.Repositories;

namespace LibraryAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _bookRepository.GetAllBooksAsync();
        }
        public async Task<Book> CreateBookAsync(BookDto bookDto)
        {
            var author = await _bookRepository.GetAuthorByIdAsync(bookDto.AuthorId);
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

            return await _bookRepository.AddBookAsync(newBook);
        }
    }
}
