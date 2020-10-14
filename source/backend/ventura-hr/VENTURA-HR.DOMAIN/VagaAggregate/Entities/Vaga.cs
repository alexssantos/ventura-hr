using System;
using System.Collections.Generic;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Entities;

namespace VENTURA_HR.DOMAIN.VagaAggregate.Entities
{
	public class Vaga : Shared.Entity
	{
		public string Descricao { get; set; }

		public DateTime DataExpiracao
		{
			get
			{
				return this._dataExpiracao.HasValue
				   ? this._dataExpiracao.Value
				   : this.DataCriacao.AddDays(Vaga.DEFAULT_EXPIRE_DAYS_AMOUNT);
			}

			set { this._dataExpiracao = value; }
		}

		private DateTime? _dataExpiracao { get; set; }

		public Guid EmpresaId { get; set; }

		public Empresa Empresa { get; set; }

		public virtual IList<Criterio> Criterios { get; set; }

		public virtual IList<Resposta> Respostas { get; set; }

		public static readonly int DEFAULT_EXPIRE_DAYS_AMOUNT = 4;
	}
}
