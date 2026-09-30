namespace CommunityLibrary.Models;

public class Loan
{
    public int Id { get; set; }

    public int BookId { get; set; }

    public Book? Book { get; set; }

    public string UserId { get; set; } = string.Empty;

    public DateTime BorrowedAt { get; set; } = DateTime.UtcNow;

    public DateTime DueDate { get; set; }

    public DateTime? ReturnedAt { get; set; }

    public bool IsReturned => ReturnedAt.HasValue;
}