using System;

namespace VENTURA_HR.DOMAIN.VagaAggregate.Entities
{
	public class RespostaCriterio : Shared.Entity
	{
		public Guid RespostaId { get; set; }
		public virtual Resposta Resposta { get; set; }
		public Guid CritérioId { get; set; }
		public virtual Criterio Criterio { get; set; }
	}
}
