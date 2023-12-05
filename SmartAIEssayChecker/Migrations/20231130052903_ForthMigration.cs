using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartAIEssayChecker.Migrations
{
    /// <inheritdoc />
    public partial class ForthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Essays_Feedbacks_FeedbackId",
                table: "Essays");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Essays_EssayId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_EssayId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EssayId",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "FeedbackId",
                table: "Essays",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Essays_FeedbackId",
                table: "Essays",
                newName: "IX_Essays_UserId");

            migrationBuilder.AddColumn<Guid>(
                name: "EssayId",
                table: "Feedbacks",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_EssayId",
                table: "Feedbacks",
                column: "EssayId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Essays_Users_UserId",
                table: "Essays",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Essays_EssayId",
                table: "Feedbacks",
                column: "EssayId",
                principalTable: "Essays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Essays_Users_UserId",
                table: "Essays");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Essays_EssayId",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_EssayId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "EssayId",
                table: "Feedbacks");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Essays",
                newName: "FeedbackId");

            migrationBuilder.RenameIndex(
                name: "IX_Essays_UserId",
                table: "Essays",
                newName: "IX_Essays_FeedbackId");

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
                name: "FK_Essays_Feedbacks_FeedbackId",
                table: "Essays",
                column: "FeedbackId",
                principalTable: "Feedbacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Essays_EssayId",
                table: "Users",
                column: "EssayId",
                principalTable: "Essays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
