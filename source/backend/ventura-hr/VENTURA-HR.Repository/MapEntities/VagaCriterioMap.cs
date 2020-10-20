using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VENTURA_HR.DOMAIN.VagaAggregate.Entities;

namespace VENTURA_HR.Repository.MapEntities
{
	public class VagaCriterioMap : IEntityTypeConfiguration<VagaCriterio>
	{
		public void Configure(EntityTypeBuilder<VagaCriterio> entity)
		{
			entity.ToTable("VagaCriterio");

			entity.HasKey(x => x.Id);
			entity.Property(x => x.Id)
				.HasColumnName("id_vaga_criterio")
				.ValueGeneratedNever()
				.IsRequired();

			entity.Property(x => x.Peso)
				.HasColumnName("int_peso")
				.IsRequired();

			entity.Property(x => x.PMD)
				.HasColumnName("int_pmd")
				.IsRequired();

			entity.Property(x => x.PMDDescricao)
				.HasColumnName("str_pmd_desc")
				.IsRequired();


			// ==== aditamento =====

			entity.Property(x => x.DataCriacao)
				.HasColumnName("dt_criacao")
				.IsRequired();

			entity.Property(x => x.DataUltimaAtualizacao)
				.HasColumnName("dt_atualizacao");

			// ==== relatoinsiops =====


			// ==== Keys =====

			entity.HasIndex(p => new { p.VagaId, p.CriterioId })
				.IsUnique();
		}
	}
}
