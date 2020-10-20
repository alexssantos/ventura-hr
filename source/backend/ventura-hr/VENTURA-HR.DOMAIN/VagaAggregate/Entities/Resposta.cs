using System;
using System.Collections.Generic;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Entities;

namespace VENTURA_HR.DOMAIN.VagaAggregate.Entities
{
	public class Resposta : Shared.Entity
	{

		public Guid? VagaId { get; set; }
		public Guid CandidatoId { get; set; }


		public Vaga Vaga { get; set; }
		public Candidato Candidato { get; set; }

		public virtual IList<RespostaCriterio> RespostaCriterios { get; set; }
	}
}
