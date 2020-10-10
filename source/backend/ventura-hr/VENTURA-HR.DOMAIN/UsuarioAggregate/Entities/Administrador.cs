using System;

namespace VENTURA_HR.DOMAIN.UsuarioAggregate.Entities
{
	public class Administrador : Shared.Entity
	{
		public string Segredo { get; set; }
		public Usuario Usuario { get; set; }
		public Guid UsuarioId { get; set; }
	}
}
