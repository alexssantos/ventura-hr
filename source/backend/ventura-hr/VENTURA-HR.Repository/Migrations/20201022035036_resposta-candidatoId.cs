using Microsoft.EntityFrameworkCore.Migrations;

namespace VENTURA_HR.Repository.Migrations
{
    public partial class respostacandidatoId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resposta_Candidato_CandidatoId",
                table: "Resposta");

            migrationBuilder.RenameColumn(
                name: "CandidatoId",
                table: "Resposta",
                newName: "id_candidatoid");

            migrationBuilder.RenameIndex(
                name: "IX_Resposta_CandidatoId",
                table: "Resposta",
                newName: "IX_Resposta_id_candidatoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Resposta_Candidato_id_candidatoid",
                table: "Resposta",
                column: "id_candidatoid",
                principalTable: "Candidato",
                principalColumn: "id_candidato",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resposta_Candidato_id_candidatoid",
                table: "Resposta");

            migrationBuilder.RenameColumn(
                name: "id_candidatoid",
                table: "Resposta",
                newName: "CandidatoId");

            migrationBuilder.RenameIndex(
                name: "IX_Resposta_id_candidatoid",
                table: "Resposta",
                newName: "IX_Resposta_CandidatoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resposta_Candidato_CandidatoId",
                table: "Resposta",
                column: "CandidatoId",
                principalTable: "Candidato",
                principalColumn: "id_candidato",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
