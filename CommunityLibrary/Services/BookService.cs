using CommunityLibrary.Data;
using CommunityLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace CommunityLibrary.Services;

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
            .AsNoTracking()
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
        existingBook.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return true;
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