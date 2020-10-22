using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VENTURA_HR.Repository.Migrations
{
    public partial class VagaCriterio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Criterio_Vaga_VagaId",
                table: "Criterio");

            migrationBuilder.DropForeignKey(
                name: "FK_RespostaCriterios_Criterio_CritérioId",
                table: "RespostaCriterios");

            migrationBuilder.DropIndex(
                name: "IX_RespostaCriterios_CritérioId",
                table: "RespostaCriterios");

            migrationBuilder.DropIndex(
                name: "IX_Criterio_VagaId",
                table: "Criterio");

            migrationBuilder.DropColumn(
                name: "CritérioId",
                table: "RespostaCriterios");

            migrationBuilder.DropColumn(
                name: "str_campo_teste",
                table: "Resposta");

            migrationBuilder.DropColumn(
                name: "int_peso",
                table: "Criterio");

            migrationBuilder.DropColumn(
                name: "str_titulo",
                table: "Criterio");

            migrationBuilder.DropColumn(
                name: "VagaId",
                table: "Criterio");

            migrationBuilder.AddColumn<Guid>(
                name: "VagaCriterioId",
                table: "RespostaCriterios",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Valor",
                table: "RespostaCriterios",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "bl_ativo",
                table: "Criterio",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "str_cargo",
                table: "Criterio",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "VagaCriterios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false),
                    DataUltimaAtualizacao = table.Column<DateTime>(nullable: true),
                    Peso = table.Column<int>(nullable: false),
                    PMD = table.Column<int>(nullable: false),
                    PMDDescricao = table.Column<string>(nullable: true),
                    VagaId = table.Column<Guid>(nullable: false),
                    CriterioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VagaCriterios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VagaCriterios_Criterio_CriterioId",
                        column: x => x.CriterioId,
                        principalTable: "Criterio",
                        principalColumn: "id_criterio",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VagaCriterios_Vaga_VagaId",
                        column: x => x.VagaId,
                        principalTable: "Vaga",
                        principalColumn: "id_vaga",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RespostaCriterios_VagaCriterioId",
                table: "RespostaCriterios",
                column: "VagaCriterioId");

            migrationBuilder.CreateIndex(
                name: "IX_VagaCriterios_CriterioId",
                table: "VagaCriterios",
                column: "CriterioId");

            migrationBuilder.CreateIndex(
                name: "IX_VagaCriterios_VagaId",
                table: "VagaCriterios",
                column: "VagaId");

            migrationBuilder.AddForeignKey(
                name: "FK_RespostaCriterios_VagaCriterios_VagaCriterioId",
                table: "RespostaCriterios",
                column: "VagaCriterioId",
                principalTable: "VagaCriterios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RespostaCriterios_VagaCriterios_VagaCriterioId",
                table: "RespostaCriterios");

            migrationBuilder.DropTable(
                name: "VagaCriterios");

            migrationBuilder.DropIndex(
                name: "IX_RespostaCriterios_VagaCriterioId",
                table: "RespostaCriterios");

            migrationBuilder.DropColumn(
                name: "VagaCriterioId",
                table: "RespostaCriterios");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "RespostaCriterios");

            migrationBuilder.DropColumn(
                name: "bl_ativo",
                table: "Criterio");

            migrationBuilder.DropColumn(
                name: "str_cargo",
                table: "Criterio");

            migrationBuilder.AddColumn<Guid>(
                name: "CritérioId",
                table: "RespostaCriterios",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "str_campo_teste",
                table: "Resposta",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "int_peso",
                table: "Criterio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "str_titulo",
                table: "Criterio",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "VagaId",
                table: "Criterio",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RespostaCriterios_CritérioId",
                table: "RespostaCriterios",
                column: "CritérioId");

            migrationBuilder.CreateIndex(
                name: "IX_Criterio_VagaId",
                table: "Criterio",
                column: "VagaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Criterio_Vaga_VagaId",
                table: "Criterio",
                column: "VagaId",
                principalTable: "Vaga",
                principalColumn: "id_vaga",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RespostaCriterios_Criterio_CritérioId",
                table: "RespostaCriterios",
                column: "CritérioId",
                principalTable: "Criterio",
                principalColumn: "id_criterio",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
