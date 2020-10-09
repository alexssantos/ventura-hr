using System.Collections.Generic;
using VENTURA_HR.DOMAIN.VagaAggregate.Entities;

namespace VENTURA_HR.DOMAIN.UsuarioAggregate.Entities
{
	public class Candidato : Usuario
	{
		public string CPF { get; set; }
		public IList<Resposta> Respostas { get; set; }
	}
}
