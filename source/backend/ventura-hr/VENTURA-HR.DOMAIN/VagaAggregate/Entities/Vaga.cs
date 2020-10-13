using System;
using System.Collections.Generic;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Entities;

namespace VENTURA_HR.DOMAIN.VagaAggregate.Entities
{
	public class Vaga : Shared.Entity
	{
		public string Descricao { get; set; }
		public Guid EmpresaId { get; set; }
		public Empresa Empresa { get; set; }
		public virtual IList<Criterio> Criterios { get; set; }
		public virtual IList<Resposta> Respostas { get; set; }

	}
}
