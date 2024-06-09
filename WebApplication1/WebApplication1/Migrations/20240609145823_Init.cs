using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Muzyk",
                columns: table => new
                {
                    IdMuzyk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Pseudonim = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdMuzyk", x => x.IdMuzyk);
                });

            migrationBuilder.CreateTable(
                name: "Utwor",
                columns: table => new
                {
                    IdUtwor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaUtworu = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CzasTrwania = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdUtwor", x => x.IdUtwor);
                });

            migrationBuilder.CreateTable(
                name: "WykonawacaUtworu",
                columns: table => new
                {
                    IdMuzyk = table.Column<int>(type: "int", nullable: false),
                    IdUtwor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WykonawacaUtworu", x => new { x.IdMuzyk, x.IdUtwor });
                    table.ForeignKey(
                        name: "FK_WykonawacaUtworu_Muzyk_IdMuzyk",
                        column: x => x.IdMuzyk,
                        principalTable: "Muzyk",
                        principalColumn: "IdMuzyk",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WykonawacaUtworu_Utwor_IdUtwor",
                        column: x => x.IdUtwor,
                        principalTable: "Utwor",
                        principalColumn: "IdUtwor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Muzyk",
                columns: new[] { "IdMuzyk", "Imie", "Nazwisko", "Pseudonim" },
                values: new object[,]
                {
                    { 1, "Anna", "Nowak", null },
                    { 2, "Kazimierz", "Malinowski", "Kazik" }
                });

            migrationBuilder.InsertData(
                table: "Utwor",
                columns: new[] { "IdUtwor", "CzasTrwania", "NazwaUtworu" },
                values: new object[,]
                {
                    { 1, 2.2f, "spiewanie" },
                    { 2, 3.5f, "granie" },
                    { 3, 5.3f, "Gitara" }
                });

            migrationBuilder.InsertData(
                table: "WykonawacaUtworu",
                columns: new[] { "IdMuzyk", "IdUtwor" },
                values: new object[,]
                {
                    { 1, 3 },
                    { 2, 1 },
                    { 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WykonawacaUtworu_IdUtwor",
                table: "WykonawacaUtworu",
                column: "IdUtwor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WykonawacaUtworu");

            migrationBuilder.DropTable(
                name: "Muzyk");

            migrationBuilder.DropTable(
                name: "Utwor");
        }
    }
}
