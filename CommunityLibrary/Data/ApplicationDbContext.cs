using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CommunityLibrary.Models;

namespace CommunityLibrary.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Loan> Loans { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Book>().HasData(
            new Book
            {
                Id = 1,
                Title = "Clean Code",
                Author = "Robert C. Martin",
                Category = "Programming",
                Description = "A practical guide to writing clean, readable, and maintainable software.",
                CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9780132350884-L.jpg",
                TotalCopies = 5,
                AvailableCopies = 5,
                PublishedDate = new DateOnly(2008, 8, 1),
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },

            new Book
            {
                Id = 2,
                Title = "The Pragmatic Programmer",
                Author = "David Thomas & Andrew Hunt",
                Category = "Programming",
                Description = "Practical techniques and principles for becoming a better software developer.",
                CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9780135957059-L.jpg",
                TotalCopies = 4,
                AvailableCopies = 4,
                PublishedDate = new DateOnly(2019, 9, 13),
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },

            new Book
            {
                Id = 3,
                Title = "Design Patterns",
                Author = "Erich Gamma, Richard Helm, Ralph Johnson, John Vlissides",
                Category = "Software Engineering",
                Description = "A classic reference on reusable object-oriented software design patterns.",
                CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9780201633610-L.jpg",
                TotalCopies = 3,
                AvailableCopies = 3,
                PublishedDate = new DateOnly(1994, 10, 21),
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },

            new Book
            {
                Id = 4,
                Title = "Introduction to Algorithms",
                Author = "Thomas H. Cormen",
                Category = "Computer Science",
                Description = "A comprehensive introduction to algorithms and data structures.",
                CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9780262046305-L.jpg",
                TotalCopies = 6,
                AvailableCopies = 6,
                PublishedDate = new DateOnly(2022, 4, 5),
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },

            new Book
            {
                Id = 5,
                Title = "The C++ Programming Language",
                Author = "Bjarne Stroustrup",
                Category = "Programming",
                Description = "A detailed reference and guide to modern C++ programming.",
                CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9780321563842-L.jpg",
                TotalCopies = 4,
                AvailableCopies = 4,
                PublishedDate = new DateOnly(2013, 5, 20),
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },

            new Book
            {
                Id = 6,
                Title = "Effective C#",
                Author = "Bill Wagner",
                Category = "Programming",
                Description = "Practical techniques for writing robust and efficient C# applications.",
                CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9780672337871-L.jpg",
                TotalCopies = 5,
                AvailableCopies = 5,
                PublishedDate = new DateOnly(2017, 3, 15),
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },

            new Book
            {
                Id = 7,
                Title = "Computer Networking",
                Author = "Andrew S. Tanenbaum",
                Category = "Networking",
                Description = "An introduction to computer networking, protocols, architectures, and applications.",
                CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9780132126953-L.jpg",
                TotalCopies = 3,
                AvailableCopies = 3,
                PublishedDate = new DateOnly(2010, 5, 1),
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },

            new Book
            {
                Id = 8,
                Title = "The Web Application Hacker's Handbook",
                Author = "Dafydd Stuttard & Marcus Pinto",
                Category = "Cybersecurity",
                Description = "A guide to understanding and testing the security of web applications.",
                CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9781118026472-L.jpg",
                TotalCopies = 3,
                AvailableCopies = 3,
                PublishedDate = new DateOnly(2011, 9, 1),
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },

            new Book
            {
                Id = 9,
                Title = "Hacking: The Art of Exploitation",
                Author = "Jon Erickson",
                Category = "Cybersecurity",
                Description = "An introduction to exploitation, programming, networking, and computer security.",
                CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9781593271442-L.jpg",
                TotalCopies = 2,
                AvailableCopies = 2,
                PublishedDate = new DateOnly(2008, 2, 1),
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },

            new Book
            {
                Id = 10,
                Title = "Database System Concepts",
                Author = "Abraham Silberschatz",
                Category = "Databases",
                Description = "A comprehensive introduction to database systems and database management.",
                CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9780078022159-L.jpg",
                TotalCopies = 4,
                AvailableCopies = 4,
                PublishedDate = new DateOnly(2019, 1, 1),
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },

            new Book
            {
                Id = 11,
                Title = "Artificial Intelligence: A Modern Approach",
                Author = "Stuart Russell & Peter Norvig",
                Category = "Artificial Intelligence",
                Description = "A comprehensive introduction to artificial intelligence and intelligent agents.",
                CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9780134610993-L.jpg",
                TotalCopies = 3,
                AvailableCopies = 3,
                PublishedDate = new DateOnly(2021, 3, 1),
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            },

            new Book
            {
                Id = 12,
                Title = "Don't Make Me Think",
                Author = "Steve Krug",
                Category = "Web Development",
                Description = "A practical guide to usability and intuitive web design.",
                CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9780321344755-L.jpg",
                TotalCopies = 5,
                AvailableCopies = 5,
                PublishedDate = new DateOnly(2014, 1, 1),
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            }
                
        );
    }
}