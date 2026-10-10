using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommunityLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddPdfToBooks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "PdfData",
                table: "Books",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PdfFileName",
                table: "Books",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PdfData", "PdfFileName" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PdfData", "PdfFileName" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PdfData", "PdfFileName" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PdfData", "PdfFileName" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PdfData", "PdfFileName" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "PdfData", "PdfFileName" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "PdfData", "PdfFileName" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "PdfData", "PdfFileName" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "PdfData", "PdfFileName" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "PdfData", "PdfFileName" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "PdfData", "PdfFileName" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "PdfData", "PdfFileName" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PdfData",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "PdfFileName",
                table: "Books");
        }
    }
}
