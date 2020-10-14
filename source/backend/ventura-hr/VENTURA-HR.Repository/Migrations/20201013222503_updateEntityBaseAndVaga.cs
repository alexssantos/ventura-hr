using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VENTURA_HR.Repository.Migrations
{
    public partial class updateEntityBaseAndVaga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RespostaCriterio_Criterio_CritérioId",
                table: "RespostaCriterio");

            migrationBuilder.DropForeignKey(
                name: "FK_RespostaCriterio_Resposta_RespostaId",
                table: "RespostaCriterio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RespostaCriterio",
                table: "RespostaCriterio");

            migrationBuilder.RenameTable(
                name: "RespostaCriterio",
                newName: "RespostaCriterios");

            migrationBuilder.RenameIndex(
                name: "IX_RespostaCriterio_RespostaId",
                table: "RespostaCriterios",
                newName: "IX_RespostaCriterios_RespostaId");

            migrationBuilder.RenameIndex(
                name: "IX_RespostaCriterio_CritérioId",
                table: "RespostaCriterios",
                newName: "IX_RespostaCriterios_CritérioId");

            migrationBuilder.AddColumn<DateTime>(
                name: "dt_criacao",
                table: "Vaga",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dt_expiracao",
                table: "Vaga",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dt_atualizacao",
                table: "Vaga",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dt_criacao",
                table: "Usuario",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dt_atualizacao",
                table: "Usuario",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dt_criacao",
                table: "Resposta",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dt_atualizacao",
                table: "Resposta",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "str_campo_teste",
                table: "Resposta",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "dt_criacao",
                table: "Empresa",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dt_atualizacao",
                table: "Empresa",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dt_criacao",
                table: "Criterio",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dt_atualizacao",
                table: "Criterio",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dt_criacao",
                table: "Candidato",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "dt_atualizacao",
                table: "Candidato",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "Administradores",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataUltimaAtualizacao",
                table: "Administradores",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataCriacao",
                table: "RespostaCriterios",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataUltimaAtualizacao",
                table: "RespostaCriterios",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_RespostaCriterios",
                table: "RespostaCriterios",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RespostaCriterios_Criterio_CritérioId",
                table: "RespostaCriterios",
                column: "CritérioId",
                principalTable: "Criterio",
                principalColumn: "id_criterio",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RespostaCriterios_Resposta_RespostaId",
                table: "RespostaCriterios",
                column: "RespostaId",
                principalTable: "Resposta",
                principalColumn: "id_resposta",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RespostaCriterios_Criterio_CritérioId",
                table: "RespostaCriterios");

            migrationBuilder.DropForeignKey(
                name: "FK_RespostaCriterios_Resposta_RespostaId",
                table: "RespostaCriterios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RespostaCriterios",
                table: "RespostaCriterios");

            migrationBuilder.DropColumn(
                name: "dt_criacao",
                table: "Vaga");

            migrationBuilder.DropColumn(
                name: "dt_expiracao",
                table: "Vaga");

            migrationBuilder.DropColumn(
                name: "dt_atualizacao",
                table: "Vaga");

            migrationBuilder.DropColumn(
                name: "dt_criacao",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "dt_atualizacao",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "dt_criacao",
                table: "Resposta");

            migrationBuilder.DropColumn(
                name: "dt_atualizacao",
                table: "Resposta");

            migrationBuilder.DropColumn(
                name: "str_campo_teste",
                table: "Resposta");

            migrationBuilder.DropColumn(
                name: "dt_criacao",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "dt_atualizacao",
                table: "Empresa");

            migrationBuilder.DropColumn(
                name: "dt_criacao",
                table: "Criterio");

            migrationBuilder.DropColumn(
                name: "dt_atualizacao",
                table: "Criterio");

            migrationBuilder.DropColumn(
                name: "dt_criacao",
                table: "Candidato");

            migrationBuilder.DropColumn(
                name: "dt_atualizacao",
                table: "Candidato");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "Administradores");

            migrationBuilder.DropColumn(
                name: "DataUltimaAtualizacao",
                table: "Administradores");

            migrationBuilder.DropColumn(
                name: "DataCriacao",
                table: "RespostaCriterios");

            migrationBuilder.DropColumn(
                name: "DataUltimaAtualizacao",
                table: "RespostaCriterios");

            migrationBuilder.RenameTable(
                name: "RespostaCriterios",
                newName: "RespostaCriterio");

            migrationBuilder.RenameIndex(
                name: "IX_RespostaCriterios_RespostaId",
                table: "RespostaCriterio",
                newName: "IX_RespostaCriterio_RespostaId");

            migrationBuilder.RenameIndex(
                name: "IX_RespostaCriterios_CritérioId",
                table: "RespostaCriterio",
                newName: "IX_RespostaCriterio_CritérioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RespostaCriterio",
                table: "RespostaCriterio",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RespostaCriterio_Criterio_CritérioId",
                table: "RespostaCriterio",
                column: "CritérioId",
                principalTable: "Criterio",
                principalColumn: "id_criterio",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RespostaCriterio_Resposta_RespostaId",
                table: "RespostaCriterio",
                column: "RespostaId",
                principalTable: "Resposta",
                principalColumn: "id_resposta",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
