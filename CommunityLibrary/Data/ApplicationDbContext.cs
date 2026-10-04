using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CommunityLibrary.Models;

namespace CommunityLibrary.Data;

public class ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Book> Books { get; set; }
    // public DbSet<Book> Books => Set<Book>();
    public DbSet<BookLoan> BookLoans => Set<BookLoan>();
    public DbSet<Category> Categories { get; set; }

    public DbSet<Loan> Loans { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Book>().HasData(
            new Book
            {
                Id = 1,
                Title = "1984",
                Author = "George Orwell",
                CategoryID = 1,
                Description = "A dystopian novel exploring surveillance, government control, and individual freedom.",
                CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9780451524935-L.jpg",
                TotalCopies = 5,
                AvailableCopies = 5,
                PublishedDate = new DateOnly(1949, 6, 8),
                CreatedAt = new DateTime(2026, 9, 30, 10, 00, 00, DateTimeKind.Utc)
            },

            new Book
            {
                Id = 2,
                Title = "The Hobbit",
                Author = "J.R.R. Tolkien",
                CategoryID = 3,
                Description = "Bilbo Baggins joins a company of dwarves on an adventure to reclaim their homeland.",
                CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9780547928227-L.jpg",
                TotalCopies = 4,
                AvailableCopies = 4,
                PublishedDate = new DateOnly(1937, 9, 21),
                CreatedAt = new DateTime(2026, 9, 30, 10, 05, 00, DateTimeKind.Utc)
            },

            new Book
            {
                Id = 3,
                Title = "Dune",
                Author = "Frank Herbert",
                CategoryID = 2,
                Description = "A science fiction epic centered around politics, power, survival, and the desert planet Arrakis.",
                CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9780441172719-L.jpg",
                TotalCopies = 6,
                AvailableCopies = 6,
                PublishedDate = new DateOnly(1965, 8, 1),
                CreatedAt = new DateTime(2026, 9, 30, 10, 10, 00, DateTimeKind.Utc)
            },

            new Book
            {
                Id = 4,
                Title = "The Great Gatsby",
                Author = "F. Scott Fitzgerald",
                CategoryID = 1,
                Description = "A classic novel about wealth, ambition, love, and the American Dream.",
                CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9780743273565-L.jpg",
                TotalCopies = 5,
                AvailableCopies = 3,
                PublishedDate = new DateOnly(1925, 4, 10),
                CreatedAt = new DateTime(2026, 9, 30, 10, 15, 00, DateTimeKind.Utc)
            },

            new Book
            {
                Id = 5,
                Title = "Harry Potter and the Philosopher's Stone",
                Author = "J.K. Rowling",
                CategoryID = 3,
                Description = "A young wizard begins his education at Hogwarts and discovers a hidden connection to his past.",
                CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9780747532699-L.jpg",
                TotalCopies = 7,
                AvailableCopies = 5,
                PublishedDate = new DateOnly(1997, 6, 26),
                CreatedAt = new DateTime(2026, 9, 30, 10, 20, 00, DateTimeKind.Utc)
            },

            new Book
            {
                Id = 6,
                Title = "The Da Vinci Code",
                Author = "Dan Brown",
                CategoryID = 4,
                Description = "A mystery thriller involving hidden symbols, secret societies, and an ancient mystery.",
                CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9780307474278-L.jpg",
                TotalCopies = 4,
                AvailableCopies = 2,
                PublishedDate = new DateOnly(2003, 4, 1),
                CreatedAt = new DateTime(2026, 9, 30, 10, 25, 00, DateTimeKind.Utc)
            },

            new Book
            {
                Id = 7,
                Title = "Clean Code",
                Author = "Robert C. Martin",
                CategoryID = 9,
                Description = "A practical guide to writing readable, maintainable, and professional software.",
                CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9780132350884-L.jpg",
                TotalCopies = 3,
                AvailableCopies = 3,
                PublishedDate = new DateOnly(2008, 8, 1),
                CreatedAt = new DateTime(2026, 9, 30, 10, 30, 00, DateTimeKind.Utc)
            },

            new Book
            {
                Id = 8,
                Title = "The Pragmatic Programmer",
                Author = "David Thomas and Andrew Hunt",
                CategoryID = 9,
                Description = "A guide to practical software development principles, techniques, and professional habits.",
                CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9780135957059-L.jpg",
                TotalCopies = 4,
                AvailableCopies = 4,
                PublishedDate = new DateOnly(1999, 10, 20),
                CreatedAt = new DateTime(2026, 9, 30, 10, 35, 00, DateTimeKind.Utc)
            },

            new Book
            {
                Id = 9,
                Title = "A Brief History of Time",
                Author = "Stephen Hawking",
                CategoryID = 10,
                Description = "An accessible exploration of cosmology, black holes, time, and the origins of the universe.",
                CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9780553380163-L.jpg",
                TotalCopies = 5,
                AvailableCopies = 4,
                PublishedDate = new DateOnly(1988, 4, 1),
                CreatedAt = new DateTime(2026, 9, 30, 10, 40, 00, DateTimeKind.Utc)
            },

            new Book
            {
                Id = 10,
                Title = "Steve Jobs",
                Author = "Walter Isaacson",
                CategoryID = 7,
                Description = "A biography examining the life, career, and innovations of Apple co-founder Steve Jobs.",
                CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9781451648539-L.jpg",
                TotalCopies = 3,
                AvailableCopies = 2,
                PublishedDate = new DateOnly(2011, 10, 24),
                CreatedAt = new DateTime(2026, 9, 30, 10, 45, 00, DateTimeKind.Utc)
            },

            new Book
            {
                Id = 11,
                Title = "Sapiens",
                Author = "Yuval Noah Harari",
                CategoryID = 8,
                Description = "An exploration of human history from early humans to modern civilization.",
                CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9780062316097-L.jpg",
                TotalCopies = 5,
                AvailableCopies = 5,
                PublishedDate = new DateOnly(2011, 1, 1),
                CreatedAt = new DateTime(2026, 9, 30, 10, 50, 00, DateTimeKind.Utc)
            },

            new Book
            {
                Id = 12,
                Title = "The Silent Patient",
                Author = "Alex Michaelides",
                CategoryID = 4,
                Description = "A psychological mystery surrounding a woman who suddenly stops speaking after a violent crime.",
                CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9781250301697-L.jpg",
                TotalCopies = 4,
                AvailableCopies = 1,
                PublishedDate = new DateOnly(2019, 2, 5),
                CreatedAt = new DateTime(2026, 9, 30, 10, 55, 00, DateTimeKind.Utc)
            }
        );

        builder.Entity<Category>().HasData(
            new Category
            {
                Id = 1,
                Name = "Fiction",
                Description = "Novels, short stories, and other fictional works."
            },

            new Category
            {
                Id = 2,
                Name = "Science Fiction",
                Description = "Stories involving science, technology, space, and the future."
            },

            new Category
            {
                Id = 3,
                Name = "Fantasy",
                Description = "Stories involving magic, mythical creatures, and imaginary worlds."
            },

            new Category
            {
                Id = 4,
                Name = "Mystery",
                Description = "Detective stories, investigations, and crime mysteries."
            },

            new Category
            {
                Id = 5,
                Name = "Thriller",
                Description = "Suspenseful stories involving danger, crime, and high-stakes situations."
            },

            new Category
            {
                Id = 6,
                Name = "Romance",
                Description = "Stories centered around romantic relationships."
            },

            new Category
            {
                Id = 7,
                Name = "Biography",
                Description = "Books documenting the lives of real people."
            },

            new Category
            {
                Id = 8,
                Name = "History",
                Description = "Books about historical events, people, and civilizations."
            },

            new Category
            {
                Id = 9,
                Name = "Technology",
                Description = "Books covering computing, programming, software, and technology."
            },

            new Category
            {
                Id = 10,
                Name = "Science",
                Description = "Books covering scientific concepts, discoveries, and research."
            }
        );
    }
}

