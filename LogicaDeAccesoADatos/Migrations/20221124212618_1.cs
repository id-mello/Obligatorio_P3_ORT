using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LogicaDeAccesoADatos.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Partidos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaHora = table.Column<DateTime>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Regiones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regiones", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IncidenciasPartido",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeleccionId = table.Column<int>(nullable: false),
                    TipoIncidencia = table.Column<string>(nullable: true),
                    Valor = table.Column<int>(nullable: false),
                    PartidoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IncidenciasPartido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IncidenciasPartido_Partidos_PartidoId",
                        column: x => x.PartidoId,
                        principalTable: "Partidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    IsoAlfa3 = table.Column<string>(nullable: true),
                    PbiPerCapita = table.Column<double>(nullable: false),
                    Poblacion = table.Column<int>(nullable: false),
                    Imagen = table.Column<string>(nullable: true),
                    RegionId = table.Column<int>(nullable: true),
                    IdRegion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paises_Regiones_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regiones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Selecciones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaisId = table.Column<int>(nullable: true),
                    IdPais = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Telefono = table.Column<int>(nullable: false),
                    CantidadApostadores = table.Column<int>(nullable: false),
                    Grupo = table.Column<string>(nullable: true),
                    PartidoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Selecciones", x => x.Id);
                    table.UniqueConstraint("AK_Selecciones_IdPais", x => x.IdPais);
                    table.ForeignKey(
                        name: "FK_Selecciones_Paises_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Selecciones_Partidos_PartidoId",
                        column: x => x.PartidoId,
                        principalTable: "Partidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IncidenciasPartido_PartidoId",
                table: "IncidenciasPartido",
                column: "PartidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Paises_IsoAlfa3",
                table: "Paises",
                column: "IsoAlfa3",
                unique: true,
                filter: "[IsoAlfa3] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Paises_RegionId",
                table: "Paises",
                column: "RegionId");

            migrationBuilder.CreateIndex(
                name: "IX_Selecciones_PaisId",
                table: "Selecciones",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Selecciones_PartidoId",
                table: "Selecciones",
                column: "PartidoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IncidenciasPartido");

            migrationBuilder.DropTable(
                name: "Selecciones");

            migrationBuilder.DropTable(
                name: "Paises");

            migrationBuilder.DropTable(
                name: "Partidos");

            migrationBuilder.DropTable(
                name: "Regiones");
        }
    }
}
