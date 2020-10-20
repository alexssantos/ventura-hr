using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VENTURA_HR.DOMAIN.VagaAggregate.Entities;

namespace VENTURA_HR.Repository.MapEntities
{
	public class VagaMap : IEntityTypeConfiguration<Vaga>
	{
		public void Configure(EntityTypeBuilder<Vaga> entity)
		{
			entity.ToTable("Vaga");


			entity.HasKey(x => x.Id);
			entity.Property(x => x.Id)
				.HasColumnName("id_vaga")
				.ValueGeneratedNever()
				.IsRequired();

			entity.Property(x => x.Descricao)
				.HasColumnName("str_descricao")
				.IsRequired();

			entity.Property(x => x.DataExpiracao)
				.HasColumnName("dt_expiracao")
				.IsRequired();


			//====== Aditamento ======

			entity.Property(x => x.DataCriacao)
				.HasColumnName("dt_criacao")
				.IsRequired();

			entity.Property(x => x.DataUltimaAtualizacao)
				.HasColumnName("dt_atualizacao");



			//====== REALATONSHIPS ======

			entity.HasMany(x => x.Respostas)
				.WithOne(x => x.Vaga)
				.HasForeignKey(x => x.VagaId)
				.OnDelete(DeleteBehavior.NoAction);

			entity.HasMany(x => x.VagaCriterios)
				.WithOne(x => x.Vaga)
				.HasForeignKey(x => x.VagaId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}
