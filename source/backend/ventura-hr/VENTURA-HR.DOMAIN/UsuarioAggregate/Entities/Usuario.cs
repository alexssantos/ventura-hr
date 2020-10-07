using System;
using VENTURA_HR.DOMAIN.Shared;

namespace VENTURA_HR.DOMAIN.UsuarioAggregate.Entities
{
	public abstract class Usuario : Entity
	{
		public Usuario() : base()
		{

		}

		public string Login { get; set; }
		public string Password { get; set; }
		public string Email { get; set; }
		public string Nome { get; set; }
		public DateTime BirthDate { get; set; }
	}
}
