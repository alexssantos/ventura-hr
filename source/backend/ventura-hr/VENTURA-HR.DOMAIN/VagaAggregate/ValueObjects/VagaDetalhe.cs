using System;
using System.Collections.Generic;
using VENTURA_HR.DOMAIN.VagaAggregate.Entities;

namespace VENTURA_HR.DOMAIN.VagaAggregate.ValueObjects
{
	public class VagaDetalhe
	{
		public DateTime DataExpiracao { get; set; }
		public bool Finalizada { get; set; }
		public Guid EmpresaId { get; set; }
		public int TotalCandidatos { get; set; }
		public decimal PerfilMinimoDesejado { get; set; }

		public IList<Criterio> Criterios { get; set; }
		public IList<CandidatoRanqueado> Candidatos { get; set; }

	}

	public class CandidatoRanqueado
	{
		public Guid CandidatoId { get; set; }
		public decimal Pontuacao { get; set; }
		public string Nome { get; set; }
		public string Email { get; set; }
		public string Telefone { get; set; }
		public IList<ParValorCriterio> ParValorCriterio { get; set; }
	}

	public class ParValorCriterio
	{
		public int ValorReposta { get; set; }
		public Guid IdCriterio { get; set; }
	}
}
