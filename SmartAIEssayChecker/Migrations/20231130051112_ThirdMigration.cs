using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartAIEssayChecker.Migrations
{
    /// <inheritdoc />
    public partial class ThirdMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EssayId",
                table: "Feedbacks");

            migrationBuilder.AddColumn<Guid>(
                name: "FeedbackId",
                table: "Essays",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Essays_FeedbackId",
                table: "Essays",
                column: "FeedbackId");

            migrationBuilder.AddForeignKey(
                name: "FK_Essays_Feedbacks_FeedbackId",
                table: "Essays",
                column: "FeedbackId",
                principalTable: "Feedbacks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Essays_Feedbacks_FeedbackId",
                table: "Essays");

            migrationBuilder.DropIndex(
                name: "IX_Essays_FeedbackId",
                table: "Essays");

            migrationBuilder.DropColumn(
                name: "FeedbackId",
                table: "Essays");

            migrationBuilder.AddColumn<Guid>(
                name: "EssayId",
                table: "Feedbacks",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
