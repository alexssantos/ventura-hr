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



		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new UsuarioMap());
			modelBuilder.ApplyConfiguration(new CandidatoMap());
			modelBuilder.ApplyConfiguration(new EmpresaMap());


			// Mapping the Table-Per-Type (TPT) Inheritance
			//modelBuilder.Entity<Empresa>().ToTable("Empresa");


			base.OnModelCreating(modelBuilder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
		}
	}
}
