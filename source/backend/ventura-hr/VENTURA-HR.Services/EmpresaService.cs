using VENTURA_HR.DOMAIN.UsuarioAggregate.Entities;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Repositories;
using VENTURA_HR.DOMAIN.UsuarioAggregate.Services;

namespace VENTURA_HR.Services
{
	public class EmpresaService : ServiceBase<Empresa, IEmpresaRepository>, IEmpresaService
	{
		private IEmpresaRepository EmpresaRepository;
		public EmpresaService(IEmpresaRepository empresaRepository) : base(empresaRepository)
		{
			EmpresaRepository = empresaRepository;
		}
	}
}
