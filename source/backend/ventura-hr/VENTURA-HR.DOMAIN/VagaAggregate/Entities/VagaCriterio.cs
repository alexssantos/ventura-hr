using System;
using System.Collections.Generic;
using VENTURA_HR.DOMAIN.VagaAggregate.Enums;

namespace VENTURA_HR.DOMAIN.VagaAggregate.Entities
{
	public class VagaCriterio : Shared.Entity
	{

		public int Peso { get; set; }
		public EPerfilCriterio PMD { get; set; }
		public string PMDDescricao
		{
			get { return PMD.ToString(); }
			set { }
		}


		public Guid VagaId { get; set; }
		public virtual Vaga Vaga { get; set; }
		public Guid CriterioId { get; set; }
		public virtual Criterio Criterio { get; set; }


		public virtual IList<RespostaCriterio> RespostaCriterios { get; set; }
	}
}
