using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace VENTURA_HR.Services.Dtos.Requests
{
	[DataContract]
	public class LoginForm
	{
		[Required]
		[DataMember(Name = "login")]
		public string Login { get; set; }

		[Required]
		[DataMember(Name = "senha")]
		public string Senha { get; set; }
	}
}
