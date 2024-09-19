using System.Text.Json.Serialization;

namespace LibraryAPI.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [JsonIgnore]
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
