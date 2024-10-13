using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KCK_Project__Console_Pocket_trainer_.Migrations
{
    /// <inheritdoc />
    public partial class Change_Muscle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Muslce",
                table: "Exercises",
                newName: "Muscle");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Muscle",
                table: "Exercises",
                newName: "Muslce");
        }
    }
}
