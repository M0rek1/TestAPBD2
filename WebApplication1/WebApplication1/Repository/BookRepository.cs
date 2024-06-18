using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories;

public class BookRepository(ApbdContext context) : IBookRepository
{
    public async Task<Book> AddBookAsync(Book book)
    {
        foreach (var bookGenre in book.BookGenres)
        {
            var genre = await context.Genres
                .FirstOrDefaultAsync(g => bookGenre.Genre != null && g.Name == bookGenre.Genre.Name);
            if (genre == null) continue;
            bookGenre.GenreId = genre.Id;
            bookGenre.Genre = null;
        }
        context.Books.Add(book);
        await context.SaveChangesAsync();
        return book;
    }
}