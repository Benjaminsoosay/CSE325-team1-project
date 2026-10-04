using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CommunityLibrary.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    SecurityWord = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserPasskeys",
                columns: table => new
                {
                    CredentialId = table.Column<byte[]>(type: "bytea", maxLength: 1024, nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Data = table.Column<string>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserPasskeys", x => x.CredentialId);
                    table.ForeignKey(
                        name: "FK_AspNetUserPasskeys_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Author = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    CategoryID = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    CoverImageUrl = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    TotalCopies = table.Column<int>(type: "integer", nullable: false),
                    AvailableCopies = table.Column<int>(type: "integer", nullable: false),
                    PublishedDate = table.Column<DateOnly>(type: "date", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BookId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    BorrowedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ReturnedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loans_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Novels, short stories, and other fictional works.", "Fiction" },
                    { 2, "Stories involving science, technology, space, and the future.", "Science Fiction" },
                    { 3, "Stories involving magic, mythical creatures, and imaginary worlds.", "Fantasy" },
                    { 4, "Detective stories, investigations, and crime mysteries.", "Mystery" },
                    { 5, "Suspenseful stories involving danger, crime, and high-stakes situations.", "Thriller" },
                    { 6, "Stories centered around romantic relationships.", "Romance" },
                    { 7, "Books documenting the lives of real people.", "Biography" },
                    { 8, "Books about historical events, people, and civilizations.", "History" },
                    { 9, "Books covering computing, programming, software, and technology.", "Technology" },
                    { 10, "Books covering scientific concepts, discoveries, and research.", "Science" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "AvailableCopies", "CategoryID", "CoverImageUrl", "CreatedAt", "Description", "PublishedDate", "Title", "TotalCopies", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "George Orwell", 5, 1, "https://covers.openlibrary.org/b/isbn/9780451524935-L.jpg", new DateTime(2026, 9, 30, 10, 0, 0, 0, DateTimeKind.Utc), "A dystopian novel exploring surveillance, government control, and individual freedom.", new DateOnly(1949, 6, 8), "1984", 5, null },
                    { 2, "J.R.R. Tolkien", 4, 3, "https://covers.openlibrary.org/b/isbn/9780547928227-L.jpg", new DateTime(2026, 9, 30, 10, 5, 0, 0, DateTimeKind.Utc), "Bilbo Baggins joins a company of dwarves on an adventure to reclaim their homeland.", new DateOnly(1937, 9, 21), "The Hobbit", 4, null },
                    { 3, "Frank Herbert", 6, 2, "https://covers.openlibrary.org/b/isbn/9780441172719-L.jpg", new DateTime(2026, 9, 30, 10, 10, 0, 0, DateTimeKind.Utc), "A science fiction epic centered around politics, power, survival, and the desert planet Arrakis.", new DateOnly(1965, 8, 1), "Dune", 6, null },
                    { 4, "F. Scott Fitzgerald", 3, 1, "https://covers.openlibrary.org/b/isbn/9780743273565-L.jpg", new DateTime(2026, 9, 30, 10, 15, 0, 0, DateTimeKind.Utc), "A classic novel about wealth, ambition, love, and the American Dream.", new DateOnly(1925, 4, 10), "The Great Gatsby", 5, null },
                    { 5, "J.K. Rowling", 5, 3, "https://covers.openlibrary.org/b/isbn/9780747532699-L.jpg", new DateTime(2026, 9, 30, 10, 20, 0, 0, DateTimeKind.Utc), "A young wizard begins his education at Hogwarts and discovers a hidden connection to his past.", new DateOnly(1997, 6, 26), "Harry Potter and the Philosopher's Stone", 7, null },
                    { 6, "Dan Brown", 2, 4, "https://covers.openlibrary.org/b/isbn/9780307474278-L.jpg", new DateTime(2026, 9, 30, 10, 25, 0, 0, DateTimeKind.Utc), "A mystery thriller involving hidden symbols, secret societies, and an ancient mystery.", new DateOnly(2003, 4, 1), "The Da Vinci Code", 4, null },
                    { 7, "Robert C. Martin", 3, 9, "https://covers.openlibrary.org/b/isbn/9780132350884-L.jpg", new DateTime(2026, 9, 30, 10, 30, 0, 0, DateTimeKind.Utc), "A practical guide to writing readable, maintainable, and professional software.", new DateOnly(2008, 8, 1), "Clean Code", 3, null },
                    { 8, "David Thomas and Andrew Hunt", 4, 9, "https://covers.openlibrary.org/b/isbn/9780135957059-L.jpg", new DateTime(2026, 9, 30, 10, 35, 0, 0, DateTimeKind.Utc), "A guide to practical software development principles, techniques, and professional habits.", new DateOnly(1999, 10, 20), "The Pragmatic Programmer", 4, null },
                    { 9, "Stephen Hawking", 4, 10, "https://covers.openlibrary.org/b/isbn/9780553380163-L.jpg", new DateTime(2026, 9, 30, 10, 40, 0, 0, DateTimeKind.Utc), "An accessible exploration of cosmology, black holes, time, and the origins of the universe.", new DateOnly(1988, 4, 1), "A Brief History of Time", 5, null },
                    { 10, "Walter Isaacson", 2, 7, "https://covers.openlibrary.org/b/isbn/9781451648539-L.jpg", new DateTime(2026, 9, 30, 10, 45, 0, 0, DateTimeKind.Utc), "A biography examining the life, career, and innovations of Apple co-founder Steve Jobs.", new DateOnly(2011, 10, 24), "Steve Jobs", 3, null },
                    { 11, "Yuval Noah Harari", 5, 8, "https://covers.openlibrary.org/b/isbn/9780062316097-L.jpg", new DateTime(2026, 9, 30, 10, 50, 0, 0, DateTimeKind.Utc), "An exploration of human history from early humans to modern civilization.", new DateOnly(2011, 1, 1), "Sapiens", 5, null },
                    { 12, "Alex Michaelides", 1, 4, "https://covers.openlibrary.org/b/isbn/9781250301697-L.jpg", new DateTime(2026, 9, 30, 10, 55, 0, 0, DateTimeKind.Utc), "A psychological mystery surrounding a woman who suddenly stops speaking after a violent crime.", new DateOnly(2019, 2, 5), "The Silent Patient", 4, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserPasskeys_UserId",
                table: "AspNetUserPasskeys",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryID",
                table: "Books",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_BookId",
                table: "Loans",
                column: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserPasskeys");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
