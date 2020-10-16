using VENTURA_HR.DOMAIN.Shared;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Entities;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Enums;

namespace VENTURA_HR.Services.UsuarioServices
{
	public interface IUsuarioService : IServiceBase<Usuario>
	{
		public Usuario Cadastrar(string login, string senha, EUsuarioTipo tipoUsuario);
	}
}
