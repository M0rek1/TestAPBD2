using WebApplication1.Data;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Repositories;

namespace WebApplication1.Services;

public class BookService(IBookRepository bookRepository, ApbdContext context)
{
    public async Task<Book> AddBookAsync(BookDTO bookDto)
        {
            var book = new Book
            {
                Title = bookDto.Title,
                ReleaseDate = bookDto.ReleaseDate,
                PublishingHouseId = bookDto.PublishingHouseId,
                BookGenres = bookDto.Genres.Select(g => new BookGenre
                {
                    GenreId = g.Id,
                    Genre = context.Genres.FirstOrDefault(genre => genre.Id == g.Id) ?? new Genre { Name = g.Name }
                }).ToList(),
                BookAuthors = bookDto.AuthorIds.Select(authorId => new BookAuthor
                {
                    AuthorId = authorId
                }).ToList()
            };

            book = await bookRepository.AddBookAsync(book);

            return new Book
            {
                Id = book.Id,
                Title = book.Title,
                ReleaseDate = book.ReleaseDate,
                PublishingHouseId = book.PublishingHouseId,
                BookGenres = book.BookGenres.Select(bg => new BookGenre
                {
                    BookId = bg.BookId,
                    GenreId = bg.GenreId,
                    Genre = new Genre
                    {
                        Id = bg.Genre.Id,
                        Name = bg.Genre.Name
                    }
                }).ToList(),
                BookAuthors = book.BookAuthors.Select(ba => new BookAuthor
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
            };
        }
    }