// public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
//     : IdentityDbContext<ApplicationUser>(options)
// {
//     public DbSet<Book> Books { get; set; }
//     public DbSet<Loan> Loans { get; set; }

//     protected override void OnModelCreating(ModelBuilder builder)
//     {
//         base.OnModelCreating(builder);

//         builder.Entity<Book>().HasData(
//             new Book
//             {
//                 Id = 1,
//                 Title = "Clean Code",
//                 Author = "Robert C. Martin",
//                 Category = "Programming",
//                 Description = "A practical guide to writing clean, readable, and maintainable software.",
//                 CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9780132350884-L.jpg",
//                 TotalCopies = 5,
//                 AvailableCopies = 5,
//                 PublishedDate = new DateOnly(2008, 8, 1),
//                 CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
//             },

//             new Book
//             {
//                 Id = 2,
//                 Title = "The Pragmatic Programmer",
//                 Author = "David Thomas & Andrew Hunt",
//                 Category = "Programming",
//                 Description = "Practical techniques and principles for becoming a better software developer.",
//                 CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9780135957059-L.jpg",
//                 TotalCopies = 4,
//                 AvailableCopies = 4,
//                 PublishedDate = new DateOnly(2019, 9, 13),
//                 CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
//             },

//             new Book
//             {
//                 Id = 3,
//                 Title = "Design Patterns",
//                 Author = "Erich Gamma, Richard Helm, Ralph Johnson, John Vlissides",
//                 Category = "Software Engineering",
//                 Description = "A classic reference on reusable object-oriented software design patterns.",
//                 CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9780201633610-L.jpg",
//                 TotalCopies = 3,
//                 AvailableCopies = 3,
//                 PublishedDate = new DateOnly(1994, 10, 21),
//                 CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
//             },

