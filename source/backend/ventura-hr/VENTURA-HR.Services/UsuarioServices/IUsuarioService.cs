using VENTURA_HR.DOMAIN.Shared;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Entities;
using VENTURA_HR.Services.Dtos.Requests;

namespace VENTURA_HR.Services.UsuarioServices
{
	public interface IUsuarioService : IServiceBase<Usuario>
	{
		public Usuario Cadastrar(CadastroRequest form);
	}
}
