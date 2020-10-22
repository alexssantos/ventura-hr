using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace VENTURA_HR.Services.Dtos.Requests
{
	[DataContract]
	public class PublicarRespostaRequest
	{
		[DataMember(Name = "criterios")]
		public List<PairResposta> Criterios { get; set; }

		[DataMember(Name = "observacao")]
		public string Observacao { get; set; }

		[DataContract]
		public partial class PairResposta
		{
			[DataMember(Name = "criterioId")]
			public Guid CriterioId { get; set; }

			[DataMember(Name = "valor")]
			public int Valor { get; set; }
		}
	}
}
