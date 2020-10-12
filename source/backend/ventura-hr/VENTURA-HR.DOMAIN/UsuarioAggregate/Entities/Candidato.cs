using System;
using System.Collections.Generic;
using VENTURA_HR.DOMAIN.VagaAggregate.Entities;

namespace VENTURA_HR.DOMAIN.UsuarioAggregate.Entities
{
	public class Candidato : Shared.Entity
	{
		public string CPF { get; set; }
		public Usuario Usuario { get; set; }
		public Guid UsuarioId { get; set; }
		public virtual IList<Resposta> Respostas { get; set; }
	}
}
