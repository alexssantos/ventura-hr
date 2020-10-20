using Microsoft.EntityFrameworkCore.Migrations;

namespace VENTURA_HR.Repository.Migrations
{
    public partial class empresacriterios4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RespostaCriterios_Resposta_RespostaId",
                table: "RespostaCriterios");

            migrationBuilder.AddForeignKey(
                name: "FK_RespostaCriterios_Resposta_RespostaId",
                table: "RespostaCriterios",
                column: "RespostaId",
                principalTable: "Resposta",
                principalColumn: "id_resposta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RespostaCriterios_Resposta_RespostaId",
                table: "RespostaCriterios");

            migrationBuilder.AddForeignKey(
                name: "FK_RespostaCriterios_Resposta_RespostaId",
                table: "RespostaCriterios",
                column: "RespostaId",
                principalTable: "Resposta",
                principalColumn: "id_resposta",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
