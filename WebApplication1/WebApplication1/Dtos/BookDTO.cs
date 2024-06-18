using WebApplication1.Models;

namespace WebApplication1.DTOs;

public class BookDTO
{
    public string Title { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int PublishingHouseId { get; set; }
    public List<int> AuthorIds { get; set; }
    public List<Genre> Genres { get; set; }
}