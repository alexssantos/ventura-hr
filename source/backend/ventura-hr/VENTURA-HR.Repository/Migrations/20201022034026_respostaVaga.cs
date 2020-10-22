using Microsoft.EntityFrameworkCore.Migrations;

namespace VENTURA_HR.Repository.Migrations
{
    public partial class respostaVaga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resposta_Vaga_vaga_id",
                table: "Resposta");

            migrationBuilder.RenameColumn(
                name: "vaga_id",
                table: "Resposta",
                newName: "id_vagaid");

            migrationBuilder.RenameIndex(
                name: "IX_Resposta_vaga_id",
                table: "Resposta",
                newName: "IX_Resposta_id_vagaid");

            migrationBuilder.AddForeignKey(
                name: "FK_Resposta_Vaga_id_vagaid",
                table: "Resposta",
                column: "id_vagaid",
                principalTable: "Vaga",
                principalColumn: "id_vaga");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resposta_Vaga_id_vagaid",
                table: "Resposta");

            migrationBuilder.RenameColumn(
                name: "id_vagaid",
                table: "Resposta",
                newName: "vaga_id");

            migrationBuilder.RenameIndex(
                name: "IX_Resposta_id_vagaid",
                table: "Resposta",
                newName: "IX_Resposta_vaga_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Resposta_Vaga_vaga_id",
                table: "Resposta",
                column: "vaga_id",
                principalTable: "Vaga",
                principalColumn: "id_vaga");
        }
    }
}
