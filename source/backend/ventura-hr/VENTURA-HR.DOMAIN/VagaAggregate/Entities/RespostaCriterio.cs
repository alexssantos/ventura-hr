/* save: usando a mesma instancia do DbContext - Connected state update
 * https://www.thereformedprogrammer.net/updating-many-to-many-relationships-in-entity-framework-core/
 * 
 */

using System;

namespace VENTURA_HR.DOMAIN.VagaAggregate.Entities
{
	public class RespostaCriterio : Shared.Entity
	{
		public int Valor { get; set; }
		public Guid RespostaId { get; set; }
		public Guid VagaCriterioId { get; set; }


		public virtual Resposta Resposta { get; set; }
		public virtual VagaCriterio VagaCriterio { get; set; }
	}
}
