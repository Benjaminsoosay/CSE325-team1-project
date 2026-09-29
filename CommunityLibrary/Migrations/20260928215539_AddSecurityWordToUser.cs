using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommunityLibrary.Migrations
{
    /// <inheritdoc />
    public partial class AddSecurityWordToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SecurityWord",
                table: "AspNetUsers",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SecurityWord",
                table: "AspNetUsers");
        }
    }
}
