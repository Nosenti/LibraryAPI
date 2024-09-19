namespace LibraryAPI.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishedDate { get; set; }
        public string AuthorFullName { get; set; }
    }
}
