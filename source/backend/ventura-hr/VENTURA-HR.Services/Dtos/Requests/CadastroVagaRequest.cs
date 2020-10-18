using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace VENTURA_HR.Services.Dtos.Requests
{
	[DataContract]
	public class CadastroVagaRequest
	{
		[Required]
		[DataMember(Name = "descricao")]
		public string Descricao { get; set; }

		[Required]
		[DataMember(Name = "empresaId")]
		public Guid EmpresaId { get; set; }

		[Required]
		[DataMember(Name = "criterios")]
		[MinLength(1)]
		public ICollection<CriterioItem> Criterios { get; set; }

		[DataContract]
		public partial class CriterioItem
		{
			[Required]
			[DataMember(Name = "titulo")]
			public string Titulo { get; set; }

			[Required]
			[Range(1, 5)]
			[DataMember(Name = "peso")]
			public int Peso { get; set; }
		}
	}
}
