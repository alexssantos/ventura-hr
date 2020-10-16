using Microsoft.EntityFrameworkCore;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Entities;
using VENTURA_HR.DOMAIN.VagaAggregate.Entities;
using VENTURA_HR.Repository.MapEntities;
using VENTURA_HT.Repository.MapEntities;

namespace VENTURA_HT.Repository.Context
{
	public class VenturaContext : DbContext
	{

		public VenturaContext(DbContextOptions<VenturaContext> options) : base(options)
		{
		}

		// fallback ctor for 'Design-time DbContext Creation'
		public VenturaContext()
		{
		}

		public DbSet<Usuario> Usuarios { get; set; }
		public DbSet<Candidato> Candidatos { get; set; }
		public DbSet<Empresa> Empresas { get; set; }
		public DbSet<Administrador> Administradores { get; set; }
		public DbSet<Vaga> Vagas { get; set; }
		public DbSet<Resposta> Respostas { get; set; }
		public DbSet<Criterio> Criterios { get; set; }
		public DbSet<RespostaCriterio> RespostaCriterios { get; set; }


		/* Mapping ways to inheranced entities (3):
		 * 
		 *	WARNING: only TPH supported for EFCore v3.x: https://docs.microsoft.com/en-us/ef/efcore-and-ef6/
		 *	
		 * 1. Table per Hierarchy (TPH) (https://entityframeworkcore.com/model-inheritance)
		 *		* An entire class hierarchy can be mapped to a single table.
		 *		* The table includes columns for all properties of all classes in the hierarchy.
		 *		* The concrete subclass represented by a particular row is identified by the value of a type discriminator column.
		 *		
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
		 * last update: 16/10/20
		 */
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new UsuarioMap());
			modelBuilder.ApplyConfiguration(new EmpresaMap());
			modelBuilder.ApplyConfiguration(new CandidatoMap());
			modelBuilder.ApplyConfiguration(new RespostaMap());
			modelBuilder.ApplyConfiguration(new VagaMap());
			modelBuilder.ApplyConfiguration(new CriterioMap());


			base.OnModelCreating(modelBuilder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{

			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Server=KONOHA; Database=ventura_hr; User Id=sa; password=n4rut0uzum4k1; MultipleActiveResultSets=true");
			}

			base.OnConfiguring(optionsBuilder);
		}
	}
}
