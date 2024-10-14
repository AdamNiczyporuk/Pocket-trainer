using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KCK_Project__Console_Pocket_trainer_.Migrations
{
    /// <inheritdoc />
    public partial class UserPatch : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Height",
                table: "Users",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TrainingsPerWeek",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Weight",
                table: "Users",
                type: "real",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "TrainingsPerWeek",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Users");
        }
    }
}
