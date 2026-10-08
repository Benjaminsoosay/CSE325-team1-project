using System.ComponentModel.DataAnnotations;

using CommunityLibrary.Data;

namespace CommunityLibrary.Models;

public class BookLoan
{
    public int Id { get; set; }

    [Required]
    public string UserId { get; set; } = string.Empty;
    public ApplicationUser User { get; set; } = null!;

    public int BookId { get; set; }
    public Book Book { get; set; } = null!;

    public DateTime BorrowedDate { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime? ReturnedDate { get; set; }

    public bool IsReturned => ReturnedDate.HasValue;
    public bool IsOverdue => !IsReturned && DateTime.Today > DueDate;
}
