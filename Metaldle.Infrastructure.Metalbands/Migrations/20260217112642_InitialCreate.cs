using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Metaldle.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MetalBands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    NumericAttribute1 = table.Column<int>(type: "integer", nullable: false),
                    NumericAttribute2 = table.Column<int>(type: "integer", nullable: false),
                    RegionAttribute = table.Column<string>(type: "text", nullable: false),
                    ContinentAttribute = table.Column<string>(type: "text", nullable: false),
                    StatusAttribute = table.Column<string>(type: "text", nullable: false),
                    ListAttribute1 = table.Column<string>(type: "text", nullable: false),
                    ListAttribute2 = table.Column<string>(type: "text", nullable: false),
                    ListAttribute3 = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MetalBands", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MetalBands_Name",
                table: "MetalBands",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MetalBands");
        }
    }
}
