﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VENTURA_HT.Repository.Context;

namespace VENTURA_HR.Repository.Migrations
{
    [DbContext(typeof(VenturaContext))]
    [Migration("20201120210347_VagaFinalizada")]
    partial class VagaFinalizada
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VENTURA_HR.DOMAIN.UsuarioAggregate.Entities.Administrador", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataUltimaAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Segredo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Administradores");
                });

            modelBuilder.Entity("VENTURA_HR.DOMAIN.UsuarioAggregate.Entities.Candidato", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnName("id_candidato")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnName("str_cpf")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnName("dt_criacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataUltimaAtualizacao")
                        .HasColumnName("dt_atualizacao")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Candidato");
                });

            modelBuilder.Entity("VENTURA_HR.DOMAIN.UsuarioAggregate.Entities.Empresa", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnName("id_empresa")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnName("str_cnpj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnName("dt_criacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataUltimaAtualizacao")
                        .HasColumnName("dt_atualizacao")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("VENTURA_HR.DOMAIN.UsuarioAggregate.Entities.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnName("id_usuario")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnName("dt_criacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataNascimento")
                        .HasColumnName("dt_nascimento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataUltimaAtualizacao")
                        .HasColumnName("dt_atualizacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnName("str_email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnName("str_login")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnName("str_nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("str_password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TipoUsuario")
                        .HasColumnName("int_tipo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("VENTURA_HR.DOMAIN.VagaAggregate.Entities.Criterio", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnName("id_criterio")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Ativo")
                        .HasColumnName("bl_ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnName("dt_criacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataUltimaAtualizacao")
                        .HasColumnName("dt_atualizacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnName("str_desc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PMD")
                        .HasColumnName("bl_pmd")
                        .HasColumnType("int");

                    b.Property<int>("Peso")
                        .HasColumnName("int_peso")
                        .HasColumnType("int");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnName("str_titulo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("VagaId")
                        .HasColumnName("id_vagaid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("VagaId");

                    b.ToTable("Criterio");
                });

            modelBuilder.Entity("VENTURA_HR.DOMAIN.VagaAggregate.Entities.Resposta", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnName("id_resposta")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CandidatoId")
                        .HasColumnName("id_candidatoid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnName("dt_criacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataUltimaAtualizacao")
                        .HasColumnName("dt_atualizacao")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("VagaId")
                        .HasColumnName("id_vagaid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CandidatoId");

                    b.HasIndex("VagaId");

                    b.ToTable("Resposta");
                });

            modelBuilder.Entity("VENTURA_HR.DOMAIN.VagaAggregate.Entities.RespostaCriterio", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnName("id_resp_crit")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CriterioId")
                        .HasColumnName("id_criterioid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnName("dt_criacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataUltimaAtualizacao")
                        .HasColumnName("dt_atualizacao")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RespostaId")
                        .HasColumnName("id_respostaid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Valor")
                        .HasColumnName("int_valor")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CriterioId");

                    b.HasIndex("RespostaId");

                    b.ToTable("RepostaCriterio");
                });

            modelBuilder.Entity("VENTURA_HR.DOMAIN.VagaAggregate.Entities.Vaga", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnName("id_vaga")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnName("dt_criacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataExpiracao")
                        .HasColumnName("dt_expiracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DataUltimaAtualizacao")
                        .HasColumnName("dt_atualizacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .HasColumnName("str_descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("EmpresaId")
                        .HasColumnName("id_empresaid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Finalizada")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("bl_finalizada")
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnName("str_titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.ToTable("Vaga");
                });

            modelBuilder.Entity("VENTURA_HR.DOMAIN.UsuarioAggregate.Entities.Administrador", b =>
                {
                    b.HasOne("VENTURA_HR.DOMAIN.UsuarioAggregate.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VENTURA_HR.DOMAIN.UsuarioAggregate.Entities.Candidato", b =>
                {
                    b.HasOne("VENTURA_HR.DOMAIN.UsuarioAggregate.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VENTURA_HR.DOMAIN.UsuarioAggregate.Entities.Empresa", b =>
                {
                    b.HasOne("VENTURA_HR.DOMAIN.UsuarioAggregate.Entities.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("VENTURA_HR.DOMAIN.VagaAggregate.Entities.Criterio", b =>
                {
                    b.HasOne("VENTURA_HR.DOMAIN.VagaAggregate.Entities.Vaga", "Vaga")
                        .WithMany("Criterios")
                        .HasForeignKey("VagaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("VENTURA_HR.DOMAIN.VagaAggregate.Entities.Resposta", b =>
                {
                    b.HasOne("VENTURA_HR.DOMAIN.UsuarioAggregate.Entities.Candidato", "Candidato")
                        .WithMany("Respostas")
                        .HasForeignKey("CandidatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VENTURA_HR.DOMAIN.VagaAggregate.Entities.Vaga", "Vaga")
                        .WithMany("Respostas")
                        .HasForeignKey("VagaId")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("VENTURA_HR.DOMAIN.VagaAggregate.Entities.RespostaCriterio", b =>
                {
                    b.HasOne("VENTURA_HR.DOMAIN.VagaAggregate.Entities.Criterio", "Criterio")
                        .WithMany("RespostaCriterios")
                        .HasForeignKey("CriterioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VENTURA_HR.DOMAIN.VagaAggregate.Entities.Resposta", "Resposta")
                        .WithMany("RespostaCriterios")
                        .HasForeignKey("RespostaId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("VENTURA_HR.DOMAIN.VagaAggregate.Entities.Vaga", b =>
                {
                    b.HasOne("VENTURA_HR.DOMAIN.UsuarioAggregate.Entities.Empresa", "Empresa")
                        .WithMany("Vagas")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
