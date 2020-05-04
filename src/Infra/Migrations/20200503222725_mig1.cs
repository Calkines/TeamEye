using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamEye.Infra.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campeonatos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ano = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campeonatos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sigla = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Times",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    NomeNormalizado = table.Column<string>(nullable: true),
                    EstadoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Times", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Times_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalheCampeonatos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Posicao = table.Column<int>(nullable: false),
                    Pontos = table.Column<int>(nullable: false),
                    Jogos = table.Column<int>(nullable: false),
                    Vitorias = table.Column<int>(nullable: false),
                    Empates = table.Column<int>(nullable: false),
                    Derrotas = table.Column<int>(nullable: false),
                    GolsPro = table.Column<int>(nullable: false),
                    GolsContra = table.Column<int>(nullable: false),
                    CampeonatoId = table.Column<int>(nullable: false),
                    TimeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalheCampeonatos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalheCampeonatos_Campeonatos_CampeonatoId",
                        column: x => x.CampeonatoId,
                        principalTable: "Campeonatos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalheCampeonatos_Times_TimeId",
                        column: x => x.TimeId,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Campeonatos_Ano_Nome",
                table: "Campeonatos",
                columns: new[] { "Ano", "Nome" },
                unique: true,
                filter: "[Nome] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_DetalheCampeonatos_TimeId",
                table: "DetalheCampeonatos",
                column: "TimeId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalheCampeonatos_CampeonatoId_TimeId",
                table: "DetalheCampeonatos",
                columns: new[] { "CampeonatoId", "TimeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estados_Sigla",
                table: "Estados",
                column: "Sigla",
                unique: true,
                filter: "[Sigla] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Times_EstadoId_NomeNormalizado",
                table: "Times",
                columns: new[] { "EstadoId", "NomeNormalizado" },
                unique: true,
                filter: "[NomeNormalizado] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalheCampeonatos");

            migrationBuilder.DropTable(
                name: "Campeonatos");

            migrationBuilder.DropTable(
                name: "Times");

            migrationBuilder.DropTable(
                name: "Estados");
        }
    }
}
