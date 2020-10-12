using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VENTURA_HR.DOMAIN.VagaAggregate.Entities;

namespace VENTURA_HR.Repository.MapEntities
{
	public class RespostaMap : IEntityTypeConfiguration<Resposta>
	{
		public void Configure(EntityTypeBuilder<Resposta> entity)
		{
			entity.ToTable("Resposta");

			entity.HasKey(x => x.Id);
			entity.Property(x => x.Id)
				.HasColumnName("id_resposta")
				.ValueGeneratedNever()
				.IsRequired();

			entity.Property(x => x.NovoCampoTesteMigration)
				.HasColumnName("str_campo_teste")
				.IsRequired();


			// ==== relationships =====

			entity.HasMany(x => x.RespostaCriterios)
				.WithOne(x => x.Resposta)
				.HasForeignKey(x => x.RespostaId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
