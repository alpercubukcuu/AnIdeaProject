using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class updatePageEntity7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "LanguageId",
                table: "Pages",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pages_LanguageId",
                table: "Pages",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pages_Languages_LanguageId",
                table: "Pages",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pages_Languages_LanguageId",
                table: "Pages");

            migrationBuilder.DropIndex(
                name: "IX_Pages_LanguageId",
                table: "Pages");

            migrationBuilder.AlterColumn<Guid>(
                name: "LanguageId",
                table: "Pages",
                type: "char(36)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "char(36)");
        }
    }
}
