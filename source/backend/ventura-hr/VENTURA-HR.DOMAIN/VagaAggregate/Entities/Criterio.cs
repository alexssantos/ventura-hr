/* Validar valores do Enum no banco ao inicial aplicação
 * 
 */

using System.Collections.Generic;
using VENTURA_HR.DOMAIN.VagaAggregate.Enums;

namespace VENTURA_HR.DOMAIN.VagaAggregate.Entities
{
	public class Criterio : Shared.Entity
	{
		public ECriterioPeso Valor { get; set; }
		public string Descricao
		{
			get { return Valor.ToString(); }
			set { }
		}
		public virtual IList<RespostaCriterio> RespostaCriterios { get; set; }
	}
}
