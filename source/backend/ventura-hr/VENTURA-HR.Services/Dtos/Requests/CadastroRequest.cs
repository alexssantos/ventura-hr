using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Enums;

namespace VENTURA_HR.Services.Dtos.Requests
{
	[DataContract]
	public class CadastroRequest
	{
		[Required(ErrorMessage = "Senha é obrigatório")]
		[DataMember(Name = "login")]
		public string Login { get; set; }

		[Required(ErrorMessage = "Senha é obrigatório")]
		[DataMember(Name = "senha")]
		public string Senha { get; set; }

		[Required(ErrorMessage = "tipo é obrigatório")]
		[Range(1, 3)]
		[DataMember(Name = "tipo")]
		public EUsuarioTipo Tipo { get; set; }

		[Required(ErrorMessage = "email é obrigatório")]
		[EmailAddress]
		[DataMember(Name = "email")]
		public string Email { get; set; }

		[Required(ErrorMessage = "documento é obrigatório")]
		[DataMember(Name = "documento")]
		public string Documento { get; set; }

		[StringLength(256, ErrorMessage = "Nome precisa ter entre 3 e 256 caracteres", MinimumLength = 3)]
		[DataMember(Name = "nome")]
		public string Nome { get; set; }

		[DataType(DataType.Date)]
		[DataMember(Name = "dataNascimento")]
		public DateTime DataNascimento { get; set; }
	}
}
