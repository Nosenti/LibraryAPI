using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Dtos
{
    public class AuthorDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }
    }
}
