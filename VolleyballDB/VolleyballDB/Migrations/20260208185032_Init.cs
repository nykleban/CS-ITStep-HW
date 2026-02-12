using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VolleyballDB.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeamHomeId = table.Column<int>(type: "int", nullable: false),
                    TeamAwayId = table.Column<int>(type: "int", nullable: false),
                    Team1Score = table.Column<int>(type: "int", nullable: false),
                    Team2Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Teams_TeamAwayId",
                        column: x => x.TeamAwayId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Teams_TeamHomeId",
                        column: x => x.TeamHomeId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "A" },
                    { 2, "B" },
                    { 3, "C" },
                    { 4, "D" },
                    { 5, "E" },
                    { 6, "F" },
                    { 7, "G" },
                    { 8, "H" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Team1Score", "Team2Score", "TeamAwayId", "TeamHomeId" },
                values: new object[,]
                {
                    { 1, 3, 1, 8, 1 },
                    { 2, 2, 3, 7, 2 },
                    { 3, 3, 0, 6, 3 },
                    { 4, 1, 3, 5, 4 },
                    { 5, 3, 2, 7, 1 },
                    { 6, 0, 3, 6, 8 },
                    { 7, 3, 1, 5, 2 },
                    { 8, 2, 3, 4, 3 },
                    { 9, 1, 3, 6, 1 },
                    { 10, 3, 0, 5, 7 },
                    { 11, 2, 3, 4, 8 },
                    { 12, 0, 3, 3, 2 },
                    { 13, 3, 0, 5, 1 },
                    { 14, 3, 1, 4, 6 },
                    { 15, 2, 3, 3, 7 },
                    { 16, 3, 2, 2, 8 },
                    { 17, 2, 3, 4, 1 },
                    { 18, 3, 1, 3, 5 },
                    { 19, 2, 3, 2, 6 },
                    { 20, 3, 0, 8, 7 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_TeamAwayId",
                table: "Games",
                column: "TeamAwayId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_TeamHomeId",
                table: "Games",
                column: "TeamHomeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Teams");
        }
    }
}
