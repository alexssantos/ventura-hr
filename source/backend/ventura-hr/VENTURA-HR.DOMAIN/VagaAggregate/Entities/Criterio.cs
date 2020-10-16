/* Agregada o contexto de vaga.
 * Os criterios são relacionados a vaga e pertencem a uma empresa.
 * 
 * Default: Não existem default. Precisam ser criados novos ao iniciar.
 * 
 * Salvar: Entidade salva ao inserir nova vaga com criterio
 * Buscar: Pegar através do endpoint de vaga
 * ditar: editado ao buscar e editar a descrição passando criterioID.
 */

using System.Collections.Generic;
using VENTURA_HR.DOMAIN.VagaAggregate.Enums;

namespace VENTURA_HR.DOMAIN.VagaAggregate.Entities
{
	public class Criterio : Shared.Entity
	{
		public ECriterioPeso Peso { get; set; }
		public string PesoDescricao
		{
			get { return Peso.ToString(); }
			set { }
		}

		public string Titulo { get; set; }

		public virtual IList<RespostaCriterio> RespostaCriterios { get; set; }
	}
}
