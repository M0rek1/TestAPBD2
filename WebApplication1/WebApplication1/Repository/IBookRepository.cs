using WebApplication1.Models;

namespace WebApplication1.Repositories;

public interface IBookRepository
{
    Task<Book> AddBookAsync(Book book);
}