using VENTURA_HR.DOMAIN.UsuarioAggregate.Entities;

namespace VENTURA_HR.DOMAIN.UsuarioAggregate.Repositories
{
	public interface IUsuarioRepository : IRepositoryBase<Usuario>
	{
		public Usuario GetUsuarioTeste(string login, string senha);
	}
}
