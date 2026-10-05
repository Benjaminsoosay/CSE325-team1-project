using CommunityLibrary.Data;
using CommunityLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace CommunityLibrary.Services;

public class LoanService
{
    private readonly ApplicationDbContext _context;

    public LoanService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<(bool Success, string Message)> BorrowBookAsync(
        int bookId,
        string userId)
    {
        // Find the book
        var book = await _context.Books
            .FirstOrDefaultAsync(b => b.Id == bookId);

        if (book == null)
            return (false, "Book not found.");

        // Check availability
        if (book.AvailableCopies <= 0)
            return (false, "This book is currently unavailable.");

        // Check if this user already has an active loan
        var alreadyBorrowed = await _context.Loans
            .AnyAsync(l =>
                l.BookId == bookId &&
                l.UserId == userId &&
                l.ReturnedAt == null);

        if (alreadyBorrowed)
            return (false, "You already have this book borrowed.");

        // Create loan
        var loan = new Loan
        {
            BookId = bookId,
            UserId = userId,
            BorrowedAt = DateTime.UtcNow,
            DueDate = DateTime.UtcNow.AddDays(14)
        };

        // Decrease available copies
        book.AvailableCopies--;

        _context.Loans.Add(loan);

        await _context.SaveChangesAsync();

        return (true, $"You successfully borrowed \"{book.Title}\".");
    }

    public async Task<(bool Success, string Message)> ReturnBookAsync(int loanId, string userId)
    {
        var loan = await _context.Loans
            .Include(l => l.Book)
            .FirstOrDefaultAsync(l =>
                l.Id == loanId &&
                l.UserId == userId &&
                l.ReturnedAt == null);

        if (loan == null)
            return (false, "Active loan not found.");

        loan.ReturnedAt = DateTime.UtcNow;

        if (loan.Book != null)
        {
            loan.Book.AvailableCopies++;
        }

        await _context.SaveChangesAsync();

        return (true, $"You returned \"{loan.Book?.Title}\".");
    }

    public async Task<List<Loan>> GetUserLoansAsync(string userId)
    {
        return await _context.Loans
            .Include(l => l.Book)
            .ThenInclude(b => b!.Category)
            .Where(l => l.UserId == userId)
            .OrderByDescending(l => l.BorrowedAt)
            .AsNoTracking()
            .ToListAsync();
    }
}