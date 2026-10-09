using CommunityLibrary.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CommunityLibrary.Controllers;

// handles the book pdf download, only logged in users can access it
[Route("api/books")]
[ApiController]
[Authorize]
public class BooksController : ControllerBase
{
    private readonly BookService _bookService;

    public BooksController(BookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet("{id}/pdf")]
    public async Task<IActionResult> DownloadPdf(int id)
    {
        var (data, fileName) = await _bookService.GetBookPdfAsync(id);
        if (data is null || fileName is null)
            return NotFound();

        return File(data, "application/pdf", fileName);
    }
}
