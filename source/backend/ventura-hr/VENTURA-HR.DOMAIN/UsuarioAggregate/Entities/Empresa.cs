using System;

namespace VENTURA_HR.DOMAIN.UsuarioAggregate.Entities
{
	public class Empresa : Shared.Entity
	{
		public string CNPJ { get; set; }
		//public IList<Vaga> Vagas { get; set; }
		public Usuario Usuario { get; set; }
		public Guid UsuarioId { get; set; }
	}
}
