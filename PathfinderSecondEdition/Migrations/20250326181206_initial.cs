using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PathfinderSecondEdition.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CharacterSheetModels",
                columns: table => new
                {
                    CharacterSheetModelId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Level = table.Column<int>(type: "INTEGER", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    CurrentHP = table.Column<int>(type: "INTEGER", nullable: false),
                    MaxHP = table.Column<int>(type: "INTEGER", nullable: false),
                    Speed = table.Column<int>(type: "INTEGER", nullable: false),
                    PathfinderActions = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSheetModels", x => x.CharacterSheetModelId);
                });

            migrationBuilder.CreateTable(
                name: "AbilityScores",
                columns: table => new
                {
                    AbilityScoreId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Strength = table.Column<int>(type: "INTEGER", nullable: false),
                    Dexterity = table.Column<int>(type: "INTEGER", nullable: false),
                    Constitution = table.Column<int>(type: "INTEGER", nullable: false),
                    Intelligence = table.Column<int>(type: "INTEGER", nullable: false),
                    Wisdom = table.Column<int>(type: "INTEGER", nullable: false),
                    Charisma = table.Column<int>(type: "INTEGER", nullable: false),
                    CharacterSheetModelId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbilityScores", x => x.AbilityScoreId);
                    table.ForeignKey(
                        name: "FK_AbilityScores_CharacterSheetModels_CharacterSheetModelId",
                        column: x => x.CharacterSheetModelId,
                        principalTable: "CharacterSheetModels",
                        principalColumn: "CharacterSheetModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CharacterSheetModels",
                columns: new[] { "CharacterSheetModelId", "CurrentHP", "FirstName", "LastName", "Level", "MaxHP", "PathfinderActions", "Speed" },
                values: new object[,]
                {
                    { 1, 15, "Konjit", "Munaye", 1, 15, "[1,0]", 30 },
                    { 2, 22, "Kanandi", "Oladoyinbo", 1, 22, "[1,0]", 25 },
                    { 3, 14, "Cris", "Marcellus", 1, 14, "[1,0]", 25 },
                    { 4, 0, "Unkown", "Person", 1, 0, "[1,0]", 25 }
                });

            migrationBuilder.InsertData(
                table: "AbilityScores",
                columns: new[] { "AbilityScoreId", "CharacterSheetModelId", "Charisma", "Constitution", "Dexterity", "Intelligence", "Strength", "Wisdom" },
                values: new object[,]
                {
                    { 1, 1, 10, 10, 10, 10, 10, 10 },
                    { 2, 2, 10, 10, 10, 10, 10, 10 },
                    { 3, 3, 10, 10, 10, 10, 10, 10 },
                    { 4, 4, 10, 10, 10, 10, 10, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbilityScores_CharacterSheetModelId",
                table: "AbilityScores",
                column: "CharacterSheetModelId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbilityScores");

            migrationBuilder.DropTable(
                name: "CharacterSheetModels");
        }
    }
}
