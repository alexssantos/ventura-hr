using Microsoft.EntityFrameworkCore.Migrations;

namespace VENTURA_HR.Repository.Migrations
{
    public partial class updateVaga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Vaga",
                newName: "str_descricao");

            migrationBuilder.AlterColumn<string>(
                name: "str_descricao",
                table: "Vaga",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "str_descricao",
                table: "Vaga",
                newName: "Descricao");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Vaga",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
