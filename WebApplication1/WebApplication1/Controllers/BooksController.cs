using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTOs;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController(BookService bookService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Book>> PostBook(BookDTO book)
    {
        var result = await bookService.AddBookAsync(book);
        return result;
    }
}