using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, ErrorMessage = "Title can not be longer than 100 characters")]
        public string Title { get; set; }
        public DateTime PublishedDate { get; set; }
        public string AuthorFullName { get; set; }
        [Required(ErrorMessage = "AuthorId is required")]
        public int AuthorId { get; set; }
    }
}
