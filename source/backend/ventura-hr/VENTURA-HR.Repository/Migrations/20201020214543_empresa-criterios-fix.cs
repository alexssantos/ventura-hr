using Microsoft.EntityFrameworkCore.Migrations;

namespace VENTURA_HR.Repository.Migrations
{
    public partial class empresacriteriosfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Criterio_Empresa_empresa_id",
                table: "Criterio");

            migrationBuilder.DropForeignKey(
                name: "FK_Resposta_Candidato_candidato_id",
                table: "Resposta");

            migrationBuilder.DropForeignKey(
                name: "FK_RespostaCriterios_VagaCriterios_VagaCriterioId",
                table: "RespostaCriterios");

            migrationBuilder.DropForeignKey(
                name: "FK_VagaCriterios_Criterio_CriterioId",
                table: "VagaCriterios");

            migrationBuilder.DropForeignKey(
                name: "FK_VagaCriterios_Vaga_VagaId",
                table: "VagaCriterios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VagaCriterios",
                table: "VagaCriterios");

            migrationBuilder.DropIndex(
                name: "IX_VagaCriterios_VagaId",
                table: "VagaCriterios");

            migrationBuilder.RenameTable(
                name: "VagaCriterios",
                newName: "VagaCriterio");

            migrationBuilder.RenameColumn(
                name: "candidato_id",
                table: "Resposta",
                newName: "CandidatoId");

            migrationBuilder.RenameIndex(
                name: "IX_Resposta_candidato_id",
                table: "Resposta",
                newName: "IX_Resposta_CandidatoId");

            migrationBuilder.RenameColumn(
                name: "empresa_id",
                table: "Criterio",
                newName: "EmpresaId");

            migrationBuilder.RenameIndex(
                name: "IX_Criterio_empresa_id",
                table: "Criterio",
                newName: "IX_Criterio_EmpresaId");

            migrationBuilder.RenameColumn(
                name: "Peso",
                table: "VagaCriterio",
                newName: "int_peso");

            migrationBuilder.RenameColumn(
                name: "PMDDescricao",
                table: "VagaCriterio",
                newName: "str_pmd_desc");

            migrationBuilder.RenameColumn(
                name: "PMD",
                table: "VagaCriterio",
                newName: "int_pmd");

            migrationBuilder.RenameColumn(
                name: "DataUltimaAtualizacao",
                table: "VagaCriterio",
                newName: "dt_atualizacao");

            migrationBuilder.RenameColumn(
                name: "DataCriacao",
                table: "VagaCriterio",
                newName: "dt_criacao");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "VagaCriterio",
                newName: "id_vaga_criterio");

            migrationBuilder.RenameIndex(
                name: "IX_VagaCriterios_CriterioId",
                table: "VagaCriterio",
                newName: "IX_VagaCriterio_CriterioId");

            migrationBuilder.AlterColumn<string>(
                name: "str_pmd_desc",
                table: "VagaCriterio",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VagaCriterio",
                table: "VagaCriterio",
                column: "id_vaga_criterio");

            migrationBuilder.CreateIndex(
                name: "IX_VagaCriterio_VagaId_CriterioId",
                table: "VagaCriterio",
                columns: new[] { "VagaId", "CriterioId" },
                unique: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_RespostaCriterios_VagaCriterio_VagaCriterioId",
                table: "RespostaCriterios",
                column: "VagaCriterioId",
                principalTable: "VagaCriterio",
                principalColumn: "id_vaga_criterio",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VagaCriterio_Criterio_CriterioId",
                table: "VagaCriterio",
                column: "CriterioId",
                principalTable: "Criterio",
                principalColumn: "id_criterio",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VagaCriterio_Vaga_VagaId",
                table: "VagaCriterio",
                column: "VagaId",
                principalTable: "Vaga",
                principalColumn: "id_vaga",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Criterio_Empresa_EmpresaId",
                table: "Criterio");

            migrationBuilder.DropForeignKey(
                name: "FK_Resposta_Candidato_CandidatoId",
                table: "Resposta");

            migrationBuilder.DropForeignKey(
                name: "FK_RespostaCriterios_VagaCriterio_VagaCriterioId",
                table: "RespostaCriterios");

            migrationBuilder.DropForeignKey(
                name: "FK_VagaCriterio_Criterio_CriterioId",
                table: "VagaCriterio");

            migrationBuilder.DropForeignKey(
                name: "FK_VagaCriterio_Vaga_VagaId",
                table: "VagaCriterio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VagaCriterio",
                table: "VagaCriterio");

            migrationBuilder.DropIndex(
                name: "IX_VagaCriterio_VagaId_CriterioId",
                table: "VagaCriterio");

            migrationBuilder.RenameTable(
                name: "VagaCriterio",
                newName: "VagaCriterios");

            migrationBuilder.RenameColumn(
                name: "CandidatoId",
                table: "Resposta",
                newName: "candidato_id");

            migrationBuilder.RenameIndex(
                name: "IX_Resposta_CandidatoId",
                table: "Resposta",
                newName: "IX_Resposta_candidato_id");

            migrationBuilder.RenameColumn(
                name: "EmpresaId",
                table: "Criterio",
                newName: "empresa_id");

            migrationBuilder.RenameIndex(
                name: "IX_Criterio_EmpresaId",
                table: "Criterio",
                newName: "IX_Criterio_empresa_id");

            migrationBuilder.RenameColumn(
                name: "int_peso",
                table: "VagaCriterios",
                newName: "Peso");

            migrationBuilder.RenameColumn(
                name: "str_pmd_desc",
                table: "VagaCriterios",
                newName: "PMDDescricao");

            migrationBuilder.RenameColumn(
                name: "int_pmd",
                table: "VagaCriterios",
                newName: "PMD");

            migrationBuilder.RenameColumn(
                name: "dt_atualizacao",
                table: "VagaCriterios",
                newName: "DataUltimaAtualizacao");

            migrationBuilder.RenameColumn(
                name: "dt_criacao",
                table: "VagaCriterios",
                newName: "DataCriacao");

            migrationBuilder.RenameColumn(
                name: "id_vaga_criterio",
                table: "VagaCriterios",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_VagaCriterio_CriterioId",
                table: "VagaCriterios",
                newName: "IX_VagaCriterios_CriterioId");

            migrationBuilder.AlterColumn<string>(
                name: "PMDDescricao",
                table: "VagaCriterios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_VagaCriterios",
                table: "VagaCriterios",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_VagaCriterios_VagaId",
                table: "VagaCriterios",
                column: "VagaId");

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
                name: "FK_RespostaCriterios_VagaCriterios_VagaCriterioId",
                table: "RespostaCriterios",
                column: "VagaCriterioId",
                principalTable: "VagaCriterios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VagaCriterios_Criterio_CriterioId",
                table: "VagaCriterios",
                column: "CriterioId",
                principalTable: "Criterio",
                principalColumn: "id_criterio",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VagaCriterios_Vaga_VagaId",
                table: "VagaCriterios",
                column: "VagaId",
                principalTable: "Vaga",
                principalColumn: "id_vaga",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
