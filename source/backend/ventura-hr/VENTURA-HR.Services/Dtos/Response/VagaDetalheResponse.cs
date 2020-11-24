using System;
using VENTURA_HR.DOMAIN.VagaAggregate.Entities;

namespace VENTURA_HR.Services.Dtos.Response
{
	public class VagaDetalheResponse
	{
		public Vaga Vaga { get; set; }
		public partial class CandidatoRanqueado
		{
			public Guid CandidatoId { get; set; }
			public decimal Pontuacao { get; set; }
			public string Nome { get; set; }
			public string Email { get; set; }
			public string Telefone { get; set; }
		}
	}
}
