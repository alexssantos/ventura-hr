using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using VENTURA_HR.DOMAIN.VagaAggregate.Entities;

namespace VENTURA_HR.Services.Dtos.Requests
{
	[DataContract]
	public class PublicarRespostaRequest
	{
		[DataMember(Name = "criterios")]
		public List<Criterio> Criterios { get; set; }

		[DataMember(Name = "reposta")]
		public string Resposta { get; set; }


		public Guid UsuarioId { get; set; }
		public Guid VagaId { get; set; }


	}
}
