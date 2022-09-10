using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Template.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materijali",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Boja = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Tip = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materijali", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prodavnice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prihod = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodavnice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    ProdavnicaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Korisnici_Prodavnice_ProdavnicaId",
                        column: x => x.ProdavnicaId,
                        principalTable: "Prodavnice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Spojevi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CenaMaterijala = table.Column<int>(type: "int", nullable: false),
                    ProdavnicaId = table.Column<int>(type: "int", nullable: true),
                    MaterijalId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spojevi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Spojevi_Materijali_MaterijalId",
                        column: x => x.MaterijalId,
                        principalTable: "Materijali",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Spojevi_Prodavnice_ProdavnicaId",
                        column: x => x.ProdavnicaId,
                        principalTable: "Prodavnice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Kuce",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdavnicaId = table.Column<int>(type: "int", nullable: true),
                    KorisnikId = table.Column<int>(type: "int", nullable: false),
                    DatumPorudzbine = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cena = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kuce", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kuce_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kuce_Prodavnice_ProdavnicaId",
                        column: x => x.ProdavnicaId,
                        principalTable: "Prodavnice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_ProdavnicaId",
                table: "Korisnici",
                column: "ProdavnicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Kuce_KorisnikId",
                table: "Kuce",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Kuce_ProdavnicaId",
                table: "Kuce",
                column: "ProdavnicaId");

            migrationBuilder.CreateIndex(
                name: "IX_Spojevi_MaterijalId",
                table: "Spojevi",
                column: "MaterijalId");

            migrationBuilder.CreateIndex(
                name: "IX_Spojevi_ProdavnicaId",
                table: "Spojevi",
                column: "ProdavnicaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kuce");

            migrationBuilder.DropTable(
                name: "Spojevi");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "Materijali");

            migrationBuilder.DropTable(
                name: "Prodavnice");
        }
    }
}
