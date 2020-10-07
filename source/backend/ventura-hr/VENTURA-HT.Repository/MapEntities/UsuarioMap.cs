using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Entities;

namespace VENTURA_HT.Repository.MapEntities
{
	public class UsuarioMap : IEntityTypeConfiguration<Usuario>
	{
		public void Configure(EntityTypeBuilder<Usuario> builder)
		{
			builder.ToTable("Usuario");
			builder.HasKey(x => x.Id);
			builder.Property(x => x.Id).ValueGeneratedNever().IsRequired();

			builder.Property(x => x.Login).IsRequired();
			builder.Property(x => x.Password).IsRequired();
			builder.Property(x => x.Email).IsRequired();
			builder.Property(x => x.Nome).IsRequired();
			builder.Property(x => x.BirthDate).IsRequired();
		}
	}
}
