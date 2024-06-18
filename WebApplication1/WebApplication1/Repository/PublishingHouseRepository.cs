using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories;

public class PublishingHouseRepository(ApbdContext context) : IPublishingHouseRepository
{
    public async Task<IEnumerable<PublishingHouse>> GetPublishingHousesAsync(string country, string city)
    {
        var query = context.PublishingHouses.Include(ph => ph.Books)
            .ThenInclude(b => b.BookGenres)
            .ThenInclude(bg => bg.Genre)
            .Include(ph => ph.Books)
            .ThenInclude(b => b.BookAuthors)
            .ThenInclude(ba => ba.Author)
            .AsQueryable();

        if (!string.IsNullOrEmpty(country))
        {
            query = query.Where(ph => ph.Country == country);
        }
        if (!string.IsNullOrEmpty(city))
        {
            query = query.Where(ph => ph.City == city);
        }

        return await query.OrderBy(ph => ph.Country).ThenBy(ph => ph.Name).ToListAsync();
    }
}   