//             new Book
//             {
//                 Id = 4,
//                 Title = "Introduction to Algorithms",
//                 Author = "Thomas H. Cormen",
//                 Category = "Computer Science",
//                 Description = "A comprehensive introduction to algorithms and data structures.",
//                 CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9780262046305-L.jpg",
//                 TotalCopies = 6,
//                 AvailableCopies = 6,
//                 PublishedDate = new DateOnly(2022, 4, 5),
//                 CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
//             },

//             new Book
//             {
//                 Id = 5,
//                 Title = "The C++ Programming Language",
//                 Author = "Bjarne Stroustrup",
//                 Category = "Programming",
//                 Description = "A detailed reference and guide to modern C++ programming.",
//                 CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9780321563842-L.jpg",
//                 TotalCopies = 4,
//                 AvailableCopies = 4,
//                 PublishedDate = new DateOnly(2013, 5, 20),
//                 CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
//             },

//             new Book
//             {
//                 Id = 6,
//                 Title = "Effective C#",
//                 Author = "Bill Wagner",
//                 Category = "Programming",
//                 Description = "Practical techniques for writing robust and efficient C# applications.",
//                 CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9780672337871-L.jpg",
//                 TotalCopies = 5,
//                 AvailableCopies = 5,
//                 PublishedDate = new DateOnly(2017, 3, 15),
//                 CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
//             },

//             new Book
//             {
//                 Id = 7,
//                 Title = "Computer Networking",
//                 Author = "Andrew S. Tanenbaum",
//                 Category = "Networking",
//                 Description = "An introduction to computer networking, protocols, architectures, and applications.",
//                 CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9780132126953-L.jpg",
//                 TotalCopies = 3,
//                 AvailableCopies = 3,
//                 PublishedDate = new DateOnly(2010, 5, 1),
//                 CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
//             },

//             new Book
//             {
//                 Id = 8,
//                 Title = "The Web Application Hacker's Handbook",
//                 Author = "Dafydd Stuttard & Marcus Pinto",
//                 Category = "Cybersecurity",
//                 Description = "A guide to understanding and testing the security of web applications.",
//                 CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9781118026472-L.jpg",
//                 TotalCopies = 3,
//                 AvailableCopies = 3,
//                 PublishedDate = new DateOnly(2011, 9, 1),
//                 CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
//             },

//             new Book
//             {
//                 Id = 9,
//                 Title = "Hacking: The Art of Exploitation",
//                 Author = "Jon Erickson",
//                 Category = "Cybersecurity",
//                 Description = "An introduction to exploitation, programming, networking, and computer security.",
//                 CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9781593271442-L.jpg",
//                 TotalCopies = 2,
//                 AvailableCopies = 2,
//                 PublishedDate = new DateOnly(2008, 2, 1),
//                 CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
//             },

//             new Book
//             {
//                 Id = 10,
//                 Title = "Database System Concepts",
//                 Author = "Abraham Silberschatz",
//                 Category = "Databases",
//                 Description = "A comprehensive introduction to database systems and database management.",
//                 CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9780078022159-L.jpg",
//                 TotalCopies = 4,
//                 AvailableCopies = 4,
//                 PublishedDate = new DateOnly(2019, 1, 1),
//                 CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
//             },

//             new Book
//             {
//                 Id = 11,
//                 Title = "Artificial Intelligence: A Modern Approach",
//                 Author = "Stuart Russell & Peter Norvig",
//                 Category = "Artificial Intelligence",
//                 Description = "A comprehensive introduction to artificial intelligence and intelligent agents.",
//                 CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9780134610993-L.jpg",
//                 TotalCopies = 3,
//                 AvailableCopies = 3,
//                 PublishedDate = new DateOnly(2021, 3, 1),
//                 CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
//             },

//             new Book
//             {
//                 Id = 12,
//                 Title = "Don't Make Me Think",
//                 Author = "Steve Krug",
//                 Category = "Web Development",
//                 Description = "A practical guide to usability and intuitive web design.",
//                 CoverImageUrl = "https://covers.openlibrary.org/b/isbn/9780321344755-L.jpg",
//                 TotalCopies = 5,
//                 AvailableCopies = 5,
//                 PublishedDate = new DateOnly(2014, 1, 1),
//                 CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
//             }
                
//         );
//     }
// }


