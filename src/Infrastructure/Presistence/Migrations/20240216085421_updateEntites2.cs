using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateEntites2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "PageCategories");

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "UrlRecord",
                type: "char(36)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "UrlRecord");

            migrationBuilder.AddColumn<Guid>(
                name: "ParentId",
                table: "PageCategories",
                type: "char(36)",
                nullable: true);
        }
    }
}
