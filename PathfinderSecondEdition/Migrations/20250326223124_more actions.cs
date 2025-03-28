using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PathfinderSecondEdition.Migrations
{
    /// <inheritdoc />
    public partial class moreactions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CharacterSheetModels",
                keyColumn: "CharacterSheetModelId",
                keyValue: 2,
                column: "PathfinderActions",
                value: "[1,0,2]");

            migrationBuilder.UpdateData(
                table: "CharacterSheetModels",
                keyColumn: "CharacterSheetModelId",
                keyValue: 3,
                column: "PathfinderActions",
                value: "[1,0,2]");

            migrationBuilder.UpdateData(
                table: "CharacterSheetModels",
                keyColumn: "CharacterSheetModelId",
                keyValue: 4,
                column: "PathfinderActions",
                value: "[1,0,2]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CharacterSheetModels",
                keyColumn: "CharacterSheetModelId",
                keyValue: 2,
                column: "PathfinderActions",
                value: "[1,0]");

            migrationBuilder.UpdateData(
                table: "CharacterSheetModels",
                keyColumn: "CharacterSheetModelId",
                keyValue: 3,
                column: "PathfinderActions",
                value: "[1,0]");

            migrationBuilder.UpdateData(
                table: "CharacterSheetModels",
                keyColumn: "CharacterSheetModelId",
                keyValue: 4,
                column: "PathfinderActions",
                value: "[1,0]");
        }
    }
}
