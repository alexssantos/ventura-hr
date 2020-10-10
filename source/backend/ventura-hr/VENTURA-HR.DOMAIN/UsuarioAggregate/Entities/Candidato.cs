using System;

namespace VENTURA_HR.DOMAIN.UsuarioAggregate.Entities
{
	public class Candidato : Shared.Entity
	{
		public string CPF { get; set; }
		//public IList<Resposta> Respostas { get; set; }
		public Usuario Usuario { get; set; }
		public Guid UsuarioId { get; set; }
	}
}
