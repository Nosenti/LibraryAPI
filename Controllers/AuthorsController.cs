using LibraryAPI.Dtos;
using LibraryAPI.Entities;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
        [HttpPost]
        public async Task<ActionResult<Author>> CreateAuthor(AuthorDto authorDto)
        {
            var newAuthor = await _authorService.CreateAuthorAsync(authorDto);
            return CreatedAtAction(nameof(CreateAuthor), new { id = newAuthor.Id }, newAuthor);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAllAuthors()
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            var authorDto = authors.Select(author => new AuthorDto
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName
            }).ToList();

            return Ok(authorDto);
        }
    }
}
