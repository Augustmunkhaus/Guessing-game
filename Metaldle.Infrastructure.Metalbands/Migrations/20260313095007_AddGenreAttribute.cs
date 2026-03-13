using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Metaldle.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddGenreAttribute : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GenreAttribute",
                table: "MetalBands",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GenreAttribute",
                table: "MetalBands");
        }
    }
}
