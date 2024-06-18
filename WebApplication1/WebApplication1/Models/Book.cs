namespace WebApplication1.Models

{

    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int PublishingHouseId { get; set; }
        public PublishingHouse PublishingHouse { get; set; }
        public ICollection<BookGenre> BookGenres { get; set; }
        public ICollection<BookAuthor> BookAuthors { get; set; }
    }
}