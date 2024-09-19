namespace LibraryAPI.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public DateTime PublishedDate { get; set; }

        // Foreign Key
        public int AuthorId { get; set; }

        // Navigation Property
        public Author Author { get; set; }
    }
}
