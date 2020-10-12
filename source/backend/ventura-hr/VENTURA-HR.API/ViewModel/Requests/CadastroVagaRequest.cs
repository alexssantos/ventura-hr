using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace VENTURA_HR.API.ViewModel.Requests
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
	}
}
