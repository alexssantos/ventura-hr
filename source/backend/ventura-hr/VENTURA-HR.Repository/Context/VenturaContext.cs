using Microsoft.EntityFrameworkCore;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Entities;
using VENTURA_HT.Repository.MapEntities;

namespace VENTURA_HT.Repository.Context
{
	public class VenturaContext : DbContext
	{

		public VenturaContext(DbContextOptions<VenturaContext> options) : base(options)
		{

		}

		public DbSet<Usuario> Usuarios { get; set; }
		public DbSet<Candidato> Candidatos { get; set; }
		public DbSet<Empresa> Empresas { get; set; }
		public DbSet<Administrador> Administradores { get; set; }



		/* Mapping ways to inheranced entities:
		 *	WARNING: only TPH supported for EFCore v3.x: https://docs.microsoft.com/en-us/ef/efcore-and-ef6/
		 *	
		 * 1. Table per Hierarchy (TPH) (https://entityframeworkcore.com/model-inheritance)
		 *		* An entire class hierarchy can be mapped to a single table.
		 *		* The table includes columns for all properties of all classes in the hierarchy.
		 *		* The concrete subclass represented by a particular row is identified by the value of a type discriminator column.
		 *		
		 * 2. Table per Concrete (TPC)
		 *		* 
		 *		*
		 *	
		 *	
		 * WARNNING: plna to be included on EFCore 5.x . 		
		 *		https://docs.microsoft.com/pt-br/ef/core/what-is-new/ef-core-5.0/plan#table-per-type-tpt-inheritance-mapping
		 * 3. Table per Type (TPT)
		 *		*
		 *		*
		 *		*
		 * 
		 */
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new UsuarioMap());
			modelBuilder.ApplyConfiguration(new EmpresaMap());
			modelBuilder.ApplyConfiguration(new CandidatoMap());

			base.OnModelCreating(modelBuilder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
		}
	}
}
