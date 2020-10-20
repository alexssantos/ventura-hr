/* Agregada o contexto de vaga.
 * Os criterios são relacionados a vaga e pertencem a uma empresa.
 * 
 * Default: Não existem default. Precisam ser criados novos ao iniciar.
 * 
 * Salvar: Entidade salva ao inserir nova vaga com criterio
 * Buscar: Pegar através do endpoint de vaga
 * ditar: editado ao buscar e editar a descrição passando criterioID.
 */

using System;
using System.Collections.Generic;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Entities;

namespace VENTURA_HR.DOMAIN.VagaAggregate.Entities
{
	public class Criterio : Shared.Entity
	{
		public string Cargo { get; set; }

		public string Descricao { get; set; }

		public bool Ativo { get; set; }


		public Guid EmpresaId { get; set; }
		public virtual Empresa Empresa { get; set; }

		public virtual IList<VagaCriterio> VagaCriterios { get; set; }
	}
}
