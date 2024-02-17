using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updateUrlRecordEntity2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsRoot",
                table: "UrlRecord",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IsRoot",
                table: "UrlRecord",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)",
                oldNullable: true);
        }
    }
}
