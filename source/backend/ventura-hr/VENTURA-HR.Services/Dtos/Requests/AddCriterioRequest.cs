using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace VENTURA_HR.Services.Dtos.Requests
{
	[DataContract]
	public class AddCriterioRequest
	{
		[DataMember(Name = "cargo")]
		[Required]
		public string Cargo { get; set; }

		[DataMember(Name = "descricao")]
		[Required]
		public string Descricao { get; set; }
	}
}
