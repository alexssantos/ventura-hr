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
			entity.HasOne(x => x.Usuario);

			entity.HasKey(x => x.Id);
			entity.Property(x => x.Id)
				.HasColumnName("id_candidato")
				.ValueGeneratedNever()
				.IsRequired();

			entity.Property(x => x.CPF)
				.HasColumnName("str_cpf")
				.IsRequired();
		}
	}
}
