using Microsoft.EntityFrameworkCore.Migrations;

namespace VENTURA_HR.Repository.Migrations
{
    public partial class empresacriterios3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Criterio_Empresa_id_empresa",
                table: "Criterio");

            migrationBuilder.DropForeignKey(
                name: "FK_Resposta_Candidato_id_candidato",
                table: "Resposta");

            migrationBuilder.DropForeignKey(
                name: "FK_Resposta_Vaga_VagaId",
                table: "Resposta");

            migrationBuilder.RenameColumn(
                name: "VagaId",
                table: "Resposta",
                newName: "vaga_id");

            migrationBuilder.RenameColumn(
                name: "id_candidato",
                table: "Resposta",
                newName: "candidato_id");

            migrationBuilder.RenameIndex(
                name: "IX_Resposta_VagaId",
                table: "Resposta",
                newName: "IX_Resposta_vaga_id");

            migrationBuilder.RenameIndex(
                name: "IX_Resposta_id_candidato",
                table: "Resposta",
                newName: "IX_Resposta_candidato_id");

            migrationBuilder.RenameColumn(
                name: "id_empresa",
                table: "Criterio",
                newName: "empresa_id");

            migrationBuilder.RenameIndex(
                name: "IX_Criterio_id_empresa",
                table: "Criterio",
                newName: "IX_Criterio_empresa_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Criterio_Empresa_empresa_id",
                table: "Criterio",
                column: "empresa_id",
                principalTable: "Empresa",
                principalColumn: "id_empresa",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resposta_Candidato_candidato_id",
                table: "Resposta",
                column: "candidato_id",
                principalTable: "Candidato",
                principalColumn: "id_candidato",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resposta_Vaga_vaga_id",
                table: "Resposta",
                column: "vaga_id",
                principalTable: "Vaga",
                principalColumn: "id_vaga");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Criterio_Empresa_empresa_id",
                table: "Criterio");

            migrationBuilder.DropForeignKey(
                name: "FK_Resposta_Candidato_candidato_id",
                table: "Resposta");

            migrationBuilder.DropForeignKey(
                name: "FK_Resposta_Vaga_vaga_id",
                table: "Resposta");

            migrationBuilder.RenameColumn(
                name: "vaga_id",
                table: "Resposta",
                newName: "VagaId");

            migrationBuilder.RenameColumn(
                name: "candidato_id",
                table: "Resposta",
                newName: "id_candidato");

            migrationBuilder.RenameIndex(
                name: "IX_Resposta_vaga_id",
                table: "Resposta",
                newName: "IX_Resposta_VagaId");

            migrationBuilder.RenameIndex(
                name: "IX_Resposta_candidato_id",
                table: "Resposta",
                newName: "IX_Resposta_id_candidato");

            migrationBuilder.RenameColumn(
                name: "empresa_id",
                table: "Criterio",
                newName: "id_empresa");

            migrationBuilder.RenameIndex(
                name: "IX_Criterio_empresa_id",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Resposta_Vaga_VagaId",
                table: "Resposta",
                column: "VagaId",
                principalTable: "Vaga",
                principalColumn: "id_vaga");
        }
    }
}
