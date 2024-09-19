namespace LibraryAPI.Dtos
{
    public class CreateBookDto
    {
        public string Title { get; set; }
        public DateTime PublishedDate { get; set; }
        public int AuthorId { get; set; }
    }
}
