using System.ComponentModel.DataAnnotations;

namespace CommunityLibrary.Models;

public class Category
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [StringLength(500)]
    public string Description { get; set; } = string.Empty;

    // Navigation property
    public ICollection<Book> Books { get; set; } = new List<Book>();
}