using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Entities;

namespace VENTURA_HT.Repository.MapEntities
{
	public class EmpresaMap : IEntityTypeConfiguration<Empresa>
	{
		public void Configure(EntityTypeBuilder<Empresa> entity)
		{
			entity.ToTable("Empresa");

			entity.HasKey(x => x.Id);
			entity.Property(x => x.Id)
				.HasColumnName("id_empresa")
				.ValueGeneratedNever()
				.IsRequired();

			entity.Property(x => x.CNPJ)
				.HasColumnName("str_cnpj")
				.IsRequired();

			entity.Property(x => x.DataCriacao)
				.HasColumnName("dt_criacao")
				.IsRequired();

			entity.Property(x => x.DataUltimaAtualizacao)
				.HasColumnName("dt_atualizacao");

			// ==== relationshiop ====

			entity.HasOne(x => x.Usuario);

			entity.HasMany(x => x.Vagas)
				.WithOne(x => x.Empresa)
				.HasForeignKey(x => x.EmpresaId);
		}
	}
}
