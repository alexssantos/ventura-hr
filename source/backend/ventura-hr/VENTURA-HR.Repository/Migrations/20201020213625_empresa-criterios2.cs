using Microsoft.EntityFrameworkCore.Migrations;

namespace VENTURA_HR.Repository.Migrations
{
    public partial class empresacriterios2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Criterio_Empresa_EmpresaId",
                table: "Criterio");

            migrationBuilder.DropForeignKey(
                name: "FK_Resposta_Candidato_CandidatoId",
                table: "Resposta");

            migrationBuilder.RenameColumn(
                name: "CandidatoId",
                table: "Resposta",
                newName: "id_candidato");

            migrationBuilder.RenameIndex(
                name: "IX_Resposta_CandidatoId",
                table: "Resposta",
                newName: "IX_Resposta_id_candidato");

            migrationBuilder.RenameColumn(
                name: "EmpresaId",
                table: "Criterio",
                newName: "id_empresa");

            migrationBuilder.RenameIndex(
                name: "IX_Criterio_EmpresaId",
                table: "Criterio",
                newName: "IX_Criterio_id_empresa");

            migrationBuilder.AddForeignKey(
                name: "FK_Criterio_Empresa_id_empresa",
                table: "Criterio",
                column: "id_empresa",
                principalTable: "Empresa",
                principalColumn: "id_empresa",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resposta_Candidato_id_candidato",
                table: "Resposta",
                column: "id_candidato",
                principalTable: "Candidato",
                principalColumn: "id_candidato",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Criterio_Empresa_id_empresa",
                table: "Criterio");

            migrationBuilder.DropForeignKey(
                name: "FK_Resposta_Candidato_id_candidato",
                table: "Resposta");

            migrationBuilder.RenameColumn(
                name: "id_candidato",
                table: "Resposta",
                newName: "CandidatoId");

            migrationBuilder.RenameIndex(
                name: "IX_Resposta_id_candidato",
                table: "Resposta",
                newName: "IX_Resposta_CandidatoId");

            migrationBuilder.RenameColumn(
                name: "id_empresa",
                table: "Criterio",
                newName: "EmpresaId");

            migrationBuilder.RenameIndex(
                name: "IX_Criterio_id_empresa",
                table: "Criterio",
                newName: "IX_Criterio_EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Criterio_Empresa_EmpresaId",
                table: "Criterio",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "id_empresa",
                onDelete: ReferentialAction.Cascade);

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
