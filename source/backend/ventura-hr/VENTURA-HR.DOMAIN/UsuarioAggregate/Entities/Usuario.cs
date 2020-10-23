using System;
using VENTURA_HR.DOMAIN.Shared;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Enums;

namespace VENTURA_HR.DOMAIN.UsuarioAggregate.Entities
{
	public class Usuario : Entity
	{
		public Usuario() : base()
		{

		}

		public string Login { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public string Nome { get; set; }
		public DateTime? DataNascimento { get; set; }
		public EUsuarioTipo TipoUsuario { get; set; }
	}
}
