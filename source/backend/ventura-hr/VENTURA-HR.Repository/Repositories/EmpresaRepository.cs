using VENTURA_HR.DOMAIN.UsuarioAggregate.Entities;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Repositories;
using VENTURA_HT.Repository.Context;

namespace VENTURA_HT.Repository.Repositories
{
	public class EmpresaRepository : RepositoryBase<Empresa>, IEmpresaRepository
	{

		public EmpresaRepository(VenturaContext context) : base(context)
		{
		}
	}
}
