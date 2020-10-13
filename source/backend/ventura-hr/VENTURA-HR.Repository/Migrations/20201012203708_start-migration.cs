using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VENTURA_HR.Repository.Migrations
{
    public partial class startmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id_usuario = table.Column<Guid>(nullable: false),
                    str_login = table.Column<string>(nullable: false),
                    str_password = table.Column<string>(nullable: false),
                    str_email = table.Column<string>(nullable: false),
                    str_nome = table.Column<string>(nullable: false),
                    dt_nascimento = table.Column<DateTime>(nullable: false),
                    int_tipo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.id_usuario);
                });

            migrationBuilder.CreateTable(
                name: "Administradores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Segredo = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Administradores_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Candidato",
                columns: table => new
                {
                    id_candidato = table.Column<Guid>(nullable: false),
                    str_cpf = table.Column<string>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidato", x => x.id_candidato);
                    table.ForeignKey(
                        name: "FK_Candidato_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    id_empresa = table.Column<Guid>(nullable: false),
                    str_cnpj = table.Column<string>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.id_empresa);
                    table.ForeignKey(
                        name: "FK_Empresa_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vaga",
                columns: table => new
                {
                    id_vaga = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    EmpresaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vaga", x => x.id_vaga);
                    table.ForeignKey(
                        name: "FK_Vaga_Empresa_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresa",
                        principalColumn: "id_empresa",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Criterio",
                columns: table => new
                {
                    id_criterio = table.Column<Guid>(nullable: false),
                    int_peso = table.Column<int>(nullable: false),
                    str_desc = table.Column<string>(nullable: false),
                    VagaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Criterio", x => x.id_criterio);
                    table.ForeignKey(
                        name: "FK_Criterio_Vaga_VagaId",
                        column: x => x.VagaId,
                        principalTable: "Vaga",
                        principalColumn: "id_vaga",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Resposta",
                columns: table => new
                {
                    id_resposta = table.Column<Guid>(nullable: false),
                    VagaId = table.Column<Guid>(nullable: true),
                    CandidatoId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resposta", x => x.id_resposta);
                    table.ForeignKey(
                        name: "FK_Resposta_Candidato_CandidatoId",
                        column: x => x.CandidatoId,
                        principalTable: "Candidato",
                        principalColumn: "id_candidato",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Resposta_Vaga_VagaId",
                        column: x => x.VagaId,
                        principalTable: "Vaga",
                        principalColumn: "id_vaga");
                });

            migrationBuilder.CreateTable(
                name: "RespostaCriterio",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RespostaId = table.Column<Guid>(nullable: false),
                    CritérioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespostaCriterio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RespostaCriterio_Criterio_CritérioId",
                        column: x => x.CritérioId,
                        principalTable: "Criterio",
                        principalColumn: "id_criterio",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RespostaCriterio_Resposta_RespostaId",
                        column: x => x.RespostaId,
                        principalTable: "Resposta",
                        principalColumn: "id_resposta",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administradores_UsuarioId",
                table: "Administradores",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Candidato_UsuarioId",
                table: "Candidato",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Criterio_VagaId",
                table: "Criterio",
                column: "VagaId");

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_UsuarioId",
                table: "Empresa",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Resposta_CandidatoId",
                table: "Resposta",
                column: "CandidatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Resposta_VagaId",
                table: "Resposta",
                column: "VagaId");

            migrationBuilder.CreateIndex(
                name: "IX_RespostaCriterio_CritérioId",
                table: "RespostaCriterio",
                column: "CritérioId");

            migrationBuilder.CreateIndex(
                name: "IX_RespostaCriterio_RespostaId",
                table: "RespostaCriterio",
                column: "RespostaId");

            migrationBuilder.CreateIndex(
                name: "IX_Vaga_EmpresaId",
                table: "Vaga",
                column: "EmpresaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administradores");

            migrationBuilder.DropTable(
                name: "RespostaCriterio");

            migrationBuilder.DropTable(
                name: "Criterio");

            migrationBuilder.DropTable(
                name: "Resposta");

            migrationBuilder.DropTable(
                name: "Candidato");

            migrationBuilder.DropTable(
                name: "Vaga");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
