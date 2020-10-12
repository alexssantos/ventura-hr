using VENTURA_HR.DOMAIN.UsuarioAggregate.Entities;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Repositories;
using VENTURA_HT.Repository.Context;

namespace VENTURA_HT.Repository.Repositories
{
	public class AdministradorRepository : RepositoryBase<Administrador>, IAdministradorRepository
	{
		public AdministradorRepository(VenturaContext context) : base(context)
		{

		}
	}
}
