using CommunityLibrary.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CommunityLibrary.Controllers;

// handles book file downloads like cover images and pdfs
[Route("api/books")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly BookService _bookService;

    public BooksController(BookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet("{id}/cover")]
    public async Task<IActionResult> GetCover(int id)
    {
        var (data, contentType) = await _bookService.GetBookCoverAsync(id);
        if (data is null || contentType is null)
            return NotFound();

        return File(data, contentType);
    }

    [Authorize]
    [HttpGet("{id}/pdf")]
    public async Task<IActionResult> DownloadPdf(int id)
    {
        var (data, fileName) = await _bookService.GetBookPdfAsync(id);
        if (data is null || fileName is null)
            return NotFound();

        return File(data, "application/pdf", fileName);
    }
}
