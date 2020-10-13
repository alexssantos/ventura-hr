using System;
using System.Collections.Generic;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Entities;

namespace VENTURA_HR.DOMAIN.VagaAggregate.Entities
{
	public class Resposta : Shared.Entity
	{
		public virtual IList<RespostaCriterio> RespostaCriterios { get; set; }
		public Guid? VagaId { get; set; }
		public Vaga Vaga { get; set; }
		public Guid CandidatoId { get; set; }
		public Candidato Candidato { get; set; }
		public string NovoCampoTesteMigration { get; set; }
	}
}
