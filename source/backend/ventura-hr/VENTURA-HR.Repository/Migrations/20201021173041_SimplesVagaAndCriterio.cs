using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VENTURA_HR.Repository.Migrations
{
    public partial class SimplesVagaAndCriterio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Criterio_Empresa_EmpresaId",
                table: "Criterio");

            migrationBuilder.DropForeignKey(
                name: "FK_RespostaCriterios_Resposta_RespostaId",
                table: "RespostaCriterios");

            migrationBuilder.DropForeignKey(
                name: "FK_RespostaCriterios_VagaCriterio_VagaCriterioId",
                table: "RespostaCriterios");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaga_Empresa_EmpresaId",
                table: "Vaga");

            migrationBuilder.DropTable(
                name: "VagaCriterio");

            migrationBuilder.DropIndex(
                name: "IX_Criterio_EmpresaId",
                table: "Criterio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RespostaCriterios",
                table: "RespostaCriterios");

            migrationBuilder.DropIndex(
                name: "IX_RespostaCriterios_VagaCriterioId",
                table: "RespostaCriterios");

            migrationBuilder.DropColumn(
                name: "str_cargo",
                table: "Criterio");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Criterio");

            migrationBuilder.DropColumn(
                name: "VagaCriterioId",
                table: "RespostaCriterios");

            migrationBuilder.RenameTable(
                name: "RespostaCriterios",
                newName: "RepostaCriterio");

            migrationBuilder.RenameColumn(
                name: "EmpresaId",
                table: "Vaga",
                newName: "id_empresaid");

            migrationBuilder.RenameIndex(
                name: "IX_Vaga_EmpresaId",
                table: "Vaga",
                newName: "IX_Vaga_id_empresaid");

            migrationBuilder.RenameColumn(
                name: "Valor",
                table: "RepostaCriterio",
                newName: "int_valor");

            migrationBuilder.RenameColumn(
                name: "RespostaId",
                table: "RepostaCriterio",
                newName: "id_respostaid");

            migrationBuilder.RenameColumn(
                name: "DataUltimaAtualizacao",
                table: "RepostaCriterio",
                newName: "dt_atualizacao");

            migrationBuilder.RenameColumn(
                name: "DataCriacao",
                table: "RepostaCriterio",
                newName: "dt_criacao");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "RepostaCriterio",
                newName: "id_resp_crit");

            migrationBuilder.RenameIndex(
                name: "IX_RespostaCriterios_RespostaId",
                table: "RepostaCriterio",
                newName: "IX_RepostaCriterio_id_respostaid");

            migrationBuilder.AlterColumn<string>(
                name: "str_descricao",
                table: "Vaga",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "str_titulo",
                table: "Vaga",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "bl_pmd",
                table: "Criterio",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "int_peso",
                table: "Criterio",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "str_titulo",
                table: "Criterio",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "id_vagaid",
                table: "Criterio",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "id_criterioid",
                table: "RepostaCriterio",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_RepostaCriterio",
                table: "RepostaCriterio",
                column: "id_resp_crit");

            migrationBuilder.CreateIndex(
                name: "IX_Criterio_id_vagaid",
                table: "Criterio",
                column: "id_vagaid");

            migrationBuilder.CreateIndex(
                name: "IX_RepostaCriterio_id_criterioid",
                table: "RepostaCriterio",
                column: "id_criterioid");

            migrationBuilder.AddForeignKey(
                name: "FK_Criterio_Vaga_id_vagaid",
                table: "Criterio",
                column: "id_vagaid",
                principalTable: "Vaga",
                principalColumn: "id_vaga");

            migrationBuilder.AddForeignKey(
                name: "FK_RepostaCriterio_Criterio_id_criterioid",
                table: "RepostaCriterio",
                column: "id_criterioid",
                principalTable: "Criterio",
                principalColumn: "id_criterio",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RepostaCriterio_Resposta_id_respostaid",
                table: "RepostaCriterio",
                column: "id_respostaid",
                principalTable: "Resposta",
                principalColumn: "id_resposta");

            migrationBuilder.AddForeignKey(
                name: "FK_Vaga_Empresa_id_empresaid",
                table: "Vaga",
                column: "id_empresaid",
                principalTable: "Empresa",
                principalColumn: "id_empresa",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Criterio_Vaga_id_vagaid",
                table: "Criterio");

            migrationBuilder.DropForeignKey(
                name: "FK_RepostaCriterio_Criterio_id_criterioid",
                table: "RepostaCriterio");

            migrationBuilder.DropForeignKey(
                name: "FK_RepostaCriterio_Resposta_id_respostaid",
                table: "RepostaCriterio");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaga_Empresa_id_empresaid",
                table: "Vaga");

            migrationBuilder.DropIndex(
                name: "IX_Criterio_id_vagaid",
                table: "Criterio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RepostaCriterio",
                table: "RepostaCriterio");

            migrationBuilder.DropIndex(
                name: "IX_RepostaCriterio_id_criterioid",
                table: "RepostaCriterio");

            migrationBuilder.DropColumn(
                name: "str_titulo",
                table: "Vaga");

            migrationBuilder.DropColumn(
                name: "bl_pmd",
                table: "Criterio");

            migrationBuilder.DropColumn(
                name: "int_peso",
                table: "Criterio");

            migrationBuilder.DropColumn(
                name: "str_titulo",
                table: "Criterio");

            migrationBuilder.DropColumn(
                name: "id_vagaid",
                table: "Criterio");

            migrationBuilder.DropColumn(
                name: "id_criterioid",
                table: "RepostaCriterio");

            migrationBuilder.RenameTable(
                name: "RepostaCriterio",
                newName: "RespostaCriterios");

            migrationBuilder.RenameColumn(
                name: "id_empresaid",
                table: "Vaga",
                newName: "EmpresaId");

            migrationBuilder.RenameIndex(
                name: "IX_Vaga_id_empresaid",
                table: "Vaga",
                newName: "IX_Vaga_EmpresaId");

            migrationBuilder.RenameColumn(
                name: "int_valor",
                table: "RespostaCriterios",
                newName: "Valor");

            migrationBuilder.RenameColumn(
                name: "id_respostaid",
                table: "RespostaCriterios",
                newName: "RespostaId");

            migrationBuilder.RenameColumn(
                name: "dt_atualizacao",
                table: "RespostaCriterios",
                newName: "DataUltimaAtualizacao");

            migrationBuilder.RenameColumn(
                name: "dt_criacao",
                table: "RespostaCriterios",
                newName: "DataCriacao");

            migrationBuilder.RenameColumn(
                name: "id_resp_crit",
                table: "RespostaCriterios",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_RepostaCriterio_id_respostaid",
                table: "RespostaCriterios",
                newName: "IX_RespostaCriterios_RespostaId");

            migrationBuilder.AlterColumn<string>(
                name: "str_descricao",
                table: "Vaga",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "str_cargo",
                table: "Criterio",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "EmpresaId",
                table: "Criterio",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "VagaCriterioId",
                table: "RespostaCriterios",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_RespostaCriterios",
                table: "RespostaCriterios",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "VagaCriterio",
                columns: table => new
                {
                    id_vaga_criterio = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CriterioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    dt_criacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dt_atualizacao = table.Column<DateTime>(type: "datetime2", nullable: true),
                    int_pmd = table.Column<int>(type: "int", nullable: false),
                    str_pmd_desc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    int_peso = table.Column<int>(type: "int", nullable: false),
                    VagaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VagaCriterio", x => x.id_vaga_criterio);
                    table.ForeignKey(
                        name: "FK_VagaCriterio_Criterio_CriterioId",
                        column: x => x.CriterioId,
                        principalTable: "Criterio",
                        principalColumn: "id_criterio",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VagaCriterio_Vaga_VagaId",
                        column: x => x.VagaId,
                        principalTable: "Vaga",
                        principalColumn: "id_vaga",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Criterio_EmpresaId",
                table: "Criterio",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_RespostaCriterios_VagaCriterioId",
                table: "RespostaCriterios",
                column: "VagaCriterioId");

            migrationBuilder.CreateIndex(
                name: "IX_VagaCriterio_CriterioId",
                table: "VagaCriterio",
                column: "CriterioId");

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
                name: "FK_RespostaCriterios_Resposta_RespostaId",
                table: "RespostaCriterios",
                column: "RespostaId",
                principalTable: "Resposta",
                principalColumn: "id_resposta");

            migrationBuilder.AddForeignKey(
                name: "FK_RespostaCriterios_VagaCriterio_VagaCriterioId",
                table: "RespostaCriterios",
                column: "VagaCriterioId",
                principalTable: "VagaCriterio",
                principalColumn: "id_vaga_criterio",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vaga_Empresa_EmpresaId",
                table: "Vaga",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "id_empresa",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
