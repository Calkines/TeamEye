using Microsoft.EntityFrameworkCore.Migrations;

namespace TeamEye.Infra.Migrations
{
    public partial class mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campeonatos",
                columns: table => new
                {
                    Ano = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campeonatos", x => new { x.Ano, x.Nome });
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sigla = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Times",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    NomeNormalizado = table.Column<string>(nullable: true),
                    EstadoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Times", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Times_Estado_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "Estado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    CampeonatoAno = table.Column<int>(nullable: true),
                    CampeonatoNome = table.Column<string>(nullable: true),
                    TimeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalheCampeonatos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetalheCampeonatos_Times_TimeId",
                        column: x => x.TimeId,
                        principalTable: "Times",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetalheCampeonatos_Campeonatos_CampeonatoAno_CampeonatoNome",
                        columns: x => new { x.CampeonatoAno, x.CampeonatoNome },
                        principalTable: "Campeonatos",
                        principalColumns: new[] { "Ano", "Nome" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalheCampeonatos_TimeId",
                table: "DetalheCampeonatos",
                column: "TimeId");

            migrationBuilder.CreateIndex(
                name: "IX_DetalheCampeonatos_CampeonatoAno_CampeonatoNome",
                table: "DetalheCampeonatos",
                columns: new[] { "CampeonatoAno", "CampeonatoNome" });

            migrationBuilder.CreateIndex(
                name: "IX_Times_EstadoId",
                table: "Times",
                column: "EstadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalheCampeonatos");

            migrationBuilder.DropTable(
                name: "Times");

            migrationBuilder.DropTable(
                name: "Campeonatos");

            migrationBuilder.DropTable(
                name: "Estado");
        }
    }
}
