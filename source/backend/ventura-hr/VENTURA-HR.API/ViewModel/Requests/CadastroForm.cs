using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Enums;

namespace VENTURA_HR.API.ViewModel.Requests
{
	[DataContract]
	public class CadastroForm
	{
		[Required]
		[DataMember(Name = "login")]
		public string Login { get; set; }

		[Required]
		[DataMember(Name = "senha")]
		public string Senha { get; set; }

		//Nao atribuir DataMember
		[Required]
		[Range(1, 3)]
		[DataMember(Name = "tipo")]
		public EUsuarioTipo Tipo { get; set; }
	}
}
