using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameStoreDB.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<double>(type: "float", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GameGenre",
                columns: table => new
                {
                    GamesId = table.Column<int>(type: "int", nullable: false),
                    GenresId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameGenre", x => new { x.GamesId, x.GenresId });
                    table.ForeignKey(
                        name: "FK_GameGenre_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameGenre_Genres_GenresId",
                        column: x => x.GenresId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "RPG" },
                    { 3, "Shooter" },
                    { 4, "Adventure" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Age", "Country", "Email", "Name" },
                values: new object[,]
                {
                    { 1, 0, "USA", "info@valve.com", "Valve" },
                    { 2, 0, "Poland", "contact@cdprojekt.com", "CD Projekt" },
                    { 3, 0, "France", "support@ubisoft.com", "Ubisoft" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "Name", "PublisherId", "Rating", "ReleaseDate" },
                values: new object[,]
                {
                    { 1, "Half-Life", 1, 9.8000000000000007, new DateTime(1998, 11, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 2, "Half-Life 2", 1, 9.9000000000000004, new DateTime(2004, 11, 16, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 3, "Portal", 1, 9.5, new DateTime(2007, 10, 10, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 4, "Portal 2", 1, 9.6999999999999993, new DateTime(2011, 4, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 5, "The Witcher", 2, 9.0, new DateTime(2007, 10, 26, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 6, "The Witcher 2", 2, 9.1999999999999993, new DateTime(2011, 5, 17, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 7, "The Witcher 3", 2, 9.9000000000000004, new DateTime(2015, 5, 19, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 8, "Assassin's Creed", 3, 8.8000000000000007, new DateTime(2007, 11, 13, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 9, "Far Cry 3", 3, 9.0999999999999996, new DateTime(2012, 11, 29, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { 10, "Watch Dogs", 3, 8.1999999999999993, new DateTime(2014, 5, 27, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "GameGenre",
                columns: new[] { "GamesId", "GenresId" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 2, 3 },
                    { 3, 4 },
                    { 4, 4 },
                    { 5, 2 },
                    { 6, 2 },
                    { 7, 2 },
                    { 8, 1 },
                    { 9, 1 },
                    { 10, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameGenre_GenresId",
                table: "GameGenre",
                column: "GenresId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_PublisherId",
                table: "Games",
                column: "PublisherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameGenre");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
