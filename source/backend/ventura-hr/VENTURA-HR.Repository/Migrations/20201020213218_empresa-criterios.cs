using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VENTURA_HR.Repository.Migrations
{
    public partial class empresacriterios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EmpresaId",
                table: "Criterio",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Criterio_EmpresaId",
                table: "Criterio",
                column: "EmpresaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Criterio_Empresa_EmpresaId",
                table: "Criterio",
                column: "EmpresaId",
                principalTable: "Empresa",
                principalColumn: "id_empresa",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Criterio_Empresa_EmpresaId",
                table: "Criterio");

            migrationBuilder.DropIndex(
                name: "IX_Criterio_EmpresaId",
                table: "Criterio");

            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Criterio");
        }
    }
}
