using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartAIEssayChecker.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Essays");

            migrationBuilder.AddColumn<Guid>(
                name: "EssayId",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Users_EssayId",
                table: "Users",
                column: "EssayId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Essays_EssayId",
                table: "Users",
                column: "EssayId",
                principalTable: "Essays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Essays_EssayId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_EssayId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EssayId",
                table: "Users");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Essays",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
