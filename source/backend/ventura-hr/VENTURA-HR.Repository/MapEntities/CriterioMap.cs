using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VENTURA_HR.DOMAIN.VagaAggregate.Entities;

namespace VENTURA_HR.Repository.MapEntities
{
	public class CriterioMap : IEntityTypeConfiguration<Criterio>
	{
		public void Configure(EntityTypeBuilder<Criterio> entity)
		{
			entity.ToTable("Criterio");

			entity.HasKey(x => x.Id);
			entity.Property(x => x.Id)
				.HasColumnName("id_criterio")
				.ValueGeneratedNever()
				.IsRequired();

			entity.Property(x => x.Descricao)
				.HasColumnName("str_desc")
				.IsRequired();

			entity.Property(x => x.Valor)
				.HasColumnName("int_peso")
				.IsRequired();

			entity.Property(x => x.DataCriacao)
				.HasColumnName("dt_criacao")
				.IsRequired();

			entity.Property(x => x.DataUltimaAtualizacao)
				.HasColumnName("dt_atualizacao");

			// ==== relatoinsiops =====

			entity.HasMany(x => x.RespostaCriterios)
				.WithOne(x => x.Criterio)
				.HasForeignKey(x => x.CritérioId);
		}
	}
}
