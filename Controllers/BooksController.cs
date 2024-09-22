using LibraryAPI.Dtos;
using LibraryAPI.Entities;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }


        [HttpPost]
        public async Task<ActionResult<Book>> CreateBook(BookDto bookDto)
        {
            try
            {
                var newBook = await _bookService.CreateBookAsync(bookDto);
                return CreatedAtAction(nameof(CreateBook), new { id = newBook.Id }, newBook);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
        {
            try
            {
                var books = await _bookService.GetAllBooksAsync();

                var booksDto = books.Select(book => new BookDto
                {
                    Id = book.Id,
                    Title = book.Title,
                    PublishedDate = book.PublishedDate,
                    AuthorFullName = $"{book.Author.FirstName} {book.Author.LastName}"
                }).ToList();

                return Ok(booksDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
