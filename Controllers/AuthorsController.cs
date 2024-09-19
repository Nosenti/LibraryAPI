using LibraryAPI.Dtos;
using LibraryAPI.Entities;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<ActionResult<Author>> CreateAuthor(CreateAuthorDto createAuthorDto)
        {
            try
            {
                var newAuthor = await _authorService.CreateAuthorAsync(createAuthorDto);
                return CreatedAtAction(nameof(CreateAuthor), new { id = newAuthor.Id }, newAuthor);
            }
            catch (DbUpdateException dbEx)
            {
                return BadRequest(dbEx.InnerException?.Message ?? dbEx.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAllAuthors()
        {
            try
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
