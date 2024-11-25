using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIAMBIPARDEV.Migrations
{
    /// <inheritdoc />
    public partial class Teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencias_ResponsavelAberturaId",
                table: "Ocorrencias",
                column: "ResponsavelAberturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Ocorrencias_ResponsavelOcorrenciaId",
                table: "Ocorrencias",
                column: "ResponsavelOcorrenciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencias_Clientes_ResponsavelAberturaId",
                table: "Ocorrencias",
                column: "ResponsavelAberturaId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ocorrencias_Clientes_ResponsavelOcorrenciaId",
                table: "Ocorrencias",
                column: "ResponsavelOcorrenciaId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencias_Clientes_ResponsavelAberturaId",
                table: "Ocorrencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Ocorrencias_Clientes_ResponsavelOcorrenciaId",
                table: "Ocorrencias");

            migrationBuilder.DropIndex(
                name: "IX_Ocorrencias_ResponsavelAberturaId",
                table: "Ocorrencias");

            migrationBuilder.DropIndex(
                name: "IX_Ocorrencias_ResponsavelOcorrenciaId",
                table: "Ocorrencias");
        }
    }
}
