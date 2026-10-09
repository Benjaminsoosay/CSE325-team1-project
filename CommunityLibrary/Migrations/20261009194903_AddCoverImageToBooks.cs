using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommunityLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddCoverImageToBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "CoverImageData",
                table: "Books",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoverImageType",
                table: "Books",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CoverImageData", "CoverImageType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CoverImageData", "CoverImageType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CoverImageData", "CoverImageType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CoverImageData", "CoverImageType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CoverImageData", "CoverImageType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CoverImageData", "CoverImageType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CoverImageData", "CoverImageType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CoverImageData", "CoverImageType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CoverImageData", "CoverImageType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CoverImageData", "CoverImageType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CoverImageData", "CoverImageType" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CoverImageData", "CoverImageType" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverImageData",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "CoverImageType",
                table: "Books");
        }
    }
}
