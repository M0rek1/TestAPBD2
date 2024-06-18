using WebApplication1.Models;

namespace WebApplication1.Repositories;

public interface IPublishingHouseRepository
{
    Task<IEnumerable<PublishingHouse>> GetPublishingHousesAsync(string country, string city);
}