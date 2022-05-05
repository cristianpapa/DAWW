using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAWW.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adrese",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Strada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bloc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Scara = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apartament = table.Column<int>(type: "int", nullable: false),
                    CodPostal = table.Column<int>(type: "int", nullable: false),
                    Oras = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tara = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adrese", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plati",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Metoda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Suma = table.Column<float>(type: "real", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plati", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produse",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descriere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Producator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pret = table.Column<float>(type: "real", nullable: false),
                    Reducere = table.Column<float>(type: "real", nullable: false),
                    Marime = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Useri",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Useri", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Livrari",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAdresa = table.Column<int>(type: "int", nullable: false),
                    FirmaCurierat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Easybox = table.Column<int>(type: "int", nullable: false),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livrari", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Livrari_Adrese_IdAdresa",
                        column: x => x.IdAdresa,
                        principalTable: "Adrese",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comenzi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPlata = table.Column<int>(type: "int", nullable: false),
                    IdLivrare = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataPlasare = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comenzi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comenzi_Livrari_IdLivrare",
                        column: x => x.IdLivrare,
                        principalTable: "Livrari",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comenzi_Plati_IdPlata",
                        column: x => x.IdPlata,
                        principalTable: "Plati",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Achizitii",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdProdus = table.Column<int>(type: "int", nullable: false),
                    IdComanda = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achizitii", x => new { x.IdUser, x.IdProdus, x.IdComanda });
                    table.ForeignKey(
                        name: "FK_Achizitii_Comenzi_IdComanda",
                        column: x => x.IdComanda,
                        principalTable: "Comenzi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Achizitii_Produse_IdProdus",
                        column: x => x.IdProdus,
                        principalTable: "Produse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Achizitii_Useri_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Useri",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Achizitii_IdComanda",
                table: "Achizitii",
                column: "IdComanda");

            migrationBuilder.CreateIndex(
                name: "IX_Achizitii_IdProdus",
                table: "Achizitii",
                column: "IdProdus");

            migrationBuilder.CreateIndex(
                name: "IX_Comenzi_IdLivrare",
                table: "Comenzi",
                column: "IdLivrare",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comenzi_IdPlata",
                table: "Comenzi",
                column: "IdPlata",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Livrari_IdAdresa",
                table: "Livrari",
                column: "IdAdresa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Achizitii");

            migrationBuilder.DropTable(
                name: "Comenzi");

            migrationBuilder.DropTable(
                name: "Produse");

            migrationBuilder.DropTable(
                name: "Useri");

            migrationBuilder.DropTable(
                name: "Livrari");

            migrationBuilder.DropTable(
                name: "Plati");

            migrationBuilder.DropTable(
                name: "Adrese");
        }
    }
}
