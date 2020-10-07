using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Entities;

namespace VENTURA_HT.Repository.MapEntities
{
	public class EmpresaMap : IEntityTypeConfiguration<Empresa>
	{
		public void Configure(EntityTypeBuilder<Empresa> builder)
		{
			builder.ToTable("Empresa");
		}
	}
}
