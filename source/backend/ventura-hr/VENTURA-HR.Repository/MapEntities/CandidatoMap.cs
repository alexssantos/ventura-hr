using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Entities;

namespace VENTURA_HT.Repository.MapEntities
{
	public class CandidatoMap : IEntityTypeConfiguration<Candidato>
	{
		public void Configure(EntityTypeBuilder<Candidato> entity)
		{
			entity.ToTable("Candidato");

			entity.HasKey(x => x.Id);
			entity.Property(x => x.Id)
				.HasColumnName("id_candidato")
				.ValueGeneratedNever()
				.IsRequired();

			entity.Property(x => x.CPF)
				.HasColumnName("str_cpf")
				.IsRequired();

			entity.Property(x => x.DataCriacao)
				.HasColumnName("dt_criacao")
				.IsRequired();

			entity.Property(x => x.DataUltimaAtualizacao)
				.HasColumnName("dt_atualizacao");


			// ==== relatoinsiops =====

			entity.HasOne(x => x.Usuario);

			entity.HasMany(x => x.Respostas)
				.WithOne(x => x.Candidato)
				.HasForeignKey(x => x.CandidatoId);
		}
	}
}
