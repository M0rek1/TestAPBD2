using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services;

public class PublishingHouseService(IPublishingHouseRepository repository)
{
    public async Task<IEnumerable<PublishingHouse>> GetPublishingHousesAsync(string country, string city)
    {
        var publishingHouses = await repository.GetPublishingHousesAsync(country, city);
        return publishingHouses.Select(ph => new PublishingHouse
        {
            Id = ph.Id,
            Name = ph.Name,
            Country = ph.Country,
            City = ph.City,
            Books = ph.Books.Select(b => new Book
            {
                Id = b.Id,
                Title = b.Title,
                ReleaseDate = b.ReleaseDate,
                PublishingHouseId = b.PublishingHouseId,
                BookGenres = b.BookGenres.Select(bg => new BookGenre
                {
                    BookId = bg.BookId,
                    GenreId = bg.GenreId,
                    Genre = new Genre
                    {
                        Id = bg.Genre.Id,
                        Name = bg.Genre.Name
                    }
                }).ToList(),
                BookAuthors = b.BookAuthors.Select(ba => new BookAuthor
                {
                    BookId = ba.BookId,
                    AuthorId = ba.AuthorId,
                    Author = new Author
                    {
                        Id = ba.Author.Id,
                        FirstName = ba.Author.FirstName,
                        LastName = ba.Author.LastName
                    }
                }).ToList()
            }).ToList()
        });
    }
}