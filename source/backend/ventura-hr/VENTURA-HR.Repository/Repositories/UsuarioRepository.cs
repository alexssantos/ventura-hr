using VENTURA_HR.DOMAIN.UsuarioAggregate.Entities;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Repositories;
using VENTURA_HT.Repository.Context;

namespace VENTURA_HT.Repository.Repositories
{
	public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
	{
		public UsuarioRepository(VenturaContext context) : base(context)
		{
		}
	}
}
