using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VENTURA_HR.DOMAIN.VagaAggregate.Entities;

namespace VENTURA_HR.Repository.MapEntities
{
	public class RespostaCriterioMap : IEntityTypeConfiguration<RespostaCriterio>
	{
		public void Configure(EntityTypeBuilder<RespostaCriterio> entity)
		{
			entity.ToTable("RepostaCriterio");

			entity.HasKey(x => x.Id);
			entity.Property(x => x.Id)
				.HasColumnName("id_resp_crit")
				.ValueGeneratedNever()
				.IsRequired();

			entity.Property(x => x.Valor)
				.HasColumnName("int_valor")
				.IsRequired();

			entity.Property(x => x.CriterioId)
				.HasColumnName("id_criterioid")
				.IsRequired();

			entity.Property(x => x.RespostaId)
				.HasColumnName("id_respostaid")
				.IsRequired();

			// === aditamento ===

			entity.Property(x => x.DataCriacao)
				.HasColumnName("dt_criacao")
				.IsRequired();

			entity.Property(x => x.DataUltimaAtualizacao)
				.HasColumnName("dt_atualizacao");
		}
	}
}
