using CommunityLibrary.Data;
using CommunityLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace CommunityLibrary.Services;

// this file connects to the database and handles all book operations like getting, creating, updating, and deleting books
public class BookService
{
    private readonly ApplicationDbContext _context;

    public BookService(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET ALL BOOKS
    public async Task<List<Book>> GetBooksAsync()
    {
        return await _context.Books
            .Include(b => b.Category)
            .Select(b => new Book
            {
                Id = b.Id,
                Title = b.Title,
                Author = b.Author,
                CategoryID = b.CategoryID,
                Category = b.Category,
                Description = b.Description,
                CoverImageUrl = b.CoverImageUrl,
                CoverImageType = b.CoverImageType,
                TotalCopies = b.TotalCopies,
                AvailableCopies = b.AvailableCopies,
                PublishedDate = b.PublishedDate,
                PdfFileName = b.PdfFileName,
                CreatedAt = b.CreatedAt,
                UpdatedAt = b.UpdatedAt
            })
            .OrderBy(b => b.Title)
            .ToListAsync();
    }

    // GET BOOK BY ID
    public async Task<Book?> GetBookByIdAsync(int id)
    {
        return await _context.Books
            .AsNoTracking()
            .FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<List<Book>> GetBookByTitleAsync(string searchText)
    {
        var Books = await _context.Books
            .Include(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Title)
            .ToListAsync();
            
        return  Books.
        // Include(b => b.Category).AsNoTracking().OrderBy(b => b.Title).
            Where(search => search.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase) || search.Author.Contains(searchText, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    // CREATE BOOK
    public async Task<Book> CreateBookAsync(Book book)
    {
        book.CreatedAt = DateTime.UtcNow;

        _context.Books.Add(book);
        await _context.SaveChangesAsync();

        return book;
    }

    // UPDATE BOOK
    public async Task<bool> UpdateBookAsync(Book book)
    {
        var existingBook = await _context.Books
            .FirstOrDefaultAsync(b => b.Id == book.Id);

        if (existingBook == null)
            return false;

        existingBook.Title = book.Title;
        existingBook.Author = book.Author;
        existingBook.CategoryID = book.CategoryID;
        existingBook.Description = book.Description;
        existingBook.CoverImageUrl = book.CoverImageUrl;
        existingBook.TotalCopies = book.TotalCopies;
        existingBook.AvailableCopies = book.AvailableCopies;
        existingBook.PublishedDate = book.PublishedDate;
        if (book.CoverImageData != null)
        {
            existingBook.CoverImageData = book.CoverImageData;
            existingBook.CoverImageType = book.CoverImageType;
        }
        if (book.PdfData != null)
        {
            existingBook.PdfData = book.PdfData;
            existingBook.PdfFileName = book.PdfFileName;
        }
        existingBook.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
    }

    // GET cover image for a specific book
    public async Task<(byte[]? Data, string? ContentType)> GetBookCoverAsync(int id)
    {
        var book = await _context.Books
            .Where(b => b.Id == id)
            .Select(b => new { b.CoverImageData, b.CoverImageType })
            .FirstOrDefaultAsync();

        return (book?.CoverImageData, book?.CoverImageType);
    }

    // GET PDF for a specific book
    public async Task<(byte[]? Data, string? FileName)> GetBookPdfAsync(int id)
    {
        var book = await _context.Books
            .Where(b => b.Id == id)
            .Select(b => new { b.PdfData, b.PdfFileName })
            .FirstOrDefaultAsync();

        return (book?.PdfData, book?.PdfFileName);
    }

    // DELETE BOOK
    public async Task<bool> DeleteBookAsync(int id)
    {
        var book = await _context.Books
            .FirstOrDefaultAsync(b => b.Id == id);

        if (book == null)
            return false;

        _context.Books.Remove(book);

        await _context.SaveChangesAsync();

        return true;
    }
}