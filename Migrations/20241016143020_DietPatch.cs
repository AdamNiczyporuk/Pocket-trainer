using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KCK_Project__Console_Pocket_trainer_.Migrations
{
    /// <inheritdoc />
    public partial class DietPatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diet_Users_UserId",
                table: "Diet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Diet",
                table: "Diet");

            migrationBuilder.RenameTable(
                name: "Diet",
                newName: "Diets");

            migrationBuilder.RenameIndex(
                name: "IX_Diet_UserId",
                table: "Diets",
                newName: "IX_Diets_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diets",
                table: "Diets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Diets_Users_UserId",
                table: "Diets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diets_Users_UserId",
                table: "Diets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Diets",
                table: "Diets");

            migrationBuilder.RenameTable(
                name: "Diets",
                newName: "Diet");

            migrationBuilder.RenameIndex(
                name: "IX_Diets_UserId",
                table: "Diet",
                newName: "IX_Diet_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Diet",
                table: "Diet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Diet_Users_UserId",
                table: "Diet",